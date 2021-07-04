using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Manager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
