using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHp : MonoBehaviour
{
    int Hp;
    EnemyHpCatch Info;
    public GameObject eneDfe;
    // Start is called before the first frame update
    void Start()
    {
        Info=eneDfe.GetComponent<EnemyHpCatch>();
    }

    // Update is called once per frame
    void Update()
    {
        Hp = Info.HpMove;
        GetComponent<Text>().text = "Hp : " + Hp.ToString("00");

    }
    
}
