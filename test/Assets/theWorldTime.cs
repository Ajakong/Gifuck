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
        
            time = Time.time;
        
        
    }

    public float timeMove
    {
        get { return time; }
    }
}
