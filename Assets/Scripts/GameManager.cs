using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LPManager lPManager;
    public PackManager packManager;
    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    public SceneManager00 sceneManager;
    public GameObject uI_WIN;
    public GameObject uI_LOSE;
    public GameObject uI_Goal;
    public GameObject uI_Pause;

    public Text textCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HogeGameStart");
        packManager.SpawnPack();
        enemyManager.enemySpawn(EnemyManager.enemyNumber);
        playerManager.playerSpawn(PlayerManager.playerNumber);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    //UI===================================================
    public void LoseUI(){
        uI_LOSE.SetActive(true);
    }

     public void WinUI(){
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


    //SCENE=============================================


    //===============================================

        private IEnumerator HogeGameStart()
    {
        Time.timeScale = 0.01f;
        textCount.text = "3";
        yield return new WaitForSeconds(0.01f);
        textCount.text = "2";
        yield return new WaitForSeconds(0.01f);
        textCount.text = "1";
        yield return new WaitForSeconds(0.01f);
        textCount.text = "Go!";
        yield return new WaitForSeconds(0.01f);
        textCount.text = "";
        Time.timeScale = 1.0f;
    }

}
