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

    bool jumpIntervalFlag = false;

    Transform tempTrans;

    public GameObject LeftArm;
    bool AttackFlag = false;
    int CollCount;

    public GameObject jumpImpact;
    GameObject impact;
    bool impactFlag=false;

    Ray ray;
    Vector3 originRay;
    Vector3 RayCast;

    Vector2 tempVec;

    [SerializeField] private LayerMask groundLayer;

    Quaternion origin;
    bool rotateFlag=false;
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
        forcePowerFront = 32.0f;
        forcePowerUp = 136.0f;
        LeftArm.GetComponent<BoxCollider>().enabled = false;
        origin = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if(AttackFlag==true)
        {
            
               
            if(CollCount>=40)
            {
                CollCount = 0;
                AttackFlag = false;
                rotateFlag = false;
                LeftArm.GetComponent<BoxCollider>().enabled = false;
            }
        }
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

            /*�v���C���[�Ɍ������ĕ���*/
            if (dis > 6.0f && dis <= 60.0f/* && !jumpFlag*/)
            {
                animator.SetBool("walkBool", true);

                this.transform.rotation = origin;
                targetRot = Quaternion.LookRotation(transform.position - playerPos);
                targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
                targetRot.x = 0;//����
                

                this.transform.rotation = this.transform.rotation * targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

                transform.position += transform.forward * 0.008f;
                //moveFlag = true;
            }
            else
            {
                animator.SetBool("walkBool", false);
                //moveFlag = false;
            }

            //�߂��ƋߐڍU��������
            if (dis <= 6.0f)
            {
                
                animator.SetTrigger("attackTrigger");
                LeftArm.GetComponent<BoxCollider>().enabled = true;
                AttackFlag = true;
            }

            //�v���C���[�Ǝ���(�{�X)�̋����𑪂��ăW�����v
            if (dis > 60.0f && !jumpFlag)
            {
                //groundFlag = true;
                animator.SetTrigger("jumpTrigger");
                jumpIntervalFlag = true;
                jumpFlag = true;
                if (jumpCount == 120)
                {
                    force = forcePowerFront * transform.forward + forcePowerUp * transform.up;

                    myRb.AddForce(force, ForceMode.Impulse);
                    //transform.transform.position += transform.up * forcePower + transform.forward * forcePower;
                    impactFlag = true;
                }
                else if(jumpCount>=300&&jumpCount<=600)
                {
                    if (Physics.Raycast(originRay, RayCast, 80, groundLayer) && impactFlag == false)
                    {
                        impactFlag = true;
                        impact = Instantiate(jumpImpact);
                        impact.transform.position = transform.position;
                    }
                }
                else if (jumpCount > 600)
                {
                    originRay = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

                    ray = new Ray(originRay, RayCast);
                    Debug.Log(originRay);

                }
            }

            if(jumpIntervalFlag)
            {
                jumpCount++;
                if(jumpCount >= 600)
                {
                    jumpCount = 0;
                    jumpFlag = false;
                    jumpIntervalFlag = false;
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
        if(AttackFlag==true&&rotateFlag==true)
        {
            targetRot = Quaternion.LookRotation(transform.position - playerPos);
            targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
            targetRot.x = 0;//����


            this.transform.rotation = this.transform.rotation * targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

            rotateFlag = false;
        }
        if(AttackFlag==true)
        {
            CollCount++;
        }
    }

    //���ɓ����������Ƀ_���[�W���󂯂�HP�o�[������悤��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("hit");

            slider.value -= 2f;
            //�Ȃ�float�̌덷�H�Ŏ��X�~���c�邽�߈ꉞ�͈͎w��
            if(slider.value <= 0.05)
            {
                Hp = 0;
            }
        }
    }
}
