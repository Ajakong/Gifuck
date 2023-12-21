using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KillEneCount : MonoBehaviour
{
    public int KillCount=0;
    KillEneCountCatch Info;
    public GameObject enekillCount;
    // Start is called before the first frame update
    void Start()
    {
        Info=enekillCount.GetComponent<KillEneCountCatch>();
    }

    // Update is called once per frame
    void Update()
    {
        KillCount = Info.KillMove;
        GetComponent<Text>().text = "Kill : " + KillCount.ToString("00");

    }

   
}
