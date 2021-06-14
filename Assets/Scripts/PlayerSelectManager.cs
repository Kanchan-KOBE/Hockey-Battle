using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    public Image imgStatus;
    public Sprite[] imgPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        imgStatus.sprite = imgPlayers[PlayerManager.playerNumber];
    }
}
