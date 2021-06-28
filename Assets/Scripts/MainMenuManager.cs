using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] Text txtUserName;

    // Start is called before the first frame update
    void Start()
    {
        RefleshName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefleshName(){
        txtUserName.text = GameManager.userName;
    }
}
