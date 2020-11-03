using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")] public float speed; // 移动速度
    public Transform ponitA, pointB;
    public Transform targetPonit; // 目标点

    public List<Transform> attackList = new List<Transform>();

    void Start()
    {
        SwitchPoint();
    }

    void Update()
    {
        // 无限趋近于目标点
        if (Mathf.Abs(transform.position.x - targetPonit.position.x) < 0.01f)
            SwitchPoint();
        MoveToTarget();
    }

    /// 移动的方法
    public void MoveToTarget()
    {
        // 朝着目标进行移动（当前坐标，目标坐标，距离的Delta值,确保在不同的机型得到同样的效果）
        transform.position = Vector2.MoveTowards(transform.position, targetPonit.position,
            speed * Time.deltaTime);
        FilpDirection();
    }

    /// 攻击玩家
    public void AttackAction()
    {
    }


    /// 对炸弹进行技能攻击
    public void SkillAction()
    {
    }

    /// 巡逻过程中需要左右翻转 他一定是在移动的过程中进行调用的
    public void FilpDirection()
    {
        // 在目标点的左侧，向右追不需要翻转
        if (transform.position.x < targetPonit.position.x)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }


    /// 判断当前坐标与PointA和B的位置，将移动的目标点设置为距离远的那一个
    public void SwitchPoint()
    {
        // A点于当前怪物的距离>B点到当前怪物的距离说明A点远
        if (Mathf.Abs(ponitA.position.x - transform.position.x)
            > Mathf.Abs(pointB.position.x - transform.position.x))
            targetPonit = ponitA;
        else
            targetPonit = pointB;
    }

    /// 物体进入检测范围就添加进攻击列表里
    private void OnTriggerStay2D(Collider2D other)
    {
        // 如果攻击列表不包含，再添加进列表里 添加的是transform
        if (!attackList.Contains(other.transform))
            attackList.Add(other.transform);
    }

    /// 物体走出检测范围从攻击列表里移除
    private void OnTriggerExit2D(Collider2D other)
    {
        attackList.Remove(other.transform);
    }
}