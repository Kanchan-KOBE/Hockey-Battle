using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelectManager : MonoBehaviour
{
    public GameObject uI_Check;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetEnemyNumber(int setEnemyNumber)
    {
        EnemyManager.enemyNumber = setEnemyNumber;
        Debug.Log("Stage : " + EnemyManager.enemyNumber);
    }

    public void CheckUI(){
        uI_Check.SetActive(true);
    }
    public void CheckUI_Delete(){
        uI_Check.SetActive(false);
    }
}
