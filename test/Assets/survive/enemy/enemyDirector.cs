using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour
{
    

    float moveSpeed ;//敵がプレイヤーに近づく速度
    float MaxSpeed = 0.01f;


    float timeCounter;
    float speedUpInterval=10;
    int speedUpCounter=1;

   

    theWorldTime time;

    GameObject world;
    
    // Start is called before the first frame update
    void Awake()
    {
        world = GameObject.Find("world");
        time = world.GetComponent<theWorldTime>();
        moveSpeed = MaxSpeed;
        Debug.Log(moveSpeed);
    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position;//playerを見つける
        Quaternion targetRot = Quaternion.LookRotation(targetPos);//LookRoatationで移動ベクトルに回転したのをtargetRotに代入
        targetRot.z = 0;//横回転しかしないように固定
        targetRot.x = 0;//同上
        this.transform.rotation = targetRot;//オブジェクトの角度をtargetRotにする

        timeCounter = time.timeMove;
        Debug.Log(MaxSpeed);
        if (timeCounter>=speedUpInterval*speedUpCounter)//割り算を使用しない理由はfloatなので条件指定に==が使いづらくなるため
        {
            
            
            MaxSpeed += 0.002f;
            speedUpCounter++;
            
        }
    }
    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position; //プレイヤーの位置を取得、targetPosに代入
        Vector3 startPos = transform.position;//エネミーの位置を取得、startPosに代入

        transform.position = Vector3.Lerp(startPos, targetPos, MaxSpeed);//二点間を埋めるようにmovespeedの速さで移動
    }
}
