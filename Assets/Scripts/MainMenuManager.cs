using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] Text txtUserName;
    [SerializeField] Text txtUserScore;
    [SerializeField] Text txtUserRank;
    [SerializeField] GameObject uI_Ranking;




    // Start is called before the first frame update
    void Start()
    {
        RefleshUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefleshUserData(){
        RefleshName();
        RefleshScore();
        RefleshRank();
    }

    public void RefleshName(){
        txtUserName.text = GameManager.userName;
    }
    public void RefleshScore(){
        txtUserScore.text = GameManager.highScore.ToString();
    }
    public void RefleshRank(){
        txtUserRank.text = GameManager.userRank.ToString();
    }

    public void OpenRanking(){
        uI_Ranking.SetActive(true);
    }
    public void CloseRanking(){
        uI_Ranking.SetActive(false);
    }


}
