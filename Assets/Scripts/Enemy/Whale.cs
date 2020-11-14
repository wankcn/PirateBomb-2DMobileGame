using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : Enemy, IDamageable
{
  

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