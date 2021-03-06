using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LPManager : MonoBehaviour
{
    // public PackFactory packFactory;
    public ARGameManager myManager;
    public PackManager packManager;
    public static int LifePlayer = 3;
    public static int LifeEnemy = 3;

    public static bool zombieCheckE = false;
    public static bool zombieCheckP = false;

    public Image[] hartsP;
    public Image[] hartsE;
    public Sprite hart;
    public Sprite noImage;
    [SerializeField] GameObject heartP;
    [SerializeField] GameObject heartE;

  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHarts();
        EnemyHarts();

    }

    public void LPReset(){ 
        if(SceneManager00.stage == 0){
            LifePlayer = 3;
            LifeEnemy = 3;
        }else if(SceneManager00.stage == 1){
            LifeEnemy = 3;
        }

        heartP.SetActive(true);
        heartE.SetActive(true);

    }


    public void MLP_Cure() //MyLP Cure++
    {
        LifePlayer += 1;
    }

    public void ELP_Cure() //LifeEnemy Cure++
    {
        LifeEnemy += 1;
    }

    public void MLP_Lose() //LifePlayer lose--
    {
        LifePlayer -= 1;
        if(LifePlayer == 0){
            zombieCheckP = true;
            StartCoroutine("HogeZombieP");
        }else{
            Debug.Log(LifePlayer + "-" + LifeEnemy);
            StartCoroutine("HogeGoal");
        }
    }
  
    public void ELP_Lose() //LifeEnemy lose--
    {
        LifeEnemy -= 1;
        if(LifeEnemy == 0){
            zombieCheckE = true;
            StartCoroutine("HogeZombieE");
        }else{
            Debug.Log(LifePlayer + "-" + LifeEnemy);
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

    private IEnumerator HogeZombieP()
    {
        yield return new WaitForSeconds(1.0f);
        if(ARGameManager.isWin){
        }else if(ARGameManager.isLose){
        }else{
            Debug.Log("zombieP");
            PlayerScript.cutInP = true;
            yield return new WaitForSeconds(2.0f);
            PlayerScript.cutInP = false;
            yield return new WaitForSeconds(1.0f);
            packManager.SpawnPack();
        }
    }
    private IEnumerator HogeZombieE()
    {
        yield return new WaitForSeconds(1.0f);
        if(ARGameManager.isWin){
        }else if(ARGameManager.isLose){
        }else{
            Debug.Log("zombieP");
            EnemyScript.cutInE = true;
            yield return new WaitForSeconds(2.0f);
            EnemyScript.cutInE = false;
            yield return new WaitForSeconds(1.0f);
            packManager.SpawnPack();
        }
    }

    private void PlayerHarts()
    {
        if(LifePlayer == 0)
        {
            hartsP[0].sprite = noImage;
            hartsP[1].sprite = noImage;
            hartsP[2].sprite = noImage;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(LifePlayer == 1)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = noImage;
            hartsP[2].sprite = noImage;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(LifePlayer == 2)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = noImage;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(LifePlayer == 3)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = hart;
            hartsP[3].sprite = noImage;
            hartsP[4].sprite = noImage;
        }
        if(LifePlayer == 4)
        {
            hartsP[0].sprite = hart;
            hartsP[1].sprite = hart;
            hartsP[2].sprite = hart;
            hartsP[3].sprite = hart;
            hartsP[4].sprite = noImage;
        }
        if(LifePlayer == 5)
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
        if(LifeEnemy == 0)
        {
            hartsE[0].sprite = noImage;
            hartsE[1].sprite = noImage;
            hartsE[2].sprite = noImage;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(LifeEnemy == 1)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = noImage;
            hartsE[2].sprite = noImage;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(LifeEnemy == 2)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = noImage;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(LifeEnemy == 3)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = hart;
            hartsE[3].sprite = noImage;
            hartsE[4].sprite = noImage;
        }
        if(LifeEnemy == 4)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = hart;
            hartsE[3].sprite = hart;
            hartsE[4].sprite = noImage;
        }
        if(LifeEnemy == 5)
        {
            hartsE[0].sprite = hart;
            hartsE[1].sprite = hart;
            hartsE[2].sprite = hart;
            hartsE[3].sprite = hart;
            hartsE[4].sprite = hart;
        }
    }

}
