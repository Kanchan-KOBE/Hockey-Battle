using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Text playerHighScore;

    [SerializeField] Text[] rankerScores;

    // Start is called before the first frame update
    void Start()
    {
        playerHighScore.text = GameManager.highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
