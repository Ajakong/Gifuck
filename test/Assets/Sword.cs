using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using System.Security.Cryptography;
using UnityEngine;

public class Sword : MonoBehaviour
{
    GameObject player;

    //プレイヤーの座標
    Vector3 playerLocalPos;
    //プレイヤーのtransformを取得用
    Transform playerTransform;

    //敵の基礎能力
    EnemyState EHp;

    //プレイヤーに当たったかどうか
    bool isHitFlag = false;

    //装備前の剣の座標
    Vector3 swordPos;
    //装備後の剣の座標
    Vector3 eqipPos;
    //剣の移動速度
    float speed;
    float updownSpeed;

    int time = 0;
    //剣の上昇時間
    int timeMax1 = 40;
    //剣の下降時間
    int timeMax2 = 80;

    //親オブジェクトにするオブジェクト名
    public GameObject RootObject;

    

    int swordAt;

    //当たり判定
    BoxCollider col;
    public float count = 0.0f;
    bool colFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        //"player"を探す
        //player = GameObject.Find("Player");
        player = GameObject.Find("unitychan");
        //装備する前の剣の座標を指定
        swordPos = new Vector3(0.0f, 1.0f, 3.0f);

        //装備した後の剣の座標を指定
        //eqipPos = new Vector3(0.3f, 1.0f, 0.0f);
        eqipPos = new Vector3(-0.019f, -0.808f, 0.017f);

        updownSpeed = 0.0005f;

        //剣の移動速度
        speed = 0.0025f;

        swordAt = 30;

        //プレイヤーのtransformを取得
        playerTransform = player.transform;

        col = this.gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //プレイヤーに当たる前の処理
        if (!isHitFlag)
        {
            if (time <= timeMax1)
            {
                //speedの再設定
                if (time == 0)
                {
                    speed = 0.004f;
                }
                //剣を上に移動
                swordPos.y += speed;
                //移動速度を減らす
                speed -= updownSpeed;
                time++;
                //剣の座標設定
                transform.position = swordPos;
            }
            else if (time <= timeMax2)
            {
                //speedの再設定

                if (time == timeMax1 + 1)
                {
                    speed = 0.004f;
                }
                //剣を下に移動
                swordPos.y -= speed;
                //移動速度を減らす
                speed -= updownSpeed;
                time++;
                //剣の座標設定
                transform.position = swordPos;
            }
            else
            {
                time = 0;
            }
        }

        //当たり判定（未完成
        if (colFlag)
        {
            count++;
            if (count >= 1f && count <= 1.5f)
            {
                col.enabled = true;
            }
            else if (count > 1.5f || count <= 30f)
            {
                col.enabled = false;
            
            }

        }

        if(count > 55)
        {
            colFlag = false;
            count = 0;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            colFlag = true;
        }
    }

    void OnTriggerEnter(Collider collision) // 当たり判定を察知
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EHp = collision.GetComponent<EnemyState>();
            EHp.HpMove -= swordAt;
            
        }

        if (collision.gameObject.tag == "Player")
        {


            //プレイヤーに当たった(剣の動きを消す)
            isHitFlag = true;
            //剣をプレイヤーの子オブジェクトにする
            this.gameObject.transform.parent = RootObject.gameObject.transform;

            //ワールド座標を基準に、回転を取得
            Vector3 localAngle = playerTransform.localEulerAngles;
            //Rotationを0に(もともと90に設定して配置している)
            localAngle.y = 0.0f;
            //Rotationを設定
            transform.localEulerAngles = localAngle;

            playerLocalPos.x = 0.0f;
            playerLocalPos.y = 0.0f;
            playerLocalPos.z = 0.0f;
            //剣を装備した時の剣の位置に移動させるための座標を足す
            playerLocalPos += eqipPos;
            //剣の装備後の座標を設定
            transform.localPosition = playerLocalPos;

            //当たり判定削除
            col.enabled = false;

        }

  
    }

    public int At
    {
        get { return swordAt; }
    }
}