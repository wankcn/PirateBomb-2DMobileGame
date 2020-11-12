using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    private float attackDamage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO 玩家受到伤害
            other.GetComponent<IDamageable>().GetHit(attackDamage);
        }

        if (other.CompareTag("Bomb"))
        {
            // TODO 炸弹效果
        }
    }
}