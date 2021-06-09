using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPManager : MonoBehaviour
{
    // public PackFactory packFactory;
    public GameManager myManager;

    public PackManager packManager;
    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    public byte myLP = 3; //自分のLP
    public byte enemyLP = 3; //敵のLP


    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine("HogeGameStart");
        // packManager.SpawnPack();
        // enemyManager.enemySpawn(enemyNumber);
        // playerManager.playerSpawn(playerNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MLP_Cure() //MyLP Cure++
    {
        myLP += 1;
    }

    public void ELP_Cure() //EnemyLP Cure++
    {
        enemyLP += 1;
    }

    public void MLP_Lose() //MyLP lose--
    {
        myLP -= 1;
        if(myLP == 0){
            Debug.Log("You Lose..");
            myManager.LoseUI();
        }else{
            Debug.Log(myLP + "-" + enemyLP);
            StartCoroutine("HogeGoal");
        }
    }
  
    public void ELP_Lose() //EnemyLP lose--
    {
        enemyLP -= 1;
        if(enemyLP == 0){
            Debug.Log("You WIN!");
            myManager.WinUI();
        }else{
            Debug.Log(myLP + "-" + enemyLP);
            StartCoroutine("HogeGoal");
        }
    }


    private IEnumerator HogeGoal()
    {
        myManager.GoalUI();
        yield return new WaitForSeconds(2.0f);
        myManager.GoalUI_Delete();
        packManager.SpawnPack();
    }
}
