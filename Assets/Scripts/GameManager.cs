using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int highScore = 0;


    public static int howManyPlayersPlusOne = 3;
    public static int howManyEnemysPlusOne = 3;

    public static bool[] unlockP = new bool[howManyPlayersPlusOne];

    public static int howManyStagesPlusOne = 3;
    public static bool[] unlockS = new bool[howManyStagesPlusOne];

    public int numberPlayer = 0;
    public int numberEnemy = 0;



    void Start()
    {
         
    }
   


    void Update()
    {
        
    }

    void Awake(){
        numberEnemy = EnemyManager.enemyNumber;
        numberPlayer = PlayerManager.playerNumber;
        // unlockP = unlockPtest;
        // unlockS = unlockStest;
        unlockP[0] = true;
        unlockP[1] = true;
        unlockS[0] = true;
        unlockS[1] = true;
        

    }

}
