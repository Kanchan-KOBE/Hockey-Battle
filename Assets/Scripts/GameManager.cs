using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int highScore = 0;
    public static string userName = "未設定";

    public static int howManyPlayersPlusOne = 3;
    public static int howManyEnemysPlusOne = 11;

    public static bool[] unlockP = new bool[howManyPlayersPlusOne];
    public static bool[] unlockE = new bool[howManyEnemysPlusOne];




    void Awake(){
        unlockP[0] = true;
        unlockP[1] = true;
        unlockE[0] = true;
        unlockE[1] = true;
        
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

}
