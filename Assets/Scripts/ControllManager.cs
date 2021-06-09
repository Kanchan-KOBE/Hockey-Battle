using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllManager : MonoBehaviour
{
    // public GameManager myManager;
    // public GameObject player;

    public bool push = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(push){
            Debug.Log("hold");
            // player.MovePlayerR();
        }
    }

    public void Down(){
        Debug.Log("down");
        push = true;
    }
    public void Up(){
        Debug.Log("up");
        push = false;
    }
}
