using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    public byte speed = 9;
    public static bool poisonTime = false;
    private float i = 0;
    private Rigidbody myRigid;

    private LPManager lPManager;
    public AudioClip[] clips;
    [SerializeField] Material[] packMaterials;

    private bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        lPManager = GameObject.Find("LPManager").GetComponent<LPManager>();

        myRigid = GetComponent<Rigidbody>();
        

        AudioSource audio = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(ARGameManager.gameStep == 6) //Game実行
        {
            if(start){
                i = Random.Range(-0.5f,0.5f);
                myRigid.AddForce((transform.forward * -1.2f + transform.right * i) * speed, ForceMode.VelocityChange);
                start = false;
            }
            
        }
    }

    private IEnumerator HogePoisonTime()
    {
        poisonTime = true;
        yield return new WaitForSeconds(0.3f);
        poisonTime = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyGoal"){
            Destroy(this.gameObject);
            lPManager.ELP_Lose();
        }
        else if(collision.gameObject.tag == "MyGoal"){
            Destroy(this.gameObject);
            lPManager.MLP_Lose();
        }
        else if(collision.gameObject.tag == "Wall"){
            GetComponent<AudioSource>().PlayOneShot(clips[0]);
        }
        else if(collision.gameObject.tag == "Enemy"){
            this.tag = "Pack";
            this.GetComponent<Renderer>().material = packMaterials[0];
            GetComponent<AudioSource>().PlayOneShot(clips[0]);
        }
        else if(collision.gameObject.tag == "Player"){
            if(this.tag == "Pack(Poison)"){
                StartCoroutine("HogePoisonTime");
                this.GetComponent<Renderer>().material = packMaterials[0];
                GetComponent<AudioSource>().PlayOneShot(clips[1]);
                this.tag = "Pack";
            }else{
                this.tag = "Pack";
                this.GetComponent<Renderer>().material = packMaterials[0];
                GetComponent<AudioSource>().PlayOneShot(clips[0]);
            }
            
        }
        else if(collision.gameObject.tag == "Poison"){
            this.tag = "Pack(Poison)";
            this.GetComponent<Renderer>().material = packMaterials[1];
            GetComponent<AudioSource>().PlayOneShot(clips[1]);
        }
        else if(collision.gameObject.tag == "Illusioner"){
            this.tag = "Pack(Illusion)";
            this.GetComponent<Renderer>().material = packMaterials[2];
            GetComponent<AudioSource>().PlayOneShot(clips[2]);
        }
        else if(collision.gameObject.tag == "Pet"){
            GetComponent<AudioSource>().PlayOneShot(clips[3],1.0f);
        }
    }

}
