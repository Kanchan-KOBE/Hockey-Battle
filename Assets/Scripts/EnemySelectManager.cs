using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelectManager : MonoBehaviour
{
    public GameObject uI_Check;
    public Sprite[] imgEnemys;
    public Image[] imgBtn;

    public Button[] btn = new Button[GameManager.howManyEnemysPlusOne];


    // public Button[] btnEnemys;
    
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < GameManager.howManyEnemysPlusOne; i++){ //アンロックされているキャラのボタンの表示を変更
            if(GameManager.unlockP[i]){
                btn[i].interactable = true;
                // imgBtn[i].sprite = imgEnemys[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void GetEnemyNumber(int setEnemyNumber)
    {
        EnemyManager.enemyNumber = setEnemyNumber;
        Debug.Log(setEnemyNumber);
    }

    public void CheckUI(){
        uI_Check.SetActive(true);
    }
    public void CheckUI_Delete(){
        uI_Check.SetActive(false);
    }
}
