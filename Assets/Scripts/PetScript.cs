using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
public int speed = 10;

    private bool moveR = true;
    private bool moveL = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        this.transform.Rotate(new Vector3(0,800,0) * Time.deltaTime, Space.World);
    }
}
