using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BlackIn : MonoBehaviour
{


   
    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha=100;           //�p�l����alpha�l�擾�ϐ�

    private bool fadeIn;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    public int SceneNo;            //�V�[���̈ړ���i���o�[�擾�ϐ�


    // Use this for initialization
    void Start()
    {
       
        fadealpha = this.gameObject.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
        fadeIn = true;                             //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��������
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