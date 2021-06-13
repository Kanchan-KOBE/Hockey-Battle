using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllManager : MonoBehaviour
{
    // public GameManager myManager;
    // public GameObject player;
    public Image iconPlayer;
    public Image iconEnemy;
    public Sprite[] imgPlayer;
    public Sprite[] imgEnemy;

    public static bool pushR = false;
    public static bool pushL = false;


    // Start is called before the first frame update
    void Start()
    {
        iconPlayer.sprite = imgPlayer[PlayerManager.playerNumber];
        iconEnemy.sprite = imgEnemy[EnemyManager.enemyNumber];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DownR(){
        pushR = true;
    }
    public void UpR(){
        pushR = false;
    }
    public void DownL(){
        pushL = true;
    }
    public void UpL(){
        pushL = false;
    }
}
