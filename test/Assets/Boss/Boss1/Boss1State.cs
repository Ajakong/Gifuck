using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1State : MonoBehaviour
{
    //�A�j���[�V����
    Animator animator;
    //rigidBody�擾
    Rigidbody myRb;

    //�ő�HP
    public int maxHp = 100;
    //HP
    public int Hp = 100;

    //�|���ꂽ���ɗ��Ƃ��A�C�e��
    public GameObject Item;
    GameObject Drop;

    //HP�o�[
    GameObject hpBar;
    Slider slider;

    //�v���C���[
    public GameObject player;

    //�v���C���[��position
    Vector3 playerPos;
    //�{�X�ƃv���C���[�̋���
    public float dis;
    //�v���C���[���������
    Quaternion targetRot;
    //�ړ����邩
    bool moveFlag = false;

    /*�W�����v�֌W*/
    //�O�ɔ�ԗ�
    float forcePowerFront;
    //��ɔ�ԗ�
    float forcePowerUp;
    //�W�����v��
    Vector3 force;
    //�W�����v�̒�����N�[���^�C���p
    public int jumpCount = 0;
    //�W�����v���Ă��邩
    bool jumpFlag = false;

    /*�|���ꂽ�Ƃ��֌W*/
    //�|���ꂽ�Ƃ��̃A�j���[�V����������鎞��
    float deathAnimationFrame = 0;
    //���񂾂��ǂ���
    bool deathFlag = false;

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
        forcePowerFront = 14f;
        forcePowerUp = 17.52f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            animator.SetBool("DeathBool",true);
            deathFlag = true;
        }

        if(deathAnimationFrame >= 15f)
        {
            Destroy(this.gameObject);
            Drop = Instantiate(Item);
            Vector3 itemDropPos = transform.position;
            itemDropPos.y += 2;
            Drop.transform.position = itemDropPos;
        }

        playerPos = player.transform.position;

        dis = Vector3.Distance(playerPos, this.transform.position);

        //�v���C���[�Ǝ���(�{�X)�̋����𑪂��ăW�����v�Ƌߐڂ𔻒f
        if(dis > 30 && !jumpFlag)
        {
            //groundFlag = true;
            animator.SetTrigger("jumpTrigger");
            jumpFlag = true;
        }

        //if(dis > 6 && dis <= 40 && !jumpFlag)
        //{
        //    animator.SetBool("walkBool",true);

        //    transform.position += transform.forward * 0.02f;
        //    //moveFlag = true;
        //}
        //else
        //{
        //    animator.SetBool("walkBool", false);
        //    //moveFlag = false;
        //}

        if (jumpFlag)
        {
            jumpCount++;
            if (jumpCount == 160)
            {
                force = forcePowerFront * transform.forward + forcePowerUp * transform.up;

                myRb.AddForce(force, ForceMode.Impulse);
                //transform.transform.position += transform.up * forcePower + transform.forward * forcePower;

            }
            if (jumpCount > 2000)
            {
                jumpCount = 0;
                jumpFlag = false;
            }
        }
        else
        {
            targetRot = Quaternion.LookRotation(playerPos);
            //targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
            //targetRot.x = 0;//����
            this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���
        }

    }

    void FixedUpdate()
    {
        if(deathFlag)
        {
            deathAnimationFrame += 0.08f;
        }

        //if(moveFlag)
        //{
        //    targetRot = Quaternion.LookRotation(playerPos);
        //    targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
        //    targetRot.x = 0;//����
        //    this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

        //    transform.position += transform.forward * 0.1f;
        //}
    }

    //���ɓ����������Ƀ_���[�W���󂯂�HP�o�[������悤��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("hit");

            slider.value -= 20f;
            //�Ȃ�float�̌덷�H�Ŏ��X�~���c�邽�߈ꉞ�͈͎w��
            if(slider.value <= 0.005)
            {
                Hp = 0;
            }
        }
    }
}
