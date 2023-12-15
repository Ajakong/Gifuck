using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneTentaMove : MonoBehaviour
{
    //�ϐ��Ə����l�̍쐬
    Quaternion qInitialRot;
    public int nDepth = 0;
    public Vector3 v3BasePos = new Vector3(0.0f, 2.0f, 0.0f);

    bool stanFlag=false;

    int stanCount=0;


    // Use this for initialization
    void Start()
    {
        //���݂̉�]�x����
        qInitialRot = transform.rotation;
        //�F�̔Z���̐ݒ�
        float fBright = (20.0f - (float)nDepth) / 20.0f;
        //�F�����쐬
        GetComponent<Renderer>().material.color = new Color(0.9f + fBright * 0.1f, fBright, 0.7f + fBright * 0.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�e�I�u�W�F�N�g�����݂��Ă���Ƃ��������s
        if (transform.parent)
        {
            //���݂̐[�x�����]�x�����쐬
            float fPosAngle = nDepth * 2.0f * Mathf.PI / 25.0f *
                              Mathf.Sin(2.0f * Mathf.PI * ((Time.time / 6.0f) % 1));
            //��]���̐ݒ�
            Vector3 v3RotAxis = new Vector3(-0.6f, -0.5f, 0.3f);
            //��L�ō쐬������]������ɉ�]�ʂ�\���N�I�[�^�j�I�����쐬
            Quaternion qRot = Quaternion.AngleAxis(fPosAngle * 360.0f / (2.0f * Mathf.PI), v3RotAxis);
            //���W�ɃN�H�[�^�j�I�����|���āA��]��̍��W���쐬
            Vector3 v3RelPos = qRot * v3BasePos;
            //���݂̍��W�̍X�V(��L�܂łō�����̂́A�e�̈ʒu����ǂꂾ���Y���Ă邩�̍��W)
            transform.position = transform.parent.position + v3RelPos;
            //�e�𐳖ʂɑ�����ׂ���]
            transform.LookAt(transform.parent.position, new Vector3(0.0f, 1.0f, 0.0f));
        }

        if (stanFlag == true)
        {
            stanCount++;
        }
    }

    void OnTriggerEnter(Collider collision) // �����蔻����@�m
    {
        if(collision.gameObject.tag=="Player")
        {
            stanFlag = true;
            if(stanCount<=16)
            {
                collision.gameObject.transform.position = collision.gameObject.transform.position;
            }
        }
    }
}
