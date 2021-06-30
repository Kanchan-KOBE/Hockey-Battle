using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript_ID : MonoBehaviour
{
    public MainMenuManager mainManager;
    [SerializeField] GameObject uI_InputUI;
    [SerializeField] InputField inputField;
    [SerializeField] Button button;
    [SerializeField] GameObject uI_Check;
    [SerializeField] Text userID;

    // Start is called before the first frame update
    void Start()
    {
        // inputField = GameObject.Find("InputField").GetComponent<InputField>();
        userID.text = "Your ID : " + $"{GameManager.userID}";
    }

    // Update is called once per frame
    void Update()
    {
        if(inputField.text.Length == 16){
            button.interactable = true;
        }else {
            button.interactable = false;
        }

    }

    public void GetInputName()
    {
        GameManager.userName = inputField.text;
        Debug.Log("OK? : " + GameManager.userName);

        inputField.text = "";
        uI_Check.SetActive(false);
        mainManager.RefleshUserData();
    }

    public void OpenCheck(){
        uI_Check.SetActive(true);
    }

    public void CloseCheck(){
        uI_Check.SetActive(false);
    }
    public void OpenInputUI(){
        uI_InputUI.SetActive(true);
    }

    public void CloseInputUI(){
        uI_InputUI.SetActive(false);
    }



}
