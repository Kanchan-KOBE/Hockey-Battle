using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    [SerializeField] AudioSource[] audio_BGM;

    public static bool settingBGM_0 = false;
    public static bool settingBGM_1 = false;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("SignUp") == 0){
            PlayerPrefs.SetInt("Volume_BGM", 1);
            PlayerPrefs.GetInt("SignUp", 1);
        }

        DontDestroyOnLoad(this);
        // SetVolume_BGM();
        audio_BGM[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume_BGM(){
        // audio_BGM[0].volume = PlayerPrefs.GetInt("Volume_BGM");
        // audio_BGM[0].volume = 0.5f;
    }

    public void BGM_Main(){
        
    }

    public void BGM_Battle(){

    }

    //バトルに移動時BGM変更
    //メニューに移動時BGM変更
    private IEnumerator HogeBGM_Main(){
        int fade = PlayerPrefs.GetInt("Volume_BGM") / 60;

        for(int i = 0; i < 60; i ++){
            audio_BGM[0].volume = audio_BGM[0].volume - fade;
        }
        yield return new WaitForSeconds(1.0f);

        for(int i = 0; i < 60; i ++){
            audio_BGM[1].volume = audio_BGM[1].volume + fade;
        }
    }

}
