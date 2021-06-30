using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;

    public static int enemyNumber = 0;
    public static int unlock_Stage = 2;
    public int setEnemyNumber;



    void Awake(){
        UpdateUnlockS();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetEnemyNumber(int setEnemyNumber){enemyNumber = setEnemyNumber;}
    public void enemySpawn(int enemyNumber)
    {
        Instantiate(Enemies[enemyNumber], new Vector3(0f,1.0f,7.5f), transform.rotation);
    }

    public void UpdateUnlockS(){
        int saved = PlayerPrefs.GetInt("UNLOCK_S");
        if(saved < unlock_Stage){
            PlayerPrefs.SetInt("UNLOCK_S",unlock_Stage);
        }
    }
}
