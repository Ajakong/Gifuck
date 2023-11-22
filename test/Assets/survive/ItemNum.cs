using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemNum : MonoBehaviour
{
    public GameObject HealPotion;

    UniState Heal;

    int Num;

    // Start is called before the first frame update
    void Start()
    {

        Heal = HealPotion.GetComponent<UniState>();
    }

    // Update is called once per frame
    void Update()
    {

       
        Num = Heal.HealNum;

        GetComponent<Text>().text =  "Å~" + Num.ToString("00");
    }
}
