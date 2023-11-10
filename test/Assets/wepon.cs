using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wepon : MonoBehaviour
{

    Sword sword;

    int at;
    // Start is called before the first frame update
    void Start()
    {
        sword=GetComponent<Sword>();
    }

    // Update is called once per frame
    void Update()
    {
        at=sword.At;
        GetComponent<Text>().text=at.ToString();
    }
}
