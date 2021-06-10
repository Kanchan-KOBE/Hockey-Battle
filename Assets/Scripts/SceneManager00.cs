using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager00 : MonoBehaviour
{

    public int currentIndex;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void ToNextScene(){
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
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
    public void ToStageSelect(){
        SceneManager.LoadScene(4);
    }
    public void ToAR(int level){
        SceneManager.LoadScene(level + 4);
    }
}
