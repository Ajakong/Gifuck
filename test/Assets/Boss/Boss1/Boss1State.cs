using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1State : MonoBehaviour
{
    public GameObject theSun;
    public GameObject demonsSun;
    public GameObject surviveGate;

    //�A�j���[�V����
    Animator animator;
    //rigidBody�擾
    Rigidbody myRb;
    Vector3 thisPos;

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
  
            Time.timeScale = 1.0f;
            Drop = Instantiate(Item);
            Vector3 itemDropPos = transform.position;
            itemDropPos.y += 2;
            Drop.transform.position = itemDropPos;

            theSun.SetActive(true);
            demonsSun.SetActive(false);
            surviveGate.SetActive(true);
            Destroy(this.gameObject);
            
        }



        if (!deathFlag)
        {
            playerPos = player.transform.position;
            thisPos = this.transform.position;
            dis = Vector3.Distance(thisPos, playerPos);

            /*�v���C���[�Ɍ������ĕ���*/
            if (dis > 6f && dis <= 40f && !jumpFlag)
            {
                animator.SetBool("walkBool", true);

                targetRot = Quaternion.LookRotation(playerPos - transform.position);
                targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
                targetRot.x = 0;//����


                this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

                transform.position += transform.forward * 0.008f;
                //moveFlag = true;
            }
            else
            {
                animator.SetBool("walkBool", false);
                //moveFlag = false;
            }

            //�߂��ƋߐڍU��������
            if (dis <= 6)
            {
                animator.SetTrigger("attackTrigger");
            }

            //�v���C���[�Ǝ���(�{�X)�̋����𑪂��ăW�����v
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

    //���ɓ����������Ƀ_���[�W���󂯂�HP�o�[������悤��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("hit");

            slider.value -= 8f;
            //�Ȃ�float�̌덷�H�Ŏ��X�~���c�邽�߈ꉞ�͈͎w��
            if(slider.value <= 0.05)
            {
                Hp = 0;
            }
        }
    }
}
