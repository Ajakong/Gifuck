using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreCount : MonoBehaviour
{
    int score=0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "score : " + score.ToString("00");

    }

    public int scoreMove
    {
        get { return score; }
        set { score = value; }
    }
}
