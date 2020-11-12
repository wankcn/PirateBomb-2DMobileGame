using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator anim; // 控制动画切换
    private Collider2D coll; // 用于脱离炸弹碰撞体
    private Rigidbody2D rb; // 用于设置炸弹重力防止掉出屏幕

    // 记录炸弹引爆的开始时间以及等待爆炸的时间
    private float startTime;
    public float waitTime;

    /// 爆炸作用力
    public float bombForce;

    /// 炸弹造成的伤害值
    private float bombDamage = 3.0f;

    // 检测元素
    [Header("Check")] public float radius; // 范围半径
    public LayerMask targetLayer; // 受爆炸影响的层级

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("bomb_off"))
        {
            // 如果当前的游戏时间大于开始时间+等待时间
            if (Time.time > startTime + waitTime)
                anim.Play("bomb_explosion");
        }
    }

    /// 爆炸效果，是一个Animation Event
    public void Explosion()
    {
        // 检测范围之前脱离炸弹的碰撞体
        coll.enabled = false;
        // 重力设置为0防止掉落出地面
        rb.gravityScale = 0;
        // 坐标，检测范围，图层
        Collider2D[] aroundObjects = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        foreach (var i in aroundObjects)
        {
            // 判断物体的方向
            Vector3 pos = transform.position - i.transform.position;
            i.GetComponent<Rigidbody2D>().AddForce((-pos + Vector3.up) * bombForce, ForceMode2D.Impulse);

            // 判断周围的是否是炸弹并且处于熄灭状态把熄灭的那颗炸弹点燃
            if (i.CompareTag("Bomb") && i.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("bomb_off"))
            {
                i.GetComponent<Bomb>().TurnOn();
            }

            if (i.CompareTag("Player"))
                i.GetComponent<IDamageable>().GetHit(bombDamage);
        }
    }

    // 炸弹消失的事件方法
    public void Destroy()
    {
        Destroy(gameObject);
    }

    /// 炸弹被吹灭的方法
    public void TurnOff()
    {
        anim.Play("bomb_off");
        gameObject.layer = LayerMask.NameToLayer("NPC");
    }

    /// 炸弹被重新点燃的方法
    public void TurnOn()
    {
        startTime = Time.time;
        anim.Play("bomb_on");
        gameObject.layer = LayerMask.NameToLayer("Bomb");
    }

    // 检测范围可视化
    public void OnDrawGizmos()
    {
        // 中心点/检测范围
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}