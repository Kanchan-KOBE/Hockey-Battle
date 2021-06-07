using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(0f,1f,-8f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
