using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    public MainMenuManager mainManager;
    [SerializeField] GameObject uI_InputUI;
    [SerializeField] InputField inputField;
    [SerializeField] Button button;
    [SerializeField] GameObject uI_Check;
    [SerializeField] Text checkName;


    // Start is called before the first frame update
    void Start()
    {
        // inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputField.text.Length < 3){
            button.interactable = false;
        }else if(inputField.text.Length > 6){
            button.interactable = false;
        }else{
            button.interactable = true;
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
        checkName.text = inputField.text;
        uI_Check.SetActive(true);
    }
    public void CheckName(){
        checkName.text = inputField.text;
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
