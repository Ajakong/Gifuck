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
        targetPos = GameObject.Find("unitychan").transform.position;//player��������
        targetRot = Quaternion.LookRotation(targetPos);//LookRoatation�ňړ��x�N�g���ɉ�]�����̂�targetRot�ɑ��
        targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
        targetRot.x = 0;//����
        this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

    }

    private void FixedUpdate()
    {
        
       
        Vector3 startPos = transform.position;//�G�l�~�[�̈ʒu���擾�AstartPos�ɑ��

        toPlayer.x=targetPos.x - transform.position.x;
        toPlayer.y=targetPos.y - transform.position.y;
        toPlayer.z=targetPos.z - transform.position.z;

       
        
        toPlayer.Normalize();



        transform.position+=toPlayer;
    }

    void OnTriggerEnter(Collider collision) // �����蔻����@�m
    {
        Debug.Log("Destroy");
        if(collision.gameObject.tag=="Player")
        {
            state = collision.gameObject.GetComponent<UniState>();
            state.UniHpMove -= 5;
        }
        Destroy(gameObject);
    }
}
