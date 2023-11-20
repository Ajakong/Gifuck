using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainJump : MonoBehaviour
{
    int timer=0;

    Rigidbody myRb;

    Vector3 JumpUp;

    
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        JumpUp = new Vector3(0, 10, 0);
        
    }

    // Update is called once per frame

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            Jumping();
        }
    }

    void Jumping()
    {
        
        Debug.Log("[ayayayay]");
        myRb.AddForce(JumpUp,ForceMode.Impulse);
    }
    
}
