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
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
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

    public void GameRetry(){
        SceneManager.LoadScene(2);
    }
    public void ToTitle(){
        SceneManager.LoadScene(0);
    }

    public void SpawnPack(){
        packManager.SpawnPack();
    }

   
    
}
