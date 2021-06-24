using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int highScore = 0;


    public static int howManyPlayersPlusOne = 3;
    public static int howManyEnemysPlusOne = 3;

    public static bool[] unlockP = new bool[howManyPlayersPlusOne];

    public static int howManyStagesPlusOne = 3;
    public static bool[] unlockS = new bool[howManyStagesPlusOne];

    public int numberPlayer = 0;
    public int numberEnemy = 0;



    void Start()
    {
         PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest { CustomId = "TestID2", CreateAccount = true},
            result => Debug.Log("ログイン成功！"),
            error => Debug.Log("ログイン失敗")
        );
    }
   


    void Update()
    {
        
    }

    void Awake(){
        numberEnemy = EnemyManager.enemyNumber;
        numberPlayer = PlayerManager.playerNumber;
        // unlockP = unlockPtest;
        // unlockS = unlockStest;
        unlockP[0] = true;
        unlockP[1] = true;
        unlockS[0] = true;
        unlockS[1] = true;
        

    }

    public void SubmitScore() //スコア送信
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "HighScore",
                        Value = highScore
                    }
                }
            },
            result =>
            {
                Debug.Log("スコア送信");
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }

}
