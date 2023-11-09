using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EneRes : MonoBehaviour
{
    GameObject enemy;
    public GameObject EnemyPre;
    //リスポーンのインターバル
    private float interval;

    //1000fのときeneが一人スポーンするナリ
    private float reS = 1000f;



    float RandX = 0;
    float RandZ = 0;

    //時間経過ごとにeneの出現速度を早くするために必要な関数ナリ、これをreSにかける
    float timeGrow = 1.05f;
    // Start is called before the first frame update
    void Start()
    {
        interval = 1000f;
    }



    // Update is called once per frame
    void Update()
    {
        


        //ここがリスポーン処理
        if (reS >= interval)
        {
            reS = 1;
            enemy = Instantiate(EnemyPre);
            enemy.transform.position = new Vector3(transform.position.x+RandX, 10, transform.position.z+RandZ);
            
        }

        //そうだ、大声を出しながらplayerの近くにスポーンさせるナリ
        RandX = Random.Range(-30, 30);
        RandZ = Random.Range(-30, 30);
    }

    private void FixedUpdate()
    {
        reS *= timeGrow;
    }
}