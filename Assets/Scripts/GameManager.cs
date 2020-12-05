using System;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest instance;
    private PlayerController player;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}