using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] Text[] txtUserName;
    [SerializeField] Text txtUserScore;
    [SerializeField] Text[] txtUserRank;
    [SerializeField] GameObject uI_Ranking;
    [SerializeField] GameObject uI_CheckSV;
    [SerializeField] GameObject sVLockButton;
    [SerializeField] GameObject uI_CheckReset;
    [SerializeField] SceneManager00 sceneManager00;

    public static bool signUP = false;




    // Start is called before the first frame update
    void Start()
    {
        RefleshUserData();
        Debug.Log(PlayerPrefs.GetInt("Unlock_SURVIVAL") );

        if(signUP){
            if(SceneManager00.stage == 0){
                sceneManager00.OpenUI_Main(3);
                sceneManager00.CloseUI_Main(0);
            }else{
                sceneManager00.OpenUI_Main(1);
                sceneManager00.CloseUI_Main(0);
            }
        }else{
            signUP = true;
        }

        if(PlayerPrefs.GetInt("Unlock_SURVIVAL") == 1){
            sVLockButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefleshUserData(){
        RefleshName();
        RefleshScore();
        RefleshRank();
    }

    public void RefleshName(){
        txtUserName[0].text = GameManager.userName;
        txtUserName[1].text = GameManager.userName;
    }
    public void RefleshScore(){
        txtUserScore.text = GameManager.highScore.ToString();
    }
    public void RefleshRank(){
        txtUserRank[0].text = GameManager.userRank.ToString();
        txtUserRank[1].text = GameManager.userRank.ToString();
    }

    public void OpenRanking(){
        uI_Ranking.SetActive(true);
    }
    public void CloseRanking(){
        uI_Ranking.SetActive(false);
    }

    public void LoadSV(){
        PlayerManager.playerNumber = PlayerPrefs.GetInt("PlayerSV");
        ARGameManager.newScore = PlayerPrefs.GetInt("ScoreSV");
        ARGameManager.winCounter = PlayerPrefs.GetInt("WinCounterSV");
        LPManager.LifePlayer = PlayerPrefs.GetInt("LifePSV");
        LPManager.LifeEnemy = PlayerPrefs.GetInt("LifeESV");
        Debug.Log("PlayerSV : " + PlayerPrefs.GetInt("PlayerSV"));

        if(PlayerPrefs.GetInt("PlayerSV") == 0){
            sceneManager00.OpenUI_Main(2);
            sceneManager00.CloseUI_Main(1);
            LPManager.LifePlayer = 3;
            ResetSV();
        }else{
            uI_CheckSV.SetActive(true);
        }
    }

    public void CloseCheckSV(){
        uI_CheckSV.SetActive(false);
    }
    public void OpenCheckReset(){
        uI_CheckReset.SetActive(true);
    }
    public void CloseCheckReset(){
        uI_CheckReset.SetActive(false);
    }

    public void ResetSV(){
        PlayerPrefs.SetInt("PlayerSV", 0);
        PlayerPrefs.SetInt("EnemySV", 0);
        PlayerPrefs.SetInt("ScoreSV", 0);
        PlayerPrefs.SetInt("WinCounterSV", 0);
    }




}
