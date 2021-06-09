using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;------------------!


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

    public static int enemyNumber = 0;
    public static int playerNumber = 0;

    // public int currentIndex;

    // public Text textCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HogeGameStart");
        packManager.SpawnPack();
        enemyManager.enemySpawn(enemyNumber);
        playerManager.playerSpawn(playerNumber);
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


    //SCENE=============================================
    // public void ToNextScene(){
    //     currentIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentIndex + 1);
    // }
    // public void ToBack(){
    //     currentIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentIndex + 1);
    // }
    // public void GameRetry(){
    //     currentIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentIndex + 1);
    // }
    // public void ToTitle(){
    //     SceneManager.LoadScene(0);
    // }
    // public void ToMainMenu(){
    //     SceneManager.LoadScene(1);
    // }




    //===============================================

        private IEnumerator HogeGameStart()
    {
        Time.timeScale = 0.01f;
        Debug.Log("3");
        // countText.text = "3";
        yield return new WaitForSeconds(0.01f);
        Debug.Log("2");
        yield return new WaitForSeconds(0.01f);
        Debug.Log("1");
        yield return new WaitForSeconds(0.01f);
        Debug.Log("Go!");
        Time.timeScale = 1.0f;
    }

}
