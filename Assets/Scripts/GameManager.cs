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
    [SerializeField] GameObject uI_InputField;

    public static int howManyPlayersPlusOne = 3;
    public static int howManyEnemysPlusOne = 3;

    public static bool[] unlockP = new bool[howManyPlayersPlusOne];

    public static int howManyStagesPlusOne = 3;
    public static bool[] unlockS = new bool[howManyStagesPlusOne];




    void Awake(){
        unlockP[0] = true;
        unlockP[1] = true;
        unlockS[0] = true;
        unlockS[1] = true;
        
    }

    void Start()
    {
        
        if(SceneManager.GetActiveScene().name == "MainMenuScene"){
            PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);
        }

        
        
    }

    void OnEnable()
    {
        PlayFabAuthService.OnLoginSuccess += PlayFabLogin_OnLoginSuccess;
    }
    private void PlayFabLogin_OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login Success!");
    }
    private void OnDisable()
    {
        PlayFabAuthService.OnLoginSuccess -= PlayFabLogin_OnLoginSuccess;
    }
   


    void Update()
    {
        
    }


    
    //=================================================================================
    //Score送信
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

    public void Delete_InputField(){
        uI_InputField.SetActive(false);
    }

}
