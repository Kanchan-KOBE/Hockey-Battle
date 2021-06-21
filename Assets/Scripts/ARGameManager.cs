using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGameManager : MonoBehaviour
{
    public static bool isWin = false;
    public static bool isLose = false;
    public static int gameStep = 0;
    public LPManager lPManager;
    public PackManager packManager;
    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    public SceneManager00 sceneManager;
    public GameObject mainCamera;
    public GameObject uI_Main;
    public GameObject uI_WIN;
    public GameObject uI_LOSE;
    public GameObject uI_Goal;
    public GameObject uI_Pause;

    public Text textCount;
    public AudioClip[] clips;

    void Awake()
    {
        GameManager.unlockS[EnemyManager.enemyNumber] = true;
        gameStep = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        isLose = false;
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
    public void LoseUI(){
        PlayerScript.cutInP = false;
        uI_LOSE.SetActive(true);
    }

     public void WinUI(){
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
        if(mainCamera.transform.localEulerAngles.x < 61){
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
