using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theWorldTime : MonoBehaviour
{
    float time;

    bool startFlag=false;

    public GameObject blackOut;
    // Start is called before the first frame update
    void Start()
    {
        startFlag = true;
        blackOut.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(startFlag==true)
        {
            if(time<=3)
            {
                time = Time.time;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                time = 0;
                startFlag = false;
            }
        }
        else 
        {
            time = Time.time;
        }
        
    }

    public float timeMove
    {
        get { return time; }
    }
}
