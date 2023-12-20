using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KillEneCount : MonoBehaviour
{
    public int KillCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Kill : " + KillCount.ToString("00");

    }

    public int KillMove
    {
        get { return KillCount; }
        set { KillCount = value; }
    }
}
