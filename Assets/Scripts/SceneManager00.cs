using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager00 : MonoBehaviour
{

    public int currentIndex;
    public static int stage = 0;
    public static int sm = 0;
    public int i = 0;

    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        // for(int i = 0; i < GameManager.howManyEnemysPlusOne; i++)
        // {
        //     Debug.Log(GameManager.unlockS[i]);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake () {
		// DontDestroyOnLoad( gameObject );
    }


    //--------------------------------------------------------------------------------------
    public void ToSetting(){
        SceneManager.LoadScene("SettingScene");
    }
    public void ToTitle(){
        SceneManager.LoadScene("TitleScene");
    }
    public void ToMain(){
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ToPlayerSelect(){
        SceneManager.LoadScene("PlayerSelectScene");
    }

    public void ToNext(){
        if(PlayerManager.playerNumber == 0){
            Debug.Log("プレイヤーが選択されていません");
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(clips[0]);
        }else{
            if(stage == 0){
                SceneManager.LoadScene("StageSelectScene");
            }else if(stage == 1){
                SceneManager.LoadScene("Stage_SV");
            }
        }
    }

    public void ToAR(){
        SceneManager.LoadScene("Stage_AR");
    }
    public void ToNextStage(){
        if(EnemyManager.enemyNumber == GameManager.howManyEnemysPlusOne){
            Debug.Log("全クリ");
        }else{
            EnemyManager.enemyNumber += 1;
            SceneManager.LoadScene("Stage_AR");
        }
    }
    public void ToStageSelect(){
        SceneManager.LoadScene("StageSelectScene");
    }

    //stage(0=ARCADE,1=SURVIVAL)
    public void GetStage(int i){
        i = stage;
    }
}
