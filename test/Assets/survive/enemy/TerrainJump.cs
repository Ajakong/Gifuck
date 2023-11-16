using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainJump : MonoBehaviour
{


    Rigidbody myRb;

    Vector3 JumpUp;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        JumpUp = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    
    void OnTriggerEnter(Collider collision) // “–‚½‚è”»’è‚ðŽ@’m
    {
        
        Debug.Log("aaaaa0");
        Jumping();    
        
        
    }

    void Jumping()
    {
        myRb.velocity.Equals(JumpUp);
    }
    
}
