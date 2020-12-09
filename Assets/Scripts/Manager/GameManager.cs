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
    private Door doorExit;

    // 将所有的敌人添加到一个List里，当list为空表示所有敌人被消灭，即打开门
    public List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // FindObjectOfType()寻找代码脚本的方式
        player = FindObjectOfType<PlayerController>();
        doorExit = FindObjectOfType<Door>();
    }

    public void Update()
    {
        // 玩家死亡游戏结束
        gameOver = player.isDead;
        UIManager.instance.GameOverUI(gameOver);
    }

    /// 通过Enemy调用，当游戏开始把场景中的敌人添加到敌人列表
    public void isEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    /// 如果敌人死亡，把该敌人从敌人列表中移除
    public void EnemyDead(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
            doorExit.OpenDoor();
    }

    /// 重新加载游戏场景
    public void RestartScene()
    {
        // GetActiveScene()获得当前的场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 进入下一个关卡
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}