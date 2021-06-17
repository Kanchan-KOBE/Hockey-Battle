using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager00 : MonoBehaviour
{

    public int currentIndex;
    public AudioClip[] clips;
    public static int stage = 0;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        DontDestroyOnLoad(this);
    }

    public void ToNextStage(){
        EnemyManager.enemyNumber += 1;
        SceneManager.LoadScene("Stage_AR");
    }

    public void ToBack(){
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        // AudioSource audio = GetComponent<AudioSource>();
        // audio.PlayOneShot(clips[0]);
        SceneManager.LoadScene(currentIndex - 1);
    }

    public void GameRetry(){
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void ToTitle(){
        SceneManager.LoadScene(0);
    }

    public void ToMain(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[3]);
        // FadeManager.FadeOut(1);
        SceneManager.LoadScene(1);
    }

    public void GetStage(int i){
        i = stage;
        // AudioSource audio = GetComponent<AudioSource>();
        // audio.PlayOneShot(clips[4]);
    }
    public void ToPlayerSelect(){
        // AudioSource audio = GetComponent<AudioSource>();
        // audio.PlayOneShot(clips[2]);
        SceneManager.LoadScene(2);
    }
    public void ToStageSelect(){
        if(stage == 0){
            SceneManager.LoadScene(3);
        }
    }
    public void ToAR(){
        if(PlayerManager.playerNumber == 0){
            Debug.Log("プレイヤーが選択されていません");
            // AudioSource audio = GetComponent<AudioSource>();
            // audio.PlayOneShot(clips[0]);
        }else{
            // AudioSource audio = GetComponent<AudioSource>();
            // audio.PlayOneShot(clips[2]);
            SceneManager.LoadScene("Stage_AR");
        }
    }
}
