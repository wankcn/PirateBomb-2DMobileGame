using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    private float attackDamage = 1;

    /// 力的方向
    private int dir;

    /// 判断哪一个敌人可以使用攻击炸弹的方法
    public bool bombAviable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 炸弹在左侧
        if (transform.position.x > other.transform.position.x)
            dir = -1;
        else
            dir = 1;


        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamageable>().GetHit(attackDamage);
        }

        if (other.CompareTag("Bomb") && bombAviable)
        {
            // 施加力的物体使用AddForce添加力，dir是力的方向，1为斜上方的方向，施加斜上方的力 *10/9.8 冲击力的方式
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir,1)*10,ForceMode2D.Impulse);
        }
    }
}