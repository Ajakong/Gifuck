using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEneCountCatch : MonoBehaviour
{
    int killCount;

    ScoreCount counter;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        counter=score.GetComponent<ScoreCount>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.killNumMove = killCount;
    }

    public int KillMove
    {
        get { return killCount; }
        set { killCount = value; }
    }
}
