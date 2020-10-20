using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerController controller;

    // 获取刚体用于得到物体的x，y轴移动
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
        // 是否跳跃和是否落地可以通过PlayerController中的isJump和isGround来进行判断
        anim.SetBool("jump", controller.isJump);
        anim.SetBool("ground", controller.isGround);
    }
}