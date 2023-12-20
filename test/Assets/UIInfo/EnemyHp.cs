using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHp : MonoBehaviour
{
    int Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Atk : " + Hp.ToString("00");

    }
    public int HpMove
    {
        get { return Hp; }
        set { Hp = value; }
    }
}
