using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHpDecCount : MonoBehaviour
{
    int hpDecCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int HpCounting
    {
        get { return hpDecCount; }
        set { hpDecCount = value; }
    }
    

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag=="Enemy")
        {
            hpDecCount++;
        }
    }
}
