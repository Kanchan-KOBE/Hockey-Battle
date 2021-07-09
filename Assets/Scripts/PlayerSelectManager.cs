using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    [SerializeField] GameObject uI_Check;

    [SerializeField] GameObject uI_Locked;
    [SerializeField] Text msgLocked;

    [SerializeField] Button btnToNext;
    [SerializeField] GameObject[] btnsLocked;

    
    void Start()
    {
        Debug.Log("Stage : " + SceneManager00.stage);

        for(int i = 0; i < GameManager.howManyPlayersPlusOne; i++){
            if(PlayerPrefs.GetInt("UNLOCK_P" + $"{i}") == 1){
                btnsLocked[i].SetActive(false);
            }
        }



        LPManager.LifePlayer = 3;
        PlayerManager.playerNumber = 0;
        ARGameManager.newScore = 0;

    }

    void Update()
    {
        if(PlayerManager.playerNumber == 0){
            btnToNext.interactable = false;
        }else{
            btnToNext.interactable = true;
        }
    }

    public void GetPlayerNumber(int setPlayerNumber)
    {
        PlayerManager.playerNumber = setPlayerNumber;
        Debug.Log("Player : " + PlayerManager.playerNumber);
    }

    public void CheckUI(){
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
