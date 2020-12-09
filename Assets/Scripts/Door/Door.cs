using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    // 控制collider的启动和关闭
    private BoxCollider2D coll;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        // 碰撞器默认不启用
        coll.enabled = false;
    }

    /// GameManager调用，当所有敌人死亡后打开门
    public void OpenDoor()
    {
        anim.Play("open");
        // 打开门后重新启用碰撞器
        coll.enabled = true;
    }
    
    // 当玩家碰撞到门的时候进入下一个场景（关卡）
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ;
        // GameManager进入下一个房间

    }
}