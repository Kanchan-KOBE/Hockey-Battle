using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    [SerializeField] GameObject uI_Check;
    [SerializeField] Image img_player;
    [SerializeField] Text txt_player;

    [SerializeField] GameObject uI_Locked;
    [SerializeField] Text msgLocked;

    [SerializeField] Button btnToNext;
    [SerializeField] GameObject[] btnsLocked;
    [SerializeField] GameObject[] flames;
    [SerializeField] GameObject btn_Ad;
    [SerializeField] Sprite[] icons_player;
    [SerializeField] Text[] names_player;

    
    void Start()
    {

        Reflesh_UnlockP();
        LPManager.LifePlayer = 3;
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
        for(int i = 0; i < GameManager.howManyPlayersPlusOne; i++){
            flames[i].SetActive(false);
        }
        flames[setPlayerNumber].SetActive(true);
    }

    public void CheckUI(){
        uI_Check.SetActive(true);
        img_player.sprite = icons_player[PlayerManager.playerNumber];
        txt_player.text = names_player[PlayerManager.playerNumber].text;
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
    public void UnlockP_All(){
        for(int i = 0; i < GameManager.howManyPlayersPlusOne; i++){
            PlayerPrefs.SetInt("UNLOCK_P" + $"{i}",1);
        }
    }
    public void Reflesh_UnlockP(){
        for(int i = 0; i < GameManager.howManyPlayersPlusOne; i++){
            if(PlayerPrefs.GetInt("UNLOCK_P" + $"{i}") == 1){
                btnsLocked[i].SetActive(false);
            }
        }
    }

    public void Btn_Ad_Set(){
        btn_Ad.SetActive(true);
    }
    public void Btn_Ad_Close(){
        btn_Ad.SetActive(false);
    }

    public void UnlockP7(){
        PlayerPrefs.SetInt("UNLOCK_P7",1);
    }
}
