using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public int speed = 10;

    // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード操作
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
