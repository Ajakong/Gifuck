using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneSpeed : MonoBehaviour
{
    public float Speed;
    EneSpeedCatch Info;
    public GameObject eneSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Info=eneSpeed.GetComponent<EneSpeedCatch>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = Info.SpeedMove*100;
        GetComponent<Text>().text = "Speed : " + Speed.ToString("f4");

    }

    
}
