using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 游戏玩家控制器，主要包含玩家的基本移动即左右移动和跳跃攻击
public class PlayerController : MonoBehaviour
{
    // 获取刚体组件 
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce; // 跳跃的力

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        Movement();
    }


    // 执行人物移动的方法 需要获取按键
    void Movement()
    {
        // float horizontalInput = Input.GetAxis("Horizontal"); // 获取的值从-1～1，包括小数

        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 获取的值从-1～1，不包含小数
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y); // 使用物理向量的速度固定移动速度 y保持不变，x为输入*速度

        // 修改transform的本地坐标来进行翻转
        if (horizontalInput != 0)
            transform.localScale = new Vector3(horizontalInput, 1, 1);
    }
}