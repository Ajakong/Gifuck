using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class scoreResult : MonoBehaviour
{
    GameObject scoreCounter;

    ScoreCount counter;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = GameObject.Find("scoreCounter");
        counter=scoreCounter.GetComponent<ScoreCount>();
    }

    // Update is called once per frame
    void Update()
    {
        score = counter.scoreMove;
        Debug.Log(score);
        Destroy(scoreCounter );
        GetComponent<Text>().text = "score : " + score.ToString("00");

    }
}
