using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_Manager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource audio_SE;
    [SerializeField] Slider slider_SE;

    // Start is called before the first frame update
    void Start()
    {
        audio_SE = GetComponent<AudioSource>();
        slider_SE.GetComponent<Slider>().normalizedValue = PlayerPrefs.GetFloat("Volume_SE");
    }

    // Update is called once per frame
    void Update()
    {
        audio_SE.volume = slider_SE.GetComponent<Slider>().normalizedValue;
    }

    public void SaveVolume_SE(){
        PlayerPrefs.SetFloat("Volume_SE", slider_SE.GetComponent<Slider>().normalizedValue);
    }

    public void SE(int _SENumber){
        GetComponent<AudioSource>().PlayOneShot(clips[_SENumber]);
    }
    public void SE_YES(){
        GetComponent<AudioSource>().PlayOneShot(clips[1]);
    }
    public void SE_NO(){
        GetComponent<AudioSource>().PlayOneShot(clips[2]);
    }
}
