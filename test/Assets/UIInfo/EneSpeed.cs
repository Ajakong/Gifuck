using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneSpeed : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Speed : " + Speed.ToString("00");

    }

    public float SpeedMove
    {
        get { return Speed; }
        set { Speed = value; }
    }
}
