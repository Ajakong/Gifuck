using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneSpeedCatch : MonoBehaviour
{
    float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Speed);
    }

    public float SpeedMove
    {
        get { return Speed; }
        set { Speed = value; }
    }
}
