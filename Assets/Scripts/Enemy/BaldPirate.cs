using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldPirate : Enemy, IDamageable
{
    /// 事件方法执行在吹灭动画里
    public void SetOff()
    {
        targetPonit.GetComponent<Bomb>().TurnOff();
    }

    public void GetHit(float damage)
    {
        enemyHP -= damage;
        if (enemyHP < 1)
        {
            enemyHP = 0;
            isDead = true;
        }

        anim.SetTrigger("hit");
    }
}