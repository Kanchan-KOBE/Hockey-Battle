using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    public GameObject uI_Check;

    public Button btnSelect;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Stage : " + SceneManager00.stage);
        LPManager.LifePlayer = 3;
        PlayerManager.playerNumber = 0;
        ARGameManager.newScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
