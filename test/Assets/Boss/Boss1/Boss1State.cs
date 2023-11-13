using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1State : MonoBehaviour
{
    Animator animator;

    public int maxHp = 1;
    public int Hp = 1;

    public GameObject Item;
    GameObject Drop;

    GameObject hpBar;
    Slider slider;

    public GameObject player;

    //プレイヤーのposition
    Vector3 pLength;
    //ボスとプレイヤーの距離
    public float dis;

    bool groundFlag = false;
    bool jumpFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hpBar = GameObject.Find("BossHp");
        slider = hpBar.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position;
        if (Hp <= 0)
        {
            Destroy(this.gameObject);

            Drop = Instantiate(Item);
            Drop.transform.position = transform.position;
        }

        pLength = player.transform.position;

        dis = Vector3.Distance(pLength, this.transform.position);

        //プレイヤーと自分(ボス)の距離を測ってジャンプと近接を判断
        if(dis > 30 && !groundFlag)
        {
            groundFlag = true;
            jumpFlag = true;
        }

    }

    void FixedUpdate()
    {
        if (jumpFlag)
        {
            animator.SetTrigger("jumpTrigger");
            Vector3 force = 16f * Vector3.up;
            Rigidbody myRb = GetComponent<Rigidbody>();
            myRb.AddForce(force, ForceMode.Impulse);
            jumpFlag = false;
        }
    }

    public int HpMove
    {
        get { return Hp; }
        set { Hp = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("hit");

            slider.value -= 0.2f;
            if(slider.value <= 0.005)
            {
                Hp = 0;
            }
        }

        if(other.gameObject.tag == "ground")
        {
            groundFlag = false;
        }
    }
}
