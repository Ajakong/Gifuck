using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCon : MonoBehaviour
{
    float speed=0.00001f;

    int awakeCount;

    int playerCount;

    Rigidbody myRb;

    Vector3 DropUp;

    //�e�I�u�W�F�N�g�ɂ���I�u�W�F�N�g��
    GameObject oyaObj;

    public GameObject SwordInfo;

    GameObject sword2;

    GameObject scoreCounter;
    public ScoreCount Score;

    public GameObject sword;


    private void Awake()
    {
        awakeCount++;
        playerCount=awakeCount;
        scoreCounter = GameObject.Find("scoreCounter");
        Score = scoreCounter.GetComponent<ScoreCount>();
        sword = GameObject.Find("ObjSword");

    }
    // Start is called before the first frame update
    void Start()
    {
       
        DropUp =new Vector3(0,3f,0);
        //myRb.AddForce(DropUp,ForceMode.Impulse);
        transform.position += DropUp; 
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        speed *= 2.0f;

        Vector3 targetPos = GameObject.Find("unitychan").transform.position; //�v���C���[�̈ʒu���擾�AtargetPos�ɑ��
        Vector3 startPos = transform.position;//�G�l�~�[�̈ʒu���擾�AstartPos�ɑ��
        
        transform.position = Vector3.Lerp(startPos, targetPos, speed);//��_�Ԃ𖄂߂�悤��speed�̑����ňړ�
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            
            Score.scoreMove += 100;
            sword.GetComponent<Sword>().At += 1;

            Destroy(this.gameObject);
        }


    }
   
}
