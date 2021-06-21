using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{ 
    [SerializeField] int speed = 10;
    [SerializeField] bool left = false;
    [SerializeField] bool rotationPet = false;
    [SerializeField] bool MovePetH = false;
    [SerializeField] bool MovePetV = false;
    [SerializeField] bool transformPetH = false;
    [SerializeField] bool transformPetV = false;


    private bool moveR = true; private bool moveL = false;
    private bool moveF = true; private bool moveB = false;
    private bool bigger = true; private bool smaller = false;

    // Start is called before the first frame update
    void Start()
    {
        if(left){
            moveF = false;
            moveB = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
//移動（横）
        if(MovePetH){
            if(this.transform.position.x > 6){
            moveR = false;
            moveL = true;
            }
            if(this.transform.position.x < -6){
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

//移動（縦）
        if(MovePetV){
            if(this.transform.position.z > 4){
            moveF = false;
            moveB = true;
            }
            if(this.transform.position.z < -1){
                moveB = false;
                moveF = true;
            }

            if(moveF){
                this.transform.position += new Vector3(0,0,1) * speed * Time.deltaTime;
            }
            if(moveB){
                this.transform.position += new Vector3(0,0,-1) * speed * Time.deltaTime;
            }
        }
        
//回転
        if(rotationPet){
        this.transform.Rotate(new Vector3(0,1000,0) * Time.deltaTime, Space.World);
        }



//変形（横）
        if(transformPetH){
            if(this.transform.localScale.x > 3){
            bigger = false;
            smaller = true;
            }
            if(this.transform.localScale.x < 1){
                smaller = false;
                bigger = true;
            }

            if(bigger){
                this.transform.localScale += new Vector3(1,0,0) * speed * Time.deltaTime;
            }
            if(smaller){
                this.transform.localScale -= new Vector3(1,0,0) * speed * Time.deltaTime;
            }
        }

//変形（縦）
        if(transformPetV){
            if(this.transform.localScale.z > 3){
            bigger = false;
            smaller = true;
            }
            if(this.transform.localScale.z < 1){
                smaller = false;
                bigger = true;
            }

            if(bigger){
                this.transform.localScale += new Vector3(1,0,0) * speed * Time.deltaTime;
            }
            if(smaller){
                this.transform.localScale -= new Vector3(1,0,0) * speed * Time.deltaTime;
            }
        }

    }
}
