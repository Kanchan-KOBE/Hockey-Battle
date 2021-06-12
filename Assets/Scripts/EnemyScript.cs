using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int number = 0;
    [SerializeField] int speed = 10;
    [SerializeField] Sprite icon;

    private bool moveR = true;
    private bool moveL = false;
    private Image iconImage;

    // Start is called before the first frame update
    void Start()
    {
        iconImage = GameObject.Find("Img_IconE").GetComponent<Image>();
        iconImage.sprite = icon;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > 5.5){
            moveR = false;
            moveL = true;
        }
        if(this.transform.position.x < -5.5){
            moveL = false;
            moveR = true;
        }

        if(moveR){
            this.transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
        }
        if(moveL){
            this.transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
        }
    }

    
}
