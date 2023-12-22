using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1State : MonoBehaviour
{
    public GameObject theSun;
    public GameObject demonsSun;
    public GameObject surviveGate;

    //アニメーション
    Animator animator;
    //rigidBody取得
    Rigidbody myRb;
    Vector3 thisPos;

    //最大HP
    public int maxHp = 100;
    //HP
    public int Hp = 100;

    //倒された時に落とすアイテム
    public GameObject Item;
    GameObject Drop;

    //HPバー
    GameObject hpBar;
    Slider slider;

    //プレイヤー
    public GameObject player;

    //プレイヤーのposition
    Vector3 playerPos;
    //ボスとプレイヤーの距離
    public float dis;
    //プレイヤーがいる方向
    Quaternion targetRot;
    //移動するか
    bool moveFlag = false;

    /*ジャンプ関係*/
    //前に飛ぶ力
    float forcePowerFront;
    //上に飛ぶ力
    float forcePowerUp;
    //ジャンプ力
    Vector3 force;
    //ジャンプの調整やクールタイム用
    public int jumpCount = 0;
    //ジャンプしているか
    bool jumpFlag = false;

    /*倒されたとき関係*/
    //倒されたときのアニメーションが流れる時間
    float deathAnimationFrame = 0;
    //死んだかどうか
    bool deathFlag = false;

    Transform tempTrans;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("unitychan");
        playerPos = Vector3.zero;
        animator = GetComponent<Animator>();
        hpBar = GameObject.Find("BossHp");
        slider = hpBar.GetComponent<Slider>();

        myRb = GetComponent<Rigidbody>();
        //forceDirection = new Vector3(0f, 4.24f, -2.0f);
        forcePowerFront = 16f;
        forcePowerUp = 14f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            if(!tempTrans)
            {
                tempTrans = this.transform;
            }
            Time.timeScale = 0.4f;
            animator.SetBool("DeathBool",true);
            deathFlag = true;
        }

        if(deathAnimationFrame >= 12f)
        {
            theSun.SetActive(true);
            demonsSun.SetActive(false);
            surviveGate.SetActive(true);

            Time.timeScale = 1.0f;
            Drop = Instantiate(Item);
            Vector3 itemDropPos = transform.position;
            itemDropPos.y += 2;
            Drop.transform.position = itemDropPos;

            

            Destroy(this.gameObject);
            
        }



        if (!deathFlag)
        {
            playerPos = player.transform.position;
            thisPos = this.transform.position;
            dis = Vector3.Distance(thisPos, playerPos);

            /*プレイヤーに向かって歩く*/
            if (dis > 6f && dis <= 40f && !jumpFlag)
            {
                animator.SetBool("walkBool", true);

                targetRot = Quaternion.LookRotation(playerPos - transform.position);
                targetRot.z = 0;//横回転しかしないように固定
                targetRot.x = 0;//同上


                this.transform.rotation = targetRot;//オブジェクトの角度をtargetRotにする

                transform.position += transform.forward * 0.008f;
                //moveFlag = true;
            }
            else
            {
                animator.SetBool("walkBool", false);
                //moveFlag = false;
            }

            //近いと近接攻撃をする
            if (dis <= 6)
            {
                animator.SetTrigger("attackTrigger");
            }

            //プレイヤーと自分(ボス)の距離を測ってジャンプ
            if (dis > 30f && !jumpFlag)
            {
                //groundFlag = true;
                animator.SetTrigger("jumpTrigger");
                jumpCount++;
                if (jumpCount == 160)
                {
                    force = forcePowerFront * transform.forward + forcePowerUp * transform.up;

                    myRb.AddForce(force, ForceMode.Impulse);
                    //transform.transform.position += transform.up * forcePower + transform.forward * forcePower;

                }
                else if (jumpCount > 1200)
                {
                    jumpCount = 0;
                    jumpFlag = false;
                }
            }
        }

    }

    void FixedUpdate()
    {
        if(deathFlag)
        {
            deathAnimationFrame += 0.08f;
        }
    }

    //剣に当たった時にダメージを受けてHPバーが減るように
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("hit");

            slider.value -= 2f;
            //なんかfloatの誤差？で時々ミリ残るため一応範囲指定
            if(slider.value <= 0.05)
            {
                Hp = 0;
            }
        }
    }
}
