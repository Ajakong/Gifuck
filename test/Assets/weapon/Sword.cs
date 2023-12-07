using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using System.Security.Cryptography;
using UnityEngine;

public class Sword : MonoBehaviour
{
    GameObject player;

    //�v���C���[�̍��W
    Vector3 playerLocalPos;
    //�v���C���[��transform���擾�p
    Transform playerTransform;

    //�G�̊�b�\��
    tutoEnemyState EHp;

    //�v���C���[�ɓ����������ǂ���
    bool isHitFlag = false;

    //�����O�̌��̍��W
    Vector3 swordPos;
    //������̌��̍��W
    Vector3 eqipPos;
    //���̈ړ����x
    float speed;
    float updownSpeed;

    int time = 0;
    //���̏㏸����
    int timeMax1 = 40;
    //���̉��~����
    int timeMax2 = 80;

    //�e�I�u�W�F�N�g�ɂ���I�u�W�F�N�g��
    public GameObject RootObject;

   
    

    int swordAt;

    //�����蔻��
    BoxCollider col;
    public float count = 0.0f;
    bool colFlag = false;

    int StopTime=0;
    bool eneSto;

    int collCoolTime ;
    bool CoolTimeFlag=false;


    // Start is called before the first frame update
    void Start()
    {
        //"player"��T��
        //player = GameObject.Find("Player");
        player = GameObject.Find("unitychan");
        //��������O�̌��̍��W���w��
        swordPos = new Vector3(0.0f, 1.0f, 3.0f);

        //����������̌��̍��W���w��
        //eqipPos = new Vector3(0.3f, 1.0f, 0.0f);
        eqipPos = new Vector3(-0.019f, -0.808f, 0.017f);

        updownSpeed = 0.0005f;

        //���̈ړ����x
        speed = 0.0025f;

        swordAt = 30;

        //�v���C���[��transform���擾
        playerTransform = player.transform;

        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //�v���C���[�ɓ�����O�̏���
        if (!isHitFlag)
        {
            if (time <= timeMax1)
            {
                //speed�̍Đݒ�
                if (time == 0)
                {
                    speed = 0.004f;
                }
                //������Ɉړ�
                swordPos.y += speed;
                //�ړ����x�����炷
                speed -= updownSpeed;
                time++;
                //���̍��W�ݒ�
                transform.position = swordPos;
            }
            else if (time <= timeMax2)
            {
                //speed�̍Đݒ�

                if (time == timeMax1 + 1)
                {
                    speed = 0.004f;
                }
                //�������Ɉړ�
                swordPos.y -= speed;
                //�ړ����x�����炷
                speed -= updownSpeed;
                time++;
                //���̍��W�ݒ�
                transform.position = swordPos;
            }
            else
            {
                time = 0;
            }
        }

        //�����蔻��i������
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

        if (eneSto)
        {
            StopTime++;
        }
        if (StopTime >= 7)
        {
            Time.timeScale = 1;
            StopTime = 0;
            eneSto = false;
        }
        
        collCoolTime++;
        
    }

    

    void OnTriggerEnter(Collider collision) // �����蔻����@�m
    {

        Debug.Log("aiaiaiai");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("aiaiaiai");
            EHp = collision.GetComponent<tutoEnemyState>();
            EHp.HpMove -= swordAt;
            CoolTimeFlag = true;
            if(collCoolTime>=45)
            {
                HitStop();
                collCoolTime = 0;
                CoolTimeFlag = false;
            }
            


        }

        if (collision.gameObject.tag == "Player")
        {

            
            //�v���C���[�ɓ�������(���̓���������)
            isHitFlag = true;
            //�����v���C���[�̎q�I�u�W�F�N�g�ɂ���
            this.gameObject.transform.parent = RootObject.gameObject.transform;

            //���[���h���W����ɁA��]���擾
            Vector3 localAngle = playerTransform.localEulerAngles;
            //Rotation��0��(���Ƃ���90�ɐݒ肵�Ĕz�u���Ă���)
            localAngle.y = 0.0f;
            //Rotation��ݒ�
            transform.localEulerAngles = localAngle;

            playerLocalPos.x = 0.0f;
            playerLocalPos.y = 0.0f;
            playerLocalPos.z = 0.0f;
            //���𑕔��������̌��̈ʒu�Ɉړ������邽�߂̍��W�𑫂�
            playerLocalPos += eqipPos;
            //���̑�����̍��W��ݒ�
            transform.localPosition = playerLocalPos;

            ////�����蔻��폜
            //col.enabled = false;

        }

  
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("aiaiaiai");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("aiaiaiai");

            EHp = collision.gameObject.GetComponent<tutoEnemyState>();
            EHp.HpMove -= swordAt;
            CoolTimeFlag = true;
            if (collCoolTime >= 45)
            {
                HitStop();
                collCoolTime = 0;
                CoolTimeFlag = false;
            }


        }
    }

    public int At
    {
        get { return swordAt; }
    }

    public void HitStop()
    {
        Time.timeScale = 0;
        eneSto = true;
    }
}