using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGameManager : MonoBehaviour
{
    public static bool isWin = false;
    public static bool isLose = false;

    public static int gameStep = 0;
    public static int winCounter = 0;


    private int plusScore = 0;
    public static int newScore = 0;
    public static int scoreMag = 2;


    private int level;

    public GameManager myManager;
    public LPManager lPManager;
    public PackManager packManager;
    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    [SerializeField] SE_Manager sE_Manager;
    public GameObject mainCamera;
    public GameObject uI_Main;
    public GameObject uI_Button;
    public GameObject uI_WIN;
    public GameObject uI_Complete;
    public GameObject uI_LOSE;
    public GameObject uI_Result;
    public GameObject uI_NewRecord;
    public GameObject uI_Goal;
    public GameObject uI_Pause;
    [SerializeField] GameObject uI_CheckSave;
    [SerializeField] GameObject uI_CheckExit;
    [SerializeField] GameObject[] uI_CountDown;


    [SerializeField] Text txtPlusScore;
    [SerializeField] Text[] txtNewScore;

    private bool u = true; //スコア計算スイッチ
    private bool plus = true; //スコア計算スイッチ

    void Awake()
    {
        gameStep = 0;
        isWin = false;
        isLose = false;
        PackScript.poisonTime = false;
        plus = true;

        int i = EnemyManager.enemyNumber - PlayerManager.playerNumber;
        if(i > 0){
            level = i;
        }else{
            level = 0;
        }
        scoreMag = 2;
    }


    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        StartCoroutine("HogeGameStart");
        Debug.Log($"Score: {newScore}\nWins: {winCounter}");
    }
   

    // Update is called once per frame
    void Update()
    {
        if(gameStep == 1){
        CameraTilt();
        }

        if(isWin){
            WinUI();
        }
        if(isLose){
            LoseUI();
        }
        
    }

    //UI===================================================
    public void LoseUI(){ //敗北時の処理
        PlayerScript.cutInP = false;
        if(SceneManager00.stage == 1){
            if(isLose){
                if(u){
                    Debug.Log("High" + GameManager.highScore + " New" + newScore);
                    if(GameManager.highScore < newScore){
                        GameManager.highScore = newScore;
                        txtNewScore[1].text = newScore.ToString();
                        uI_NewRecord.SetActive(true);
                        myManager.SubmitScore();
                        ResetSV();
                        u = false;
                        
                    }else{
                        txtNewScore[2].text = newScore.ToString();
                        uI_Result.SetActive(true);
                        u = false;
                    }
                }
            }
        }else{
            uI_LOSE.SetActive(true);
            
            
        }
        PlayerScript.cutInP = false;
        winCounter = 0;
        newScore = 0;
    }

     public void WinUI(){//勝利時の処理
        if(SceneManager00.stage == 1){ 
            if(isWin){
                if(u){ //スコア計算
                    winCounter ++;
                    plusScore = (level * 100 + LPManager.LifePlayer * 100) * scoreMag * winCounter;
                    newScore = newScore + plusScore;

                    txtPlusScore.text = "+ " + plusScore.ToString();
                    txtNewScore[0].text = newScore.ToString();

                    SaveSV();
                    uI_WIN.SetActive(true);
                    u = false;
                }
            }
            
        }else if(SceneManager00.stage == 0){ 
            if(isWin){
                int i = GameManager.howManyEnemysPlusOne - 1;
                if(EnemyManager.enemyNumber == i){
                    if(plus){//全クリUI
                        uI_Complete.SetActive(true);
                        plus = false;
                    }
                }else{
                    uI_WIN.SetActive(true);
                    if(plus){//ステージアンロック
                        EnemyManager.unlock_Stage = EnemyManager.enemyNumber + 1;
                        plus = false;
                    }
                }
            }
        }

        EnemyScript.cutInE = false;
    }

    public void TextChange(){
        txtNewScore[3].text = newScore.ToString();
    }
    public void GoalUI(){
        uI_Goal.SetActive(true);
        PackScript.poisonTime = false;
    }
    public void CompleteUI(){
        uI_Complete.SetActive(true);
    }
    public void GoalUI_Delete(){
        uI_Goal.SetActive(false);

    }
    public void PauseUI(){
        Time.timeScale = 0f;
        uI_Pause.SetActive(true);
    }
    public void PauseUI_Delete(){
        uI_Pause.SetActive(false);
        Time.timeScale = 1f;
    }

//================================================================
//SVセーブ
    public void SaveSV(){
        PlayerPrefs.SetInt("PlayerSV", PlayerManager.playerNumber);
        PlayerPrefs.SetInt("ScoreSV", newScore);
        PlayerPrefs.SetInt("WinCounterSV", winCounter);
        PlayerPrefs.SetInt("LifePSV", LPManager.LifePlayer);
        PlayerPrefs.SetInt("LifeESV", LPManager.LifeEnemy);
    }
    public void ResetSV(){
        PlayerPrefs.SetInt("PlayerSV", 0);
        PlayerPrefs.SetInt("ScoreSV", 0);
        PlayerPrefs.SetInt("WinCounterSV", 0);
        PlayerPrefs.SetInt("LifePSV", 0);
        PlayerPrefs.SetInt("LifeESV", 0);
    }

    public void OpenCheckSave(){
        uI_CheckSave.SetActive(true);
    }
    public void CloseCheckSave(){
        uI_CheckSave.SetActive(false);
    }
    public void OpenCheckExit(){
        uI_CheckExit.SetActive(true);
    }
    public void CloseCheckExit(){
        uI_CheckExit.SetActive(false);
    }


    //CAMERA=============================================
    void CameraTilt(){
        if(mainCamera.transform.localEulerAngles.x < 60){
            mainCamera.transform.Rotate(new Vector3(10,0,0) * Time.deltaTime * 1000, Space.World);
        }
    }


    //===============================================

    private IEnumerator HogeGameStart()
    {
        //step0（E,P生成）（LP＝３）
        Time.timeScale = 0.001f;
        enemyManager.enemySpawn(EnemyManager.enemyNumber);
        playerManager.playerSpawn(PlayerManager.playerNumber);
        yield return new WaitForSeconds(0.0005f);
        gameStep ++; //1

        //step1(カメラ移動2.5秒)
        yield return new WaitForSeconds(0.004f);
        gameStep ++; //2

        //step2（カットイン３秒）
        Time.timeScale = 1.0f;
        //true
        yield return new WaitForSeconds(2f);
        //false
        gameStep ++; //3

        //step3(MainUI表示、LP=3)（０.5秒）
        uI_Main.SetActive(true);
        uI_Button.SetActive(true);
        lPManager.LPReset();
        yield return new WaitForSeconds(0.5f);
        gameStep ++; //4

        //step4(Pack生成)(スキル発動)
        packManager.SpawnPack();
        yield return new WaitForSeconds(0.5f);
        gameStep ++;//5

        //step5（カウントダウン）
        
        uI_CountDown[0].SetActive(true);
        sE_Manager.SE(5);
        yield return new WaitForSeconds(1f);
        uI_CountDown[0].SetActive(false);
        uI_CountDown[1].SetActive(true);
        sE_Manager.SE(5);
        yield return new WaitForSeconds(1f);
        uI_CountDown[1].SetActive(false);
        uI_CountDown[2].SetActive(true);
        sE_Manager.SE(5);
        yield return new WaitForSeconds(1f);
        uI_CountDown[2].SetActive(false);
        uI_CountDown[3].SetActive(true);
        sE_Manager.SE(6);
        yield return new WaitForSeconds(1f);
        uI_CountDown[3].SetActive(false);


        gameStep ++;//6
    }
}
