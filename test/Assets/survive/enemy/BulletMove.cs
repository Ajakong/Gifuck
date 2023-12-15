using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
   

    Rigidbody myRb;

    UniState state;

    Vector3 targetPos;

    Quaternion targetRot;

    Vector3 toPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 1);
        myRb.AddForce(0, 200, 0, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = GameObject.Find("unitychan").transform.position;//playerを見つける
        targetRot = Quaternion.LookRotation(targetPos);//LookRoatationで移動ベクトルに回転したのをtargetRotに代入
        targetRot.z = 0;//横回転しかしないように固定
        targetRot.x = 0;//同上
        this.transform.rotation = targetRot;//オブジェクトの角度をtargetRotにする

    }

    private void FixedUpdate()
    {
        
       
        Vector3 startPos = transform.position;//エネミーの位置を取得、startPosに代入

        toPlayer.x=targetPos.x - transform.position.x;
        toPlayer.y=targetPos.y - transform.position.y;
        toPlayer.z=targetPos.z - transform.position.z;

        Debug.Log(toPlayer);
        
        toPlayer.Normalize();



        transform.position+=toPlayer;
    }

    void OnTriggerEnter(Collider collision) // 当たり判定を察知
    {
        if(collision.gameObject.tag=="Player")
        {
            state = collision.gameObject.GetComponent<UniState>();
            state.UniHpMove -= 5;
        }
        Destroy(gameObject);
    }
}
