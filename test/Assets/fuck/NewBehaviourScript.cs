using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 v3BasePosition = new Vector3(-341, 0, -306);
    private Vector3 v3Position;
    private Vector3 v3Velocity;
    private float fGravity = -0.003f;

    // Start is called before the first frame update
    void Start()
    {

        float fRand_r, fRand_Angle;
        v3Position = v3BasePosition;                    // �ʒu��������
        fRand_r = Mathf.Sqrt(-2.0f * Mathf.Log(Random.Range(0.0f, 0.25f)));    // ��-2ln(a)
        fRand_Angle = Random.Range(0.0f, 2.0f * Mathf.PI);				// 2��b
        v3Velocity = new Vector3(0.5f * fRand_r * Mathf.Cos(fRand_Angle)/2, 1.0f,
                                 0.2f * fRand_r * Mathf.Sin(fRand_Angle)/2);  // ���x��������
        transform.position = v3Position;
    }

    // Update is called once per frame
    void Update()
    {
        v3Position += v3Velocity;                       // �ʒu�ɑ��x�𑫂�
        v3Velocity.y += fGravity/2;                       // ���x�ɉ����x�𑫂�

        if (v3Position.y < 0.0f)                       // �n�ʂɗ�������
        {
            Destroy(gameObject);
        }

        transform.position = v3Position;
    }
}
