using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public int speed = 10;
    public GameObject playerUI;

    private bool gameUI = true;

    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ARGameManager.gameStep == 3) //スタート時UI表示
        {
            if(gameUI)
            {
                playerUI.SetActive(true);
                Debug.Log("gameUI");

                gameUI = false;
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
}
