using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int number = 0;
    // [SerializeField] string thisEnemyName = "NoName";
    [SerializeField] int speed = 10;
    [SerializeField] Sprite icon;
    [SerializeField] GameObject pet;
    [SerializeField] bool lifeCharge = false;
    [SerializeField] bool pets = false;
    [SerializeField] bool zombie = false;

    private bool skill1 = true;

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

        if(ARGameManager.gameStep == 4)
        {
            if(skill1)
            {
                SpawnPet();
                LifeCharge();
                Debug.Log("skill1");

                skill1 = false;
            }
        }

        if(this.transform.position.x > 5.5){
            moveR = false;
            moveL = true;
        }
        if(this.transform.position.x < -5.5){
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
            LPManager.LifeEnemy += 1;
        }

    }
    void SpawnPet(){
        if(pets){
            Instantiate(pet,new Vector3(0f,1f,4.5f), transform.rotation);
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


}
