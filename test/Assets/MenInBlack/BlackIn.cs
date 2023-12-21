using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BlackIn : MonoBehaviour
{


   
    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha=100;           //パネルのalpha値取得変数

    private bool fadeIn;          //フェードアウトのフラグ変数

    public int SceneNo;            //シーンの移動先ナンバー取得変数


    // Use this for initialization
    void Start()
    {
       
        fadealpha = this.gameObject.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        fadeIn = true;                             //シーン読み込み時にフェードインさせる
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fadeIn == true)
        {
            FadeIn();
        }
    }

    void FadeIn()
    {
        alpha -= 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadeIn = false;
        }
    }


}