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
    public static string userID = "0123456789ABCDEF";
    public static string userName = "-----";
    public static int userRank = 0;
    public static int highScore = 0;

    public static int howManyPlayersPlusOne = 11;
    public static int howManyEnemysPlusOne = 11;


    [SerializeField] GameObject initNameUI;


    void Awake(){
        
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene"){ 
            Login();
        }
        Time.timeScale = 1.0f;
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
            if (result.NewlyCreated) {
                if(SceneManager.GetActiveScene().name == "TitleScene"){
                    initNameUI.SetActive(true);
                }
                SubmitScore();
                PlayerPrefs.SetFloat("Volume_BGM", 1.0f);
                PlayerPrefs.SetFloat("Volume_SE", 1.0f);
            }
            Debug.Log($"PlayFabのログインに成功\nPlayFabId : {result.PlayFabId}, CustomId : {_customUserID}\nアカウントを作成したか : {result.NewlyCreated}");
            GetUserData();
            
        }
        private void OnLoginFailure(PlayFabError error)
        {
            Debug.LogError($"PlayFabのログインに失敗\n{error.GenerateErrorReport()}");
        }

    private static readonly string CUSTOM_ID_SAVE_KEY = "CUSTOM_K_ID_SAVE_KEY";    //IDを保存する時のKEY
    
    public string LoadCustomID() {//IDを取得
        string id = PlayerPrefs.GetString(CUSTOM_ID_SAVE_KEY);
        
        _shouldCreateAccount = string.IsNullOrEmpty(id);
        return _shouldCreateAccount ? GenerateCustomID() : id;
    }

    public void SaveCustomID() {//IDを保存
        PlayerPrefs.SetString(CUSTOM_ID_SAVE_KEY, _customUserID);
    }

    private string GenerateCustomID() {//ランダムにIDを生成
        Guid guid = Guid.NewGuid();
        Console.WriteLine("GUID : " + guid.ToString());
        return guid.ToString();
    }

    public void GetUserID() { //取得
        var request = new GetLeaderboardAroundPlayerRequest{StatisticName = "HighScore", MaxResultsCount = 1};
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetUserIDSuccess, OnGetUserIDFailure);
    }
        private void OnGetUserIDSuccess(GetLeaderboardAroundPlayerResult result){
            foreach (var entry in result.Leaderboard) {
                userID = $"{entry.PlayFabId}";
            }
            Debug.Log("ID : " + userID);
        }
        private void OnGetUserIDFailure(PlayFabError error){
            Debug.LogError($"ユーザー名の取得に失敗しました\n{error.GenerateErrorReport()}");
        }

    private void GetUserData(){//ユーザーデータまとめて取得
        GetUserName();
        GetUserRank();
        GetUserScore();
        GetUserID();
    }

//=========================================================================
//登録＆ログイン
    public void PressRegisterButton()//登録
    {
        var RegisterData = new RegisterPlayFabUserRequest()
        {
            TitleId = "33E40",
            Email = "shunsuke.k.9969@gmail.com",
            Password = "Shun9969",
            Username = "Kanchan"
        };

        PlayFabClientAPI.RegisterPlayFabUser(RegisterData, result => 
        {
            Debug.Log("Congratulations, you made your PlayFab account!");
            GetUserData();
        }, error => Debug.Log(error.GenerateErrorReport()));
    }

    public void PressLoginButton()//ログイン
    {
        var LoginData = new LoginWithEmailAddressRequest()
        {
            TitleId = "33E40",
            Email = "shunsuke.k.9969@gmail.com",
            Password = "Shun9969",
        };
        PlayFabClientAPI.LoginWithEmailAddress(LoginData, result => 
        {
            Debug.Log("Congratulations, you made your first successful API call!");
            GetUserData();
        }, error => Debug.Log(error.GenerateErrorReport()));
    }


//=========================================================================
//ユーザー名
    public void UpdateUserName() { //更新
        PlayFabClientAPI.UpdateUserTitleDisplayName(
            new UpdateUserTitleDisplayNameRequest {
                DisplayName = userName
            },
            result => {
                Debug.Log("New Name : " + userName);
                mainManager.RefleshName();
            },
            error => {
                Debug.LogError(error.GenerateErrorReport());
            }
        );
    }

    public void GetUserName() { //取得
        var request = new GetLeaderboardAroundPlayerRequest{StatisticName = "HighScore", MaxResultsCount = 1};
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetUserNameSuccess, OnGetUserNameFailure);
    }
        private void OnGetUserNameSuccess(GetLeaderboardAroundPlayerResult result){
            foreach (var entry in result.Leaderboard) {
                userName = $"{entry.DisplayName}";
            }
            Debug.Log("Name : " + userName);
            mainManager.RefleshName();
        }
        private void OnGetUserNameFailure(PlayFabError error){
            Debug.LogError($"ユーザー名の取得に失敗しました\n{error.GenerateErrorReport()}");
        }
        





//=================================================================================
//スコア
    public void SubmitScore() //更新
    {
        PlayFabClientAPI.UpdatePlayerStatistics(
            new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>()
                {
                    new StatisticUpdate
                    {
                        StatisticName = "HighScore",
                        Value = ARGameManager.newScore
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

    public void GetUserScore() { //取得
        var request = new GetLeaderboardAroundPlayerRequest{StatisticName = "HighScore", MaxResultsCount = 1};
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetUserScoreSuccess, OnGetUserScoreFailure);
    }
        private void OnGetUserScoreSuccess(GetLeaderboardAroundPlayerResult result){
            foreach (var entry in result.Leaderboard) {
                highScore = int.Parse($"{entry.StatValue}");
            }
            Debug.Log("Score : " + highScore);
            mainManager.RefleshScore();
        }
        private void OnGetUserScoreFailure(PlayFabError error){
            Debug.LogError($"スコアの取得に失敗しました\n{error.GenerateErrorReport()}");
        }

    

//=================================================================================
//ランキング

    [SerializeField]  private Text rank_a = default;
    [SerializeField]  private Text name_a = default;
    [SerializeField]  private Text score_a = default;

    [SerializeField]  private Text name_t = default;
    [SerializeField]  private Text score_t = default;

    public void GetLeaderboard() { 
        var request = new GetLeaderboardRequest{
            StatisticName   = "HighScore", //ランキング名(統計情報名)
            StartPosition   = 0,                 //何位以降のランキングを取得するか
            MaxResultsCount = 10                  //ランキングデータを何件取得するか(最大100)
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }
        private void OnGetLeaderboardSuccess(GetLeaderboardResult result){

            name_t.text = "";
            score_t.text = "";

            foreach (var entry in result.Leaderboard) {
            name_t.text += $"\n{entry.DisplayName}";
            score_t.text += $"\n{entry.StatValue}";
            }
        }
        private void OnGetLeaderboardFailure(PlayFabError error){
            Debug.LogError($"ランキング(リーダーボード)の取得に失敗しました\n{error.GenerateErrorReport()}");
        }


    public void GetLeaderboardAroundPlayer() { 
        var request = new GetLeaderboardAroundPlayerRequest{
            StatisticName   = "HighScore", //ランキング名(統計情報名)
            MaxResultsCount = 5  //自分を含め前後何件取得するか
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetLeaderboardAroundPlayerSuccess, OnGetLeaderboardAroundPlayerFailure);
    }
        private void OnGetLeaderboardAroundPlayerSuccess(GetLeaderboardAroundPlayerResult result){

            rank_a.text = "";
            name_a.text = "";
            score_a.text = "";

            foreach (var entry in result.Leaderboard) {
                rank_a.text += $"\n{entry.Position + 1}";
            }
            foreach (var entry in result.Leaderboard) {
                name_a.text += $"\n{entry.DisplayName}";
            }
            foreach (var entry in result.Leaderboard) {
                score_a.text += $"\n{entry.StatValue}";
            }
        }
        private void OnGetLeaderboardAroundPlayerFailure(PlayFabError error){
            Debug.LogError($"自分の順位周辺のランキングの取得に失敗しました\n{error.GenerateErrorReport()}");
        }

    public void GetUserRank() { //取得
        var request = new GetLeaderboardAroundPlayerRequest{StatisticName = "HighScore", MaxResultsCount = 1};
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetUserRankSuccess, OnGetUserRankFailure);
    }
        private void OnGetUserRankSuccess(GetLeaderboardAroundPlayerResult result){
            foreach (var entry in result.Leaderboard) {
                userRank = int.Parse($"{entry.Position}") + 1;
            }
            Debug.Log("Rank : " + userRank);
            mainManager.RefleshRank();
        }
        private void OnGetUserRankFailure(PlayFabError error){
            Debug.LogError($"ユーザー名の取得に失敗しました\n{error.GenerateErrorReport()}");
        }





//=================================================================================
    public void OpenInitNameUI(){
        initNameUI.SetActive(true);
    }

    public void ResetUnlockS(){
        PlayerPrefs.SetInt("UNLOCK_S", 1);
    }
    public void AllUnlockS(){
        PlayerPrefs.SetInt("UNLOCK_S", 10);
    }
    public void ResetUnlockP(){
        for(int i = 0; i < GameManager.howManyPlayersPlusOne; i++){
            PlayerPrefs.SetInt("UNLOCK_P" + $"{i}", 0);
        }
    }
    public void UnlockP4(){
        PlayerPrefs.SetInt("UNLOCK_P4",1);
    }

}
