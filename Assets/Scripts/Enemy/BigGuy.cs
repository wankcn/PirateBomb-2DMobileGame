using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuy : Enemy, IDamageable
{
    /// 控制pickup的组件 坐标位置
    public Transform pickUpPoint;

    public float force;

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

    /// 事件方法，捡起炸弹
    public void PickUpBomb()
    {
        // 如果标签是炸弹，改变炸弹的位置 并且敌人检测范围内没有炸弹
        if (targetPonit.CompareTag("Bomb") && !hasBomb)
        {
            // 改变坐标位置
            targetPonit.gameObject.transform.position = pickUpPoint.position;
            // 控制炸弹跟随人物移动，使得炸弹成为pickuppoint的子集
            targetPonit.SetParent(pickUpPoint);
            // 炸弹捡起来以后，重力应该取消掉
            targetPonit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            hasBomb = true;
        }
    }

    public void ThrowAway() // event
    {
        if (hasBomb)
        {
            targetPonit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            // 脱离父子关系 返回两集
            targetPonit.SetParent(transform.parent.parent);

            // 扔炸弹（按照玩家的方向扔出物体） 获得实时的玩家x轴的坐标值
            if (FindObjectOfType<PlayerController>().gameObject.transform.position.x - transform.position.x < 0)
                targetPonit.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * force, ForceMode2D.Impulse);
            else
                targetPonit.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * force, ForceMode2D.Impulse);
        }

        hasBomb = false;
    }
}