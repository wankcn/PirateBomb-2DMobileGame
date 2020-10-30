using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    // 移动的方法
    public void MoveToTarget()
    {
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