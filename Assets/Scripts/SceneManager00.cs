using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager00 : MonoBehaviour
{

    public int currentIndex;

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

    public void ToNextStage(){
        EnemyManager.enemyNumber += 1;
        SceneManager.LoadScene("Stage_AR");
    }
    public void ToBack(){
        currentIndex = SceneManager.GetActiveScene().buildIndex;
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
        SceneManager.LoadScene(1);
    }

    public void GetStage(int i){i = stage;}
    public void ToPlayerSelect(){
        SceneManager.LoadScene(2);
    }
    public void ToStageSelect(){
        if(stage == 0){
            SceneManager.LoadScene(3);
        }
    }
    public void ToAR(){
        if(stage == 0){
            SceneManager.LoadScene("Stage_AR");
        }
    }
}
