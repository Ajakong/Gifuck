using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlayer : MonoBehaviour
{
    float moveSpeed = 0.01f;//�G���v���C���[�ɋ߂Â����x

    Vector3 _prevPosition;//�O�̃t���[���ʒu
    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        Vector3 targetPos = GameObject.Find("unitychan").transform.position;//player��������
        Quaternion targetRot = Quaternion.LookRotation(targetPos);//LookRoatation�ňړ��x�N�g���ɉ�]�����̂�targetRot�ɑ��
        targetRot.z = 0;//����]�������Ȃ��悤�ɌŒ�
        targetRot.x = 0;//����
        this.transform.rotation = targetRot;//�I�u�W�F�N�g�̊p�x��targetRot�ɂ���
    }
    void FixedUpdate()
    {
        //Vector3 targetPos = GameObject.Find("unitychan").transform.position; //�v���C���[�̈ʒu���擾�AtargetPos�ɑ��
        //Vector3 startPos = transform.position;//�G�l�~�[�̈ʒu���擾�AstartPos�ɑ��

        //transform.position = Vector3.Lerp(startPos, targetPos, moveSpeed);//��_�Ԃ𖄂߂�悤��movespeed�̑����ňړ�
    }
}
