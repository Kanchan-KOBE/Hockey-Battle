using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemies;

    public int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemySpawn(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemySpawn(int i)
    {
        Instantiate(Enemies[i], new Vector3(0f,1.0f,8f), transform.rotation);
    }
}
