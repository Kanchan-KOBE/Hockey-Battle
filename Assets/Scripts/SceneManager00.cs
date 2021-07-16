using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager00 : MonoBehaviour
{

    public ARGameManager aRGameManager;
    public static int stage ;

    [SerializeField] GameObject[] uIs_Main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake () {

    }


    //--------------------------------------------------------------------------------------
    public void OpenUI_Main(int _UINumber){
        uIs_Main[_UINumber].SetActive(true);
    }
    public void CloseUI_Main(int _UINumber){
        uIs_Main[_UINumber].SetActive(false);
    }


    public void ToMain(){
        SceneManager.LoadScene("TitleScene");
    }
    
    public void ToNext(){
        if(PlayerManager.playerNumber == 0){
            Debug.Log("プレイヤーが選択されていません");
        }else{
            if(stage == 0){
                uIs_Main[3].SetActive(true);
            }else if(stage == 1){
                ToSV();
            }
        }
    }

    public void ToAR(){
        SceneManager.LoadScene("Stage_AR");
    }
    public void ToNextStage(){
        int i = GameManager.howManyEnemysPlusOne - 1;
        if(EnemyManager.enemyNumber == i){
            Debug.Log("全クリ");
            aRGameManager.CompleteUI();
        }else{
            EnemyManager.enemyNumber += 1;
            SceneManager.LoadScene("Stage_AR");
        }
    }


    public void ToSV(){
        // EnemyManager.enemyNumber = Random.Range(0,GameManager.howManyEnemysPlusOne - 1);
        EnemyManager.enemyNumber = 10;
        SceneManager.LoadScene("Stage_SV");
    }



    public void GetStage(int i){    //stage(0=ARCADE,1=SURVIVAL)
        stage = i;
    }
}
