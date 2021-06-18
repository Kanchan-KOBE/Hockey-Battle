using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackManager : MonoBehaviour
{
    public GameObject pack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPack()
    {
        Instantiate(pack, new Vector3(0f, 0.75f, 2f), transform.rotation);
    }
}

