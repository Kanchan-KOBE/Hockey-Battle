using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    public Image imgStatus;
    // public Image imgCheck;
    public GameObject uI_Check;
    public Text namePlayer;
    public Sprite[] imgPlayers;
    public Image[] imgBtn;

    public Button[] btn = new Button[GameManager.howManyPlayersPlusOne];


    // public Button[] btnPlayers;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GameManager.howManyPlayersPlusOne; i++){
            if(GameManager.unlockP[i]){
                btn[i].interactable = true;
                imgBtn[i].sprite = imgPlayers[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void GetPlayerNumber(int setPlayerNumber)
    {
        PlayerManager.playerNumber = setPlayerNumber;
        imgStatus.sprite = imgPlayers[PlayerManager.playerNumber];
        Debug.Log(setPlayerNumber);
    }
    public void GetPlayerName(string playerName)
    {
        namePlayer.text = playerName;
    }

    public void CheckUI(){
        uI_Check.SetActive(true);
    }
    public void CheckUI_Delete(){
        uI_Check.SetActive(false);
    }
}
