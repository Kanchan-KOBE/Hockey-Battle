using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public static bool cutInP = false;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject cutInUI;

    [SerializeField] Image iconImg;
    [SerializeField] Image cutInImg;
    [SerializeField] Text nameP;

    [SerializeField] AudioSource audio_P;

    [SerializeField] string playerName;
    [SerializeField] Sprite playerImg;
    [SerializeField] GameObject pet;
    public int speed = 10;

    //SKILLS
    [SerializeField] bool lifeCharge = false;
    [SerializeField] bool lifeChargePlus = false;
    [SerializeField] bool pets = false;
    [SerializeField] bool zombie = false;
    [SerializeField] bool lucky = false;



    private bool gameUI = true;
    private bool skill1 = true;

    // Start is called before the first frame update
        void Start()
    {
        iconImg.sprite = playerImg;
        cutInImg.sprite = playerImg;
        nameP.text = playerName;

        if(lucky){
            ARGameManager.scoreMag = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        audio_P.volume = PlayerPrefs.GetFloat("Volume_SE");

        if(cutInP){ //CUT IN
            cutInUI.SetActive(true);
        }else{
            cutInUI.SetActive(false);
        }
        if(ARGameManager.gameStep == 2) //CUT IN
        {
            cutInP = true;
        }


        if(ARGameManager.gameStep == 3) //スタート時UI表示
        {
            if(gameUI)
            {
                cutInP = false;
                playerUI.SetActive(true);

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

                skill1 = false;
            }
        }

        if(LPManager.zombieCheckP)//SKILL ゾンビ
        {
            Zombie();
            cutInP = true;
            LPManager.zombieCheckP = false;
        }


        if(PackScript.poisonTime){
            if(this.transform.localScale.x > 0.5){
                this.transform.localScale -= new Vector3(0.2f,0f,0f) * Time.deltaTime;
            }if(this.transform.localScale.z > 0.5){
                this.transform.localScale -= new Vector3(0f,0f,0.2f) * Time.deltaTime;
            }
        }

        //キーボード操作
        if(ControllManager.pushR){
            MovePlayerR();
        }
        if(ControllManager.pushL){
            MovePlayerL();
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            MovePlayerR();
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            MovePlayerL();
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += new Vector3(0,0,1) * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += new Vector3(0,0,-1) * speed * Time.deltaTime;
        }
    }


    //ボタン操作（L,R）
    

    //移動処理
    public void MovePlayerR()
    {
        if(this.transform.position.x < 5.5){
        this.transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
        }
    }
    public void MovePlayerL()
    {
        if(this.transform.position.x > -5.5){
            this.transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
        }
    }



    //SKILLS-------------------------------------------------------
    void LifeCharge(){
        if(lifeCharge){
            if(LPManager.LifePlayer < 5){
            LPManager.LifePlayer += 1;
            }
        }

    }
    void LifeChargePlus(){
        if(lifeChargePlus){
            for(int i = 0; i < 2; i++){
                if(LPManager.LifePlayer < 5){
                    LPManager.LifePlayer += 1;
                }
            }
        }

    }
    void SpawnPet(){
        if(pets){
            Instantiate(pet,new Vector3(0f,1f,-4f), Quaternion.Euler(0f,180f,0f));
        }
    }
    void Zombie(){
        if(zombie){
            int i = Random.Range(0,99);
            Debug.Log(i);
            if(i < 30){
                LPManager.LifePlayer = 1;
            }else{
                ARGameManager.isLose = true;
            }
        }else
        {
            ARGameManager.isLose = true;
        }
    }
}
