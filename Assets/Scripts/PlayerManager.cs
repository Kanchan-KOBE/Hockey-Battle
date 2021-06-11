using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

   public GameObject[] Players;

   public static int playerNumber = 0;

   public int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayerNumber(int i){playerNumber = i;}

    public void playerSpawn(int playerNumber)
    {
        Instantiate(Players[playerNumber], new Vector3(0f,1.0f,-8f), transform.rotation);
    }

}
