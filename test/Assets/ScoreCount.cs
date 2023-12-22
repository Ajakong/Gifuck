using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreCount : MonoBehaviour
{
    public int score=0;
    public int killNum=0;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public int scoreMove
    {
        get { return score; }
        set { score = value; }
    }

    public int killNumMove
    {
        get { return killNum; }
        set { killNum = value; }

    }
}
