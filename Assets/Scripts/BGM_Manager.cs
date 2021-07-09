using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_Manager : MonoBehaviour
{
    [SerializeField] AudioSource audio_BGM;
    [SerializeField] Slider slider_BGM;

    // Start is called before the first frame update
    void Start()
    {
        audio_BGM = GetComponent<AudioSource>();
        slider_BGM.GetComponent<Slider>().normalizedValue = PlayerPrefs.GetFloat("Volume_BGM");
    }

    // Update is called once per frame
    void Update()
    {
        audio_BGM.volume = slider_BGM.GetComponent<Slider>().normalizedValue;
    }

    public void SaveVolume_BGM(){
        PlayerPrefs.SetFloat("Volume_BGM", slider_BGM.GetComponent<Slider>().normalizedValue);
    }

    

}
