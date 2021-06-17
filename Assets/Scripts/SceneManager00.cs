using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager00 : MonoBehaviour
{

    public int currentIndex;
    public AudioClip[] clips;
    public static int stage = 0;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        // DontDestroyOnLoad(this);
    }

    //------------------------------------------呼び出し用--------------------------------------------
    public void ToSetting(){StartCoroutine("ToSettingHoge");}
    public void ToTitle(){StartCoroutine("ToTitleHoge");
    }
    public void ToMain(){
        // StartCoroutine("ToMainHoge");
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        // yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ToPlayerSelect(){StartCoroutine("ToPlayerSelectHoge");}

    public void ToNext(){
        if(PlayerManager.playerNumber == 0){
            Debug.Log("プレイヤーが選択されていません");
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(clips[0]);
        }else{
            if(stage == 0){
                StartCoroutine("ToStageSelectHoge");
            }else if(stage == 1){
                StartCoroutine("ToSVHoge");
            }
        }
    }

    public void ToAR(){StartCoroutine("ToARHoge");}
    public void ToNextStage(){StartCoroutine("ToNextStageHoge");}
    public void ToStageSelect(){StartCoroutine("ToStageSelectHoge");}

    
    //stage(0=ARCADE,1=SURVIVAL)
    public void GetStage(int i){
        i = stage;
    }

    


    //------------------------------------HOGE--------------------------------------
    private IEnumerator ToSettingHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SettingScene");
    }
    private IEnumerator ToTitleHoge()
    {
        Debug.Log("Hoge1");
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        Debug.Log("Hoge2");
        SceneManager.LoadScene("TitleScene");
        Debug.Log("Hoge3");
    }
    private IEnumerator ToMainHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenuScene");
    }
    private IEnumerator ToPlayerSelectHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("PlayerSelectScene");
    }
    private IEnumerator ToStageSelectHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StageSelectScene");
    }
    private IEnumerator ToARHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage_AR");
    }
    private IEnumerator ToNextStageHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        EnemyManager.enemyNumber += 1;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage_AR");
    }
    private IEnumerator ToSVHoge()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Stage_SV");
    }
}
