using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 v3BasePosition = new Vector3(2.780838f, 46.5f, 8.498985f);
    private Vector3 v3Position;
    private Vector3 v3Velocity;
    private float fGravity = -0.003f;

    // Start is called before the first frame update
    void Start()
    {

        float fRand_r, fRand_Angle;
        v3Position = v3BasePosition;                    // 位置を初期化
        fRand_r = Mathf.Sqrt(-2.0f * Mathf.Log(Random.Range(0.0f, 1.0f)));    // √-2ln(a)
        fRand_Angle = Random.Range(0.0f, 2.0f * Mathf.PI);				// 2πb
        v3Velocity = new Vector3(0.5f * fRand_r * Mathf.Cos(fRand_Angle), 1.5f,
                                 0.2f * fRand_r * Mathf.Sin(fRand_Angle));  // 速度を初期化
        transform.position = v3Position;
    }

    // Update is called once per frame
    void Update()
    {
        v3Position += v3Velocity;                       // 位置に速度を足す
        v3Velocity.y += fGravity;                       // 速度に加速度を足す

        if (v3Position.y < 0.0f)                       // 地面に落ちたか
        {
            Destroy(gameObject);
        }

        transform.position = v3Position;
    }
}
