using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItem : MonoBehaviour
{
    float speed = 0.00001f;

    int awakeCount;

    int playerCount;

    Rigidbody myRb;

    Vector3 DropUp;

    //親オブジェクトにするオブジェクト名
    GameObject oyaObj;

    GameObject SwordInfo;
    

    GameObject Player;

    GameObject scoreCounter;
    ScoreCount Score;


    private void Awake()
    {
        awakeCount++;
        playerCount = awakeCount;
        scoreCounter = GameObject.Find("scoreCounter");
        Score = scoreCounter.GetComponent<ScoreCount>();

        SwordInfo = GameObject.Find("ObjSword");
        Player = GameObject.Find("unitychan");
    }
    // Start is called before the first frame update
    void Start()
    {

        DropUp = new Vector3(0, 3f, 0);
        //myRb.AddForce(DropUp,ForceMode.Impulse);
        transform.position += DropUp;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        speed *= 2.0f;

        Vector3 targetPos =Player.transform.position; //プレイヤーの位置を取得、targetPosに代入
        Vector3 startPos = transform.position;//エネミーの位置を取得、startPosに代入

        transform.position = Vector3.Lerp(startPos, targetPos, speed);//二点間を埋めるようにspeedの速さで移動

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SwordInfo.AddComponent<SwordColor>();

            Score.scoreMove += 2000;


            Destroy(this.gameObject);
        }


    }

}
