using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class PlayerAtk : MonoBehaviour
{
    Sword swordInfo;
    public GameObject sword;

    int SwordAtk;
    // Start is called before the first frame update
    void Start()
    {
        swordInfo = sword.GetComponent<Sword>();
    }

    // Update is called once per frame
    void Update()
    {
        SwordAtk = swordInfo.At;

        GetComponent<Text>().text = "Atk : " + SwordAtk.ToString("00");

    }
}
