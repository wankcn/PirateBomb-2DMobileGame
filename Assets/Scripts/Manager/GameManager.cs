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

        // // FindObjectOfType()寻找代码脚本的方式
        // player = FindObjectOfType<PlayerController>();
        // doorExit = FindObjectOfType<Door>();
    }

    public void Update()
    {
        // 玩家死亡游戏结束 避免没有Player时报错
        if (player != null)
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
        {
            doorExit.OpenDoor();
            SaveData();
        }
    }

    /// 重新加载游戏场景
    public void RestartScene()
    {
        // GetActiveScene()获得当前的场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 重新加载时玩家恢复数据 删掉键值重新创建
        PlayerPrefs.DeleteKey("PlayerHealth");
    }

    // 进入下一个关卡
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // 观察者模式，使场景中删除player也不产生报错
    public void IsPlayer(PlayerController playerController)
    {
        player = playerController;
    }

    // 观察者模式，使场景中删除door也不产生报错
    public void IsDoorExit(Door door)
    {
        doorExit = door;
    }


    // 保存血量，加载血量的函数方法
    // 加载血量 判断有没有键值，没有就初始化为3，有的话获得当前键值的血量
    public float LoadHealth()
    {
        // 如果存储数据中没有PlayerHealth键值就来设置它 代表游戏的初始化
        if (!PlayerPrefs.HasKey("PlayerHealth"))
            PlayerPrefs.SetFloat("PlayerHealth", 3f);
        // 从一个场景到另外一个场景已经存在Key PlayerHealth，设置临时变量从键值里取值
        float curHealth = PlayerPrefs.GetFloat("PlayerHealth");
        return curHealth;
    }

    // 存储Player当前的血量
    public void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerHealth", player.playerHP);
        PlayerPrefs.Save(); // 创建保存文件
    }

    // 结束游戏，只在生成后生效
    public void QuitGame()
    {
        Application.Quit();
    }
}