using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EneRes : MonoBehaviour
{
    GameObject enemy;
    public GameObject EnemyPre;
    //���X�|�[���̃C���^�[�o��
    private float interval;

    //1000f�̂Ƃ�ene����l�X�|�[������i��
    private float reS = 1000f;



    float RandX = 0;
    float RandZ = 0;

    //���Ԍo�߂��Ƃ�ene�̏o�����x�𑁂����邽�߂ɕK�v�Ȋ֐��i���A�����reS�ɂ�����
    float timeGrow = 1.05f;
    // Start is called before the first frame update
    void Start()
    {
        interval = 1000f;
    }



    // Update is called once per frame
    void Update()
    {
        


        //���������X�|�[������
        if (reS >= interval)
        {
            reS = 1;
            enemy = Instantiate(EnemyPre);
            enemy.transform.position = new Vector3(transform.position.x+RandX, 10, transform.position.z+RandZ);
            
        }

        //�������A�吺���o���Ȃ���player�̋߂��ɃX�|�[��������i��
        RandX = Random.Range(-30, 30);
        RandZ = Random.Range(-30, 30);
    }

    private void FixedUpdate()
    {
        reS *= timeGrow;
    }
}