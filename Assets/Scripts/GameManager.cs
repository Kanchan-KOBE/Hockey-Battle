using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public LPManager lPManager;
    public PackManager packManager;
    public GameObject uI_WIN;
    public GameObject uI_LOSE;

    public GameObject uI_Goal;
    public GameObject playerObject;
    public GameObject enemyObject;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HogeGameStart");
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    //UI===================================================
    public void LoseUI(){
        Debug.Log("ゲームオーバーUI");
        uI_LOSE.SetActive(true);
    }

     public void WinUI(){
        Debug.Log("ゲームクリアUI");
        uI_WIN.SetActive(true);
    }

    public void GoalUI(){
        uI_Goal.SetActive(true);
    }
    public void GoalUI_Delete(){
        uI_Goal.SetActive(false);
    }


    //SCENE=============================================
    public void GameRetry(){
        SceneManager.LoadScene(2);
    }
    public void ToTitle(){
        SceneManager.LoadScene(0);
    }

    public void SpawnPack(){
        packManager.SpawnPack();
    }


    //===============================================
    private IEnumerator HogeGameStart()
    {
        Time.timeScale = 1.0f;
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Go!");
        Time.timeScale = 1.0f;
    }
    
}
