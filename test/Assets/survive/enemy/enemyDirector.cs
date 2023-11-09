using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour
{
    float moveSpeed = 0.01f;//敵がプレイヤーに近づく速度

    Vector3 _prevPosition;//前のフレーム位置
    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position;//playerを見つける
        Quaternion targetRot = Quaternion.LookRotation(targetPos);//LookRoatationで移動ベクトルに回転したのをtargetRotに代入
        targetRot.z = 0;//横回転しかしないように固定
        targetRot.x = 0;//同上
        this.transform.rotation = targetRot;//オブジェクトの角度をtargetRotにする
    }
    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position; //プレイヤーの位置を取得、targetPosに代入
        Vector3 startPos = transform.position;//エネミーの位置を取得、startPosに代入



        transform.position = Vector3.Lerp(startPos, targetPos, moveSpeed);//二点間を埋めるようにmovespeedの速さで移動
    }
}
