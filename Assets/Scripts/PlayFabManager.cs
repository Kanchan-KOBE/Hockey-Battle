using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayFabManager : MonoBehaviour
{

    private bool _shouldCreateAccount = true;
    private string _customUserID;
    void Start()
    {
        if(_shouldCreateAccount){
            Login();
        }

    }


      void Update()
    {
        
    }

    //=========================================================================
    //Login
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
            }
            Debug.Log($"PlayFabのログインに成功\nPlayFabId : {result.PlayFabId}, CustomId : {_customUserID}\nアカウントを作成したか : {result.NewlyCreated}");
        }
        private void OnLoginFailure(PlayFabError error)
        {
            Debug.LogError($"PlayFabのログインに失敗\n{error.GenerateErrorReport()}");
        }

    private static readonly string CUSTOM_ID_SAVE_KEY = "CUSTOM_U_ID_SAVE_KEY";    //IDを保存する時のKEY
    
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



















    void SubmitScore(int playerScore)
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

    void RequestLeaderBoard()
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
}
