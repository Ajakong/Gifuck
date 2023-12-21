using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoEneDirec : MonoBehaviour
{
    
    GameObject LightningBullet;

    float moveSpeed;//�G���v���C���[�ɋ߂Â����x
    float MaxSpeed = 0.01f;


    float timeCounter;
    float speedUpInterval = 10;
    int speedUpCounter = 1;

    bool playerChase;

    Vector3 collisionImpact;
    Vector3 Shoot;

    theWorldTime time;

    GameObject world;

    Rigidbody myRb;

  

    // Start is called before the first frame update
    void Awake()
    {
       

        myRb = GetComponent<Rigidbody>();

       
        

    }

    // Update is called once per frame

    private void Update()
    {
        collisionImpact = myRb.velocity;
        collisionImpact.y = collisionImpact.x;
        Vector3 targetPos = GameObject.Find("unitychan").transform.position;//player��������
        Quaternion targetRot = Quaternion.LookRotation(targetPos);//LookRoatation�ňړ��x�N�g���ɉ�]�����̂�targetRot�ɑ��
        targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
        targetRot.x = 0;//����
        this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

        

        
    }
    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position; //�v���C���[�̈ʒu���擾�AtargetPos�ɑ��
        Vector3 startPos = transform.position;//�G�l�~�[�̈ʒu���擾�AstartPos�ɑ��

        if (playerChase == true)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, MaxSpeed);//��_�Ԃ𖄂߂�悤��speed�̑����ňړ�
        }
    }

    void OnTriggerStay(Collider collision) // �����蔻����@�m
    {
        if (collision.gameObject.tag == "Player")
        {
            playerChase = true;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerChase = false;
        }
    }
}
