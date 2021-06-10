using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;

    public static int enemyNumber = 1;
    public int i = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemySpawn(int enemyNumber)
    {
        Instantiate(Enemies[enemyNumber], new Vector3(0f,1.0f,8f), transform.rotation);
    }

    public void GetEnemyNumber(int i){enemyNumber = i;}

}
