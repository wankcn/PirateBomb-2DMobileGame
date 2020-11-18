using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain : Enemy, IDamageable
{
    private SpriteRenderer sprite;

    public override void Init()
    {
        base.Init();
        sprite = GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        base.Update();
        if (animState == 0)
            sprite.flipX = false;
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

    public override void SkillAction()
    {
        base.SkillAction();
        // 如果播放的是害怕skill，往相反方向跑
        if (anim.GetCurrentAnimatorStateInfo(1).IsName("captain_skill"))
        {
            // 播放动画的过程中对人物进行翻转
            sprite.flipX = true;
            // 炸弹在人物的左侧，向右跑
            if (transform.position.x > targetPonit.position.x)
                transform.position = Vector2.MoveTowards(transform.position,
                    transform.position + Vector3.right, speed * 2 * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position,
                    transform.position + Vector3.left, speed * 2 * Time.deltaTime);
        }
        else
            sprite.flipX = false;
    }
}