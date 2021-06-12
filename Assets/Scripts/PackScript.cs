using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    public byte speed = 9;
    private float i = 0;
    private Rigidbody myRigid;

    private LPManager lPManager;

    // Start is called before the first frame update
    void Start()
    {
        lPManager = GameObject.Find("LPManager").GetComponent<LPManager>();

        myRigid = GetComponent<Rigidbody>();
        i = Random.Range(-1f,1f);
        myRigid.AddForce((transform.forward * -1 + transform.right * i) * speed, ForceMode.VelocityChange);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyGoal"){
            Destroy(this.gameObject);
            lPManager.ELP_Lose();
        }else if(collision.gameObject.tag == "MyGoal"){
            Destroy(this.gameObject);
            lPManager.MLP_Lose();
        }
    }

}
