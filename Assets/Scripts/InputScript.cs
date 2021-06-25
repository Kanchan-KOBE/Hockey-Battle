using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Button button;
    [SerializeField] GameObject uI_Check;

    // Start is called before the first frame update
    void Start()
    {
        // inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputField.text == ""){
            button.interactable = false;
        }else{
            button.interactable = true;
        }
    }

    public void GetInputName()
    {
        GameManager.playerName = inputField.text;
        Debug.Log(GameManager.playerName);

        inputField.text = "";
        uI_Check.SetActive(false);
    }

    public void Check(){
        uI_Check.SetActive(true);
    }

    public void Cancel(){
        uI_Check.SetActive(false);
    }

}
