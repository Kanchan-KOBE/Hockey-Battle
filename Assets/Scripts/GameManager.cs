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


    private bool _shouldCreateAccount;
    private string _customID;


    void Awake(){
        unlockP[0] = true;
        unlockP[1] = true;
        unlockS[0] = true;
        unlockS[1] = true;
        
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenuScene"){
            Login();
        }
        
    }
   


    void Update()
    {
        
    }


    //=================================================================================
    //LogIn

    private void Login() //Login
    {
        _customID = LoadCustomID();
        var request = new LoginWithCustomIDRequest { CustomId = _customID,  CreateAccount = _shouldCreateAccount};
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        
    }

    private void OnLoginSuccess(LoginResult result){ //ログイン成功
        //IDが既に使われている場合
        if (_shouldCreateAccount && !result.NewlyCreated) {
            Debug.LogWarning($"CustomId : {_customID} は既に使われています。");
            Login();//ログインしなおし
            return;
        }

        //アカウント作成時にIDを保存
        if (result.NewlyCreated) {
            SaveCustomID();
            uI_InputField.SetActive(true);
        }
        Debug.Log($"PlayFabのログインに成功\nPlayFabId : {result.PlayFabId}, CustomId : {_customID}\nアカウントを作成したか : {result.NewlyCreated}");
        SetPlayerDisplayName();
    }
        
    private void OnLoginFailure(PlayFabError error){  //ログイン失敗
        Debug.LogError($"PlayFabのログインに失敗\n{error.GenerateErrorReport()}");
    }

    public void SetPlayerDisplayName () {
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest {
                DisplayName = userName
            },
            result => {
                Debug.Log("Set display name was succeeded.");
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }

    //=================================================================================
    //カスタムIDの取得

    private static readonly string CUSTOM_ID_SAVE_KEY = "CUSTOM_ID_SAVE_KEY";    //IDを保存する時のKEY
    
    private string LoadCustomID() { //IDを取得
    string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);
    _shouldCreateAccount = string.IsNullOrEmpty(id);    //保存されていなければ新規生成
    return _shouldCreateAccount ? GenerateCustomID() : id;
    }

    private void SaveCustomID() {    //IDの保存
    PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, _customID);
    }

    //=================================================================================
    //カスタムIDの生成
    
    private string GenerateCustomID() {     //IDを生成する
    Guid guid = Guid.NewGuid();    //Guidの構造体生成
    Debug.Log("GUID : " + guid.ToString());    //生成されたGUIDを確認
    return guid.ToString();
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
