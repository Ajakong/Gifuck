using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItem : MonoBehaviour
{
    float speed = 0.00001f;

    int awakeCount;

    int playerCount;

    Rigidbody myRb;

    Vector3 DropUp;

    //�e�I�u�W�F�N�g�ɂ���I�u�W�F�N�g��
    GameObject oyaObj;

    GameObject SwordInfo;
    

    GameObject Player;

    GameObject scoreCounter;
    ScoreCount Score;


    private void Awake()
    {
        awakeCount++;
        playerCount = awakeCount;
        scoreCounter = GameObject.Find("scoreCounter");
        Score = scoreCounter.GetComponent<ScoreCount>();

        SwordInfo = GameObject.Find("ObjSword");
        Player = GameObject.Find("unitychan");
    }
    // Start is called before the first frame update
    void Start()
    {

        DropUp = new Vector3(0, 3f, 0);
        //myRb.AddForce(DropUp,ForceMode.Impulse);
        transform.position += DropUp;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        speed *= 1.2f;

        Vector3 targetPos =Player.transform.position; //�v���C���[�̈ʒu���擾�AtargetPos�ɑ��
        Vector3 startPos = transform.position;//�G�l�~�[�̈ʒu���擾�AstartPos�ɑ��

        transform.position = Vector3.Lerp(startPos, targetPos, speed);//��_�Ԃ𖄂߂�悤��speed�̑����ňړ�

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SwordInfo.AddComponent<SwordColor>();

            Score.scoreMove += 2000;
           SwordInfo.GetComponent<Sword>().At += 30;

            Destroy(this.gameObject);
        }


    }

}
