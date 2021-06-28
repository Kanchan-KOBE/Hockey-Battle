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
    public MainMenuManager mainManager;
    private bool _shouldCreateAccount;
    public static string _customUserID;
    public static string userName = default;

    public static int highScore = 0;

    public static int howManyPlayersPlusOne = 11;
    public static int howManyEnemysPlusOne = 11;

    public static bool[] unlockP = new bool[howManyPlayersPlusOne];
    public static bool[] unlockE = new bool[howManyEnemysPlusOne];

    [SerializeField] GameObject nameInputUI;


    void Awake(){
        unlockP[0] = true;
        unlockP[1] = true;
        unlockE[0] = true;
        unlockE[1] = true;
        if(SceneManager.GetActiveScene().name == "MainMenuScene"){
            
            Login();
            
        }
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

//=========================================================================
//ログイン
    void Login()
    {
        _customUserID = LoadCustomID();
        var request = new LoginWithCustomIDRequest { CustomId = _customUserID,  CreateAccount = _shouldCreateAccount};
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

        private void OnLoginSuccess(LoginResult result)
        {
            if (_shouldCreateAccount && !result.NewlyCreated) { //ifアカウントID重複
                Debug.LogWarning($"CustomId : {_customUserID} は既に使われています。");
                Login();//ログインしなおし
                return;
            }
            if (result.NewlyCreated) {//アカウント作成時にIDを保存
                SaveCustomID();
                if(SceneManager.GetActiveScene().name == "MainMenuScene"){
                    nameInputUI.SetActive(true);
                }
            }
            Debug.Log($"PlayFabのログインに成功\nPlayFabId : {result.PlayFabId}, CustomId : {_customUserID}\nアカウントを作成したか : {result.NewlyCreated}");
            SubmitScore(0);
            GetUserName();
        }
        private void OnLoginFailure(PlayFabError error)
        {
            Debug.LogError($"PlayFabのログインに失敗\n{error.GenerateErrorReport()}");
        }

    private static readonly string CUSTOM_ID_SAVE_KEY = "CUSTOM_T_ID_SAVE_KEY";    //IDを保存する時のKEY
    
    public string LoadCustomID() {//IDを取得
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);
        
        _shouldCreateAccount = string.IsNullOrEmpty(id);
        return _shouldCreateAccount ? GenerateCustomID() : id;
    }

    private void SaveCustomID() {//IDを保存
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, _customUserID);
    }

    private string GenerateCustomID() {//ランダムにIDを生成
        Guid guid = Guid.NewGuid();
        Console.WriteLine("GUID : " + guid.ToString());
        return guid.ToString();
    }



//=========================================================================
//ユーザー名
    public void UpdateUserName() { //更新
        var updateDataDict = new Dictionary<string, string>() {
        {"Name", userName},
        };

        var request = new UpdateUserDataRequest {
        Data         = updateDataDict, 
        Permission   = UserDataPermission.Private //アクセス許可設定
        };
        
        PlayFabClientAPI.UpdateUserData(request, OnSuccessUpdatingPlayerName, OnErrorUpdatingPlayerName);
        Debug.Log($"プレイヤーデータの更新開始");
        if(SceneManager.GetActiveScene().name == "MainMenuScene"){
            DeleteUI();
        }


        PlayFabClientAPI.UpdateUserTitleDisplayName( //DisplayNameに追加
            new UpdateUserTitleDisplayNameRequest {
                DisplayName = userName
            },
            result => {
                Debug.Log("Namw : " + userName);
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }
        private void OnSuccessUpdatingPlayerName(UpdateUserDataResult result) {
            Debug.Log($"成功(Name)更新");
            //result.ToJsonでjsonで形式で結果を確認可能(result.Dataはない)
        }
        private void OnErrorUpdatingPlayerName(PlayFabError error) {
            Debug.LogWarning($"失敗(Name)更新 : {error.GenerateErrorReport()}");
        }

    public void GetUserName() { //取得
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, OnSuccessGettingPlayerData, OnErrorGettingPlayerData);
    }
        private void OnSuccessGettingPlayerData(GetUserDataResult result) {
            userName = result.Data["Name"].Value;
            Debug.Log("You are " + userName);
        }
        private void OnErrorGettingPlayerData(PlayFabError error) {
            Debug.LogWarning($"ユーザーデータの取得に失敗しました : {error.GenerateErrorReport()}");
        }





//=================================================================================
//スコア
    public void SubmitScore(int playerScore) //更新
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "HighScore",
                        Value = playerScore
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

    

//=================================================================================
//ランキング

[SerializeField]  private Text rankerName = default;
[SerializeField]  private Text rankerScore = default;
    public void RequestLeaderBoard()
    {
        PlayFabClientAPI.GetLeaderboard(
            new GetLeaderboardRequest
            {
                StatisticName = "HighScore",
                StartPosition = 0,
                MaxResultsCount = 10
            },
            result =>
            {
                result.Leaderboard.ForEach(
                    x => Debug.Log(string.Format("{0}位:{1} スコア{2}", x.Position + 1, x.DisplayName, x.StatValue))
                    );
            },
            error =>
            {
                Debug.Log(error.GenerateErrorReport());
            }
            );
    }
    public void GetLeaderboardAroundPlayer() { 
        var request = new GetLeaderboardAroundPlayerRequest{
            StatisticName   = "HighScore", //ランキング名(統計情報名)
            MaxResultsCount = 1  //自分を含め前後何件取得するか
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetLeaderboardAroundPlayerSuccess, OnGetLeaderboardAroundPlayerFailure);
    }
        private void OnGetLeaderboardAroundPlayerSuccess(GetLeaderboardAroundPlayerResult result){

            foreach (var entry in result.Leaderboard) {
                rankerName.text += $"\n{entry.DisplayName}";
            }
            foreach (var entry in result.Leaderboard) {
                rankerScore.text += $"\n{entry.StatValue}";
            }
            // foreach (var entry in result.Leaderboard) {
            //     rankerScore.text += $"\n順位 : {entry.Position}";
            // }
        }
        private void OnGetLeaderboardAroundPlayerFailure(PlayFabError error){
            Debug.LogError($"自分の順位周辺のランキングの取得に失敗しました\n{error.GenerateErrorReport()}");
        }



    public void OpenUI(){
        nameInputUI.SetActive(true);
    }
    public void DeleteUI(){
        nameInputUI.SetActive(false);
    }

    public void Tst(){
        userName = "Test";
    }

}
