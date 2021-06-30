using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    [SerializeField] GameObject uI_Check;

    [SerializeField] Button btnToNext;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Stage : " + SceneManager00.stage);
        LPManager.LifePlayer = 3;
        PlayerManager.playerNumber = 0;
        ARGameManager.newScore = 0;

        // for(int i = 0; i < GameManager.howManyPlayersPlusOne; i ++)
        // {
            
        // }

    }

    // Update is called once per frame
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
}
