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
    public SceneManager00 sceneManager;
    public GameObject mainCamera;
    public GameObject uI_Main;
    public GameObject uI_WIN;
    public GameObject uI_LOSE;
    public GameObject uI_Result;
    public GameObject uI_NewRecord;
    public GameObject uI_Goal;
    public GameObject uI_Pause;

    [SerializeField] Text textCount;
    [SerializeField] Text txtPlusScore;
    [SerializeField] Text[] txtNewScore;
    public AudioClip[] clips;

    private bool u = true; //スコア計算スイッチ

    void Awake()
    {
        gameStep = 0;
        isWin = false;
        isLose = false;
        PackScript.poisonTime = false;
        

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
                        myManager.SubmitScore(GameManager.highScore);
                        u = false;
                    }else{
                        txtNewScore[2].text = newScore.ToString();
                        myManager.SubmitScore(GameManager.highScore);
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

     public void WinUI(){ //勝利時の処理
        if(SceneManager00.stage == 1){ 
            if(isWin){
                if(u){ //スコア計算
                    winCounter ++;
                    plusScore = (level * 100 + LPManager.LifePlayer * 100) * scoreMag * winCounter;
                    newScore = newScore + plusScore;
                    txtPlusScore.text = plusScore.ToString();
                    txtNewScore[0].text = newScore.ToString();
                    u = false;
                }
            }
            
        }else if(SceneManager00.stage == 0){ 
            int i = GameManager.howManyEnemysPlusOne - 1;
            if(EnemyManager.enemyNumber == i){
                //全クリUI
            }else{
                //ステージアンロック
            }
        }

        EnemyScript.cutInE = false;
        uI_WIN.SetActive(true);
    }

    public void GoalUI(){
        uI_Goal.SetActive(true);
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
        yield return new WaitForSeconds(2.5f);
        //false
        gameStep ++; //3

        //step3(MainUI表示、LP=3)（０.5秒）
        uI_Main.SetActive(true);
        lPManager.LPReset();
        yield return new WaitForSeconds(0.5f);
        gameStep ++; //4

        //step4(Pack生成)(スキル発動)
        packManager.SpawnPack();
        yield return new WaitForSeconds(0.5f);
        gameStep ++;//5

        //step5（カウントダウン）
        GetComponent<AudioSource>().PlayOneShot(clips[0]);
        textCount.text = "3";
        yield return new WaitForSeconds(1f);
        textCount.text = "2";
        yield return new WaitForSeconds(1f);
        textCount.text = "1";
        yield return new WaitForSeconds(1f);
        textCount.text = "Go!";
        yield return new WaitForSeconds(1f);
        textCount.text = "";


        gameStep ++;//6
    }
}
