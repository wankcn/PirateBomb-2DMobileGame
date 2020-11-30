using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : Enemy, IDamageable
{
    /// 每次吞下炸弹体积扩大20%
    private float scale = 1.2f;

    // 计算鲸鱼吞炸弹的次数 预留功能
    // private int tag = 0;

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

    public void Swalow()
    {
        targetPonit.GetComponent<Bomb>().TurnOff();
        targetPonit.gameObject.SetActive(false);

        // 扩大体积
        transform.localScale *= scale;
        tag += 1;
    }
}