using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotest : MonoBehaviour
{
    public GameObject Player;


    Vector3 v3InitialPos;                       // �����ʒu
    Quaternion qInitialRot;

    Matrix4x4 matTransform;
    // ������]
    // Start is called before the first frame update
    void Start()
    {
        v3InitialPos = transform.position;
        qInitialRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        v3InitialPos = Player.transform.position;
    }
    void FixedUpdate()
    {
        float fAngle = 2.0f * Mathf.PI * ((Time.time / 10.0f) % 1); // �p�x
        // ��]�̍s��
        matTransform = Matrix4x4.identity;                // �P�ʍs��
        matTransform.m00 = Mathf.Cos(fAngle); matTransform.m02 = Mathf.Sin(fAngle);
        matTransform.m20 = -Mathf.Sin(fAngle); matTransform.m22 = Mathf.Cos(fAngle);

        matTransform.m00 *= v3InitialPos.x; matTransform.m02 *= v3InitialPos.z;
        matTransform.m20 *= v3InitialPos.x; matTransform.m22 *= v3InitialPos.z;

        

        transform.position = matTransform * v3InitialPos;           // �ϊ�
        transform.rotation = qInitialRot;                           // ��]������
        transform.Rotate(0.0f, fAngle * 360.0f / (2.0f * Mathf.PI), 0.0f, Space.World);
        //        transform.Rotate(0, fAngle * Mathf.Rad2Deg, 0, Space.World);
    }

    public Vector3 rotateMove
    {
        get { return transform.forward; }


    }
}
