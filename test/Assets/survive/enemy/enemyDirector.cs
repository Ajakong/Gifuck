using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDirector : MonoBehaviour
{
    

    float moveSpeed ;//�G���v���C���[�ɋ߂Â����x
    float MaxSpeed = 0.01f;


    float timeCounter;
    float speedUpInterval=10;
    int speedUpCounter=1;

   

    theWorldTime time;

    GameObject world;
    
    // Start is called before the first frame update
    void Awake()
    {
        world = GameObject.Find("world");
        time = world.GetComponent<theWorldTime>();
        moveSpeed = MaxSpeed;
        Debug.Log(moveSpeed);
    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position;//player��������
        Quaternion targetRot = Quaternion.LookRotation(targetPos);//LookRoatation�ňړ��x�N�g���ɉ�]�����̂�targetRot�ɑ��
        targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
        targetRot.x = 0;//����
        this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���

        timeCounter = time.timeMove;
        Debug.Log(MaxSpeed);
        if (timeCounter>=speedUpInterval*speedUpCounter)//����Z���g�p���Ȃ����R��float�Ȃ̂ŏ����w���==���g���Â炭�Ȃ邽��
        {
            
            
            MaxSpeed += 0.002f;
            speedUpCounter++;
            
        }
    }
    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position; //�v���C���[�̈ʒu���擾�AtargetPos�ɑ��
        Vector3 startPos = transform.position;//�G�l�~�[�̈ʒu���擾�AstartPos�ɑ��

        transform.position = Vector3.Lerp(startPos, targetPos, MaxSpeed);//��_�Ԃ𖄂߂�悤��movespeed�̑����ňړ�
    }
}
