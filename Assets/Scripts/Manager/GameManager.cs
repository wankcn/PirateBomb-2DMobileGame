using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 单例模式
    public static GameManager instance;

    /// 代表游戏结束
    public bool gameOver;

    private PlayerController player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // FindObjectOfType()寻找代码脚本的方式
        player = FindObjectOfType<PlayerController>();
    }

    public void Update()
    {
        // 玩家死亡游戏结束
        gameOver = player.isDead;
        UIManager.instance.GameOverUI(gameOver);
    }

    /// 重新加载游戏场景
    public void RestartScene()
    {
        // GetActiveScene()获得当前的场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}