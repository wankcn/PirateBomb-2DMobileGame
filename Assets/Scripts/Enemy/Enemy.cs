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
        targetPonit = ponitA;
    }

    void Update()
    {
        MoveToTarget();
    }
    
    // 移动的方法
    public void MoveToTarget()
    {
        // 朝着目标进行移动（当前坐标，目标坐标，距离的Delta值,确保在不同的机型得到同样的效果）
        transform.position = Vector2.MoveTowards(transform.position, targetPonit.position,
            speed * Time.deltaTime);
        FilpDirection();
    }

    // 攻击玩家
    public void AttackAction()
    {
    }

    // 对炸弹进行技能攻击
    public void SkillAction()
    {
    }

    // 巡逻过程中需要左右翻转 他一定是在移动的过程中进行调用的
    public void FilpDirection()
    {
    }
}