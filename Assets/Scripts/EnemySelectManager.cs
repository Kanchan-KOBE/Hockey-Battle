using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelectManager : MonoBehaviour
{
    [SerializeField] GameObject uI_Check;

    [SerializeField] GameObject uI_Locked;
    [SerializeField] Text msgLocked;
    [SerializeField] Text msgCheck;
   

    [SerializeField] Button btnToNext;
    [SerializeField] GameObject[] btnsLocked;
    [SerializeField] GameObject[] flames;


    
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("EM:"+EnemyManager.unlock_Stage + " PP:"+PlayerPrefs.GetInt("UNLOCK_S"));
        for(int i = 0; i < PlayerPrefs.GetInt("UNLOCK_S") + 1; i ++){
            btnsLocked[i].SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyManager.enemyNumber == 0){
            btnToNext.interactable = false;
        }else{
            btnToNext.interactable = true;
        }
    }

    public void GetEnemyNumber(int setEnemyNumber)
    {
        EnemyManager.enemyNumber = setEnemyNumber;
        Debug.Log("Stage : " + EnemyManager.enemyNumber);
        for(int i = 0; i < GameManager.howManyEnemysPlusOne; i++){
            flames[i].SetActive(false);
        }
        flames[setEnemyNumber].SetActive(true);
    }

    public void CheckUI(){
        msgCheck.text = $"Challenge Stage{EnemyManager.enemyNumber} ?";
        uI_Check.SetActive(true);
    }
    public void CheckUI_Delete(){
        uI_Check.SetActive(false);
    }

    public void OpenLocked( string message ){
        msgLocked.text = message;
        uI_Locked.SetActive(true);
    }
    public void CloseLocked(){
        uI_Locked.SetActive(false);
    }


    
}
