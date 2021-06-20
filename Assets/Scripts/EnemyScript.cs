using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int number = 0;
    public GameObject enemyUI;
    [SerializeField] int speed = 10;
    [SerializeField] int width = 5;
    [SerializeField] GameObject pet;
    [SerializeField] bool lifeCharge = false;
    [SerializeField] bool lifeChargePlus = false;
    [SerializeField] bool pets = false;
    [SerializeField] bool zombie = false;

    private bool skill1 = true;
    private bool gameUI = true;

    private bool moveR = true;
    private bool moveL = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LPManager.zombieCheckE)
        {
            Zombie();
            LPManager.zombieCheckE = false;
        }


        if(ARGameManager.gameStep == 3) //スタート時UI表示
        {
            if(gameUI)
            {
                enemyUI.SetActive(true);
                Debug.Log("gameUI");

                gameUI = false;
            }
        }
        if(ARGameManager.gameStep == 4) //スタート時スキル発動
        {
            if(skill1)
            {
                SpawnPet();
                LifeCharge();
                LifeChargePlus();
                Debug.Log("skill1");

                skill1 = false;
            }
        }



        
        if(this.transform.position.x > width){ //移動-----
            moveR = false;
            moveL = true;
        }
        if(this.transform.position.x < width * -1){
            moveL = false;
            moveR = true;
        }

        if(moveR){
            this.transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
        }
        if(moveL){
            this.transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
        }
    }


//SKILLS===============================================================================
    void LifeCharge(){
        if(lifeCharge){
            if(LPManager.LifeEnemy < 5){
            LPManager.LifeEnemy += 1;
            }
        }

    }
    void LifeChargePlus(){
        if(lifeChargePlus){
            for(int i = 0; i < 2; i++){
                if(LPManager.LifeEnemy < 5){
                    LPManager.LifeEnemy += 1;
                }
            }
        }

    }
    void SpawnPet(){
        if(pets){
            Instantiate(pet,new Vector3(0f,1f,4f), transform.rotation);
        }
    }
    void Zombie(){
        if(zombie){
            int i = Random.Range(0,99);
            Debug.Log(i);
            if(i < 30){
                LPManager.LifeEnemy ++;
            }else{
                ARGameManager.isWin = true;
            }
        }else
        {
            ARGameManager.isWin = true;
        }
    }

//SOUND===============================================================================
    //  void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.tag == "Pack"){
    //         GetComponent<AudioSource>().PlayOneShot(roar[0],1.0f);
    //     }else if(collision.gameObject.tag == "MyGoal"){
            
    //     }
    // }

}
