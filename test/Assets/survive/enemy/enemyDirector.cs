using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour
{
    public GameObject eneBullet;

    GameObject LightningBullet;

    float moveSpeed;//敵がプレイヤーに近づく速度
    float MaxSpeed = 0.007f;


    float timeCounter;
    float speedUpInterval = 10;
    int speedUpCounter = 1;

    bool playerChase;

    Vector3 collisionImpact;
    Vector3 Shoot;

    theWorldTime time;

    GameObject world;

    Rigidbody myRb;

    EneSpeedCatch EneSpeed;
    GameObject EneSpeedUI;

    // Start is called before the first frame update
    void Awake()
    {
        Shoot = new Vector3(0, 2, 0);

        myRb = GetComponent<Rigidbody>();
      
        world = GameObject.Find("world");
        time = world.GetComponent<theWorldTime>();
        moveSpeed = MaxSpeed;
        EneSpeedUI = GameObject.Find("EneSpeed");
        EneSpeed = EneSpeedUI.GetComponent<EneSpeedCatch>();

    }

    // Update is called once per frame

    private void Update()
    {
        collisionImpact=myRb.velocity;
        collisionImpact.y=collisionImpact.x;
        Vector3 targetPos = GameObject.Find("unitychan").transform.position;//playerを見つける
        Quaternion targetRot = Quaternion.LookRotation(targetPos);//LookRoatationで移動ベクトルに回転したのをtargetRotに代入
        targetRot.z = 0;//横回転しかしないように固定
        targetRot.x = 0;//同上
        this.transform.rotation = targetRot;//オブジェクトの角度をtargetRotにする

        timeCounter = time.timeMove;
      
        if (timeCounter >= speedUpInterval * speedUpCounter)//割り算を使用しない理由はfloatなので条件指定に==が使いづらくなるため
        {
           

            MaxSpeed += 0.001f;
            speedUpCounter++;
            EneSpeed.SpeedMove = MaxSpeed;
        }
    }
    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position; //プレイヤーの位置を取得、targetPosに代入
        Vector3 startPos = transform.position;//エネミーの位置を取得、startPosに代入

        if(playerChase==true)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, MaxSpeed);//二点間を埋めるようにspeedの速さで移動
        }
    }

    void OnTriggerStay(Collider collision) // 当たり判定を察知
    {
        if(collision.gameObject.tag=="Player")
        {
            playerChase = true;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerChase = false;
        }
    }
}
