using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEneCountCatch : MonoBehaviour
{
    int killCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int KillMove
    {
        get { return killCount; }
        set { killCount = value; }
    }
}
