using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPManager : MonoBehaviour
{
    // public PackFactory packFactory;
    public GameManager myManager;
    public byte myLP = 3; //自分のLP
    public byte enemyLP = 3; //敵のLP

    private IEnumerator HogeGoal()
    {

        yield return new WaitForSeconds(2.0f);
        myManager.SpawnPack();
    }


    // Start is called before the first frame update
    void Start()
    {
        // packFactory = GameObject.Find("PackFactory").GetComponent<PackFactoryScript>();
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
            // myManager.SpawnPack();
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
            // myManager.SpawnPack();
        }
    }
}
