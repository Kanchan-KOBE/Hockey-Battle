using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LPManager : MonoBehaviour
{
    // public PackFactory packFactory;
    public GameManager myManager;
    public PackManager packManager;
    public byte myLP = 3; //自分のLP
    public byte enemyLP = 3; //敵のLP

    public Image[] hartsP;
    public Image[] hartsE;
    public Sprite hart;
    public Sprite noImage;

    // Start is called before the first frame update
    void Start()
    {
        // hartsP[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHarts();
        EnemyHarts();

    }


    public void MLP_Cure() //MyLP Cure++
    {
        myLP += 1;
    }

    public void ELP_Cure() //EnemyLP Cure++
    {
        enemyLP += 1;
    }

    public void MLP_Lose() //MyLP lose--
    {
        myLP -= 1;
        if(myLP == 0){
            Debug.Log("You Lose..");
            myManager.LoseUI();
        }else{
            Debug.Log(myLP + "-" + enemyLP);
            StartCoroutine("HogeGoal");
        }
    }
  
    public void ELP_Lose() //EnemyLP lose--
    {
        enemyLP -= 1;
        if(enemyLP == 0){
            Debug.Log("You WIN!");
            myManager.WinUI();
        }else{
            Debug.Log(myLP + "-" + enemyLP);
            StartCoroutine("HogeGoal");
        }
    }


    private IEnumerator HogeGoal()
    {
        myManager.GoalUI();
        yield return new WaitForSeconds(2.0f);
        myManager.GoalUI_Delete();
        packManager.SpawnPack();
    }

    private void PlayerHarts()
    {
        if(myLP == 0)
        {
            hartsP[0].sprite = noImage;
            hartsP[1].sprite = noImage;
            hartsP[2].sprite = noImage;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(myLP == 1)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = noImage;
            hartsP[2].sprite = noImage;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(myLP == 2)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = noImage;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(myLP == 3)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = hart;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(myLP == 4)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = hart;
            hartsP[3].sprite = hart;
            hartsP[4].sprite = noImage;
        }
        if(myLP == 5)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = hart;
            hartsP[3].sprite = hart;
            hartsP[4].sprite = hart;
        }
    }
    private void EnemyHarts()
    {
        if(enemyLP == 0)
        {
            hartsE[0].sprite = noImage;
            hartsE[1].sprite = noImage;
            hartsE[2].sprite = noImage;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(enemyLP == 1)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = noImage;
            hartsE[2].sprite = noImage;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(enemyLP == 2)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = noImage;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(enemyLP == 3)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = hart;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(enemyLP == 4)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = hart;
            hartsE[3].sprite = hart;
            hartsE[4].sprite = noImage;
        }
        if(enemyLP == 5)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = hart;
            hartsE[3].sprite = hart;
            hartsE[4].sprite = hart;
        }
    }
}
