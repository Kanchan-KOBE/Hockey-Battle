using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int howManyPlayersPlusOne = 3;
    public bool[] unlockPtest = new bool[howManyPlayersPlusOne];
    public static bool[] unlockP = new bool[howManyPlayersPlusOne];


    public static int howManyStagesPlusOne = 3;
    public bool[] unlockStest = new bool[howManyStagesPlusOne];
    public static bool[] unlockS = new bool[howManyStagesPlusOne];

    public int numberPlayer = 0;
    public int numberEnemy = 0;


    // Start is called before the first frame update
    void Start()
    {

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        numberEnemy = EnemyManager.enemyNumber;
        numberPlayer = PlayerManager.playerNumber;
        unlockP = unlockPtest;
        unlockS = unlockStest;
        unlockP[0] = true;
    }

}
