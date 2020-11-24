using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 单例模式
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    /// 获得血量UI
    public GameObject healthBar;

    [Header("UI Elements")] public GameObject pauseMenu;

    private void Awake()
    {
        if (instance == null)

            instance = this;
        else
            Destroy(gameObject);
    }

    /// 更新面板血量
    public void UpdateHP(float currentHP)
    {
        switch (currentHP)
        {
            case 3:
                healthBar.transform.GetChild(0).gameObject.SetActive(true);
                healthBar.transform.GetChild(1).gameObject.SetActive(true);
                healthBar.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                healthBar.transform.GetChild(0).gameObject.SetActive(true);
                healthBar.transform.GetChild(1).gameObject.SetActive(true);
                healthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                healthBar.transform.GetChild(0).gameObject.SetActive(true);
                healthBar.transform.GetChild(1).gameObject.SetActive(false);
                healthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 0:
                healthBar.transform.GetChild(0).gameObject.SetActive(false);
                healthBar.transform.GetChild(1).gameObject.SetActive(false);
                healthBar.transform.GetChild(2).gameObject.SetActive(false);
                break;
        }
    }


    // 点击暂停按钮，讲暂停界面显示出来并且游戏暂停
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        // 游戏暂停
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        // 游戏暂停
        Time.timeScale = 1;
    }
}