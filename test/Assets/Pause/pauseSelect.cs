
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Diagnostics;
using System.Collections.Specialized;

public class pauseSelect : MonoBehaviour
{
    public AudioSource select;
    public AudioSource selectChoise;

    public GameObject Continue;
    public GameObject Info;
    public GameObject secret;
    public GameObject toTitle;

    Vector3 startFirstTextSize;
    Vector3 startSecondTextSize;

    public bool firstFlag = true;
    public bool secondFlag = false;



    int isSelect = 0;

    Vector2 axis = Vector2.zero;

    int choise = 0;

    bool selectFlag=false;
    bool choiseInter = false;

    public GameObject pause;
    public GameObject UniInfo;
    public GameObject topSecret;

    // Start is called before the first frame update
    void Awake()
    {

        //panel�̃R���g���[��
        Continue.SetActive(true);
        Info.SetActive(false);
        secret.SetActive(false);
        toTitle.SetActive(false);

        //Info�̃R���g���[��
        UniInfo.SetActive(false);
        topSecret.SetActive(false);
    }

    public void OnInputStick(InputAction.CallbackContext context)
    {


        axis = context.ReadValue<Vector2>();

        // UnityEngine.Debug.Log(axis.y);


        //if (axis.y > -0.5f)
        //{
        //    UnityEngine.Debug.Log(axis.y);
        //    secondFlag = true;
        //    firstFlag = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {

        UnityEngine.Debug.Log(choise);
        if (axis == Vector2.zero)
        {
            UnityEngine.Debug.Log(axis.y);
            firstFlag = true;
            //secondFlag = false;
        }

        if (axis.y >= 0.6f)
        {
            if (choiseInter == false)
            {
                select.Play();
                choise--;
            }
            choiseInter = true;
        }
        if (axis.y <= -0.6f)
        {
            if (choiseInter == false)
            {
                select.Play();
                choise++;
            }
            choiseInter = true;
        }
        if (Mathf.Abs(axis.y) <= 0.2f)
        {
            choiseInter = false;
        }

        if (choise % 4 == 0)
        {
            isSelect = 0;
            Continue.SetActive(true);
            Info.SetActive(false);
            secret.SetActive(false);
            toTitle.SetActive(false);
        }
        if (choise % 4 == 1||choise%4==-3)
        {
            isSelect = 1;
            Continue.SetActive(false);
            Info.SetActive(true);
            secret.SetActive(false);
            toTitle.SetActive(false);
        }
        if (choise % 4 == 2||choise%4==-2)
        {
            isSelect = 2;
            Continue.SetActive(false);
            Info.SetActive(false);
            secret.SetActive(true);

            toTitle.SetActive(false);
        }
        if (choise % 4 == 3||choise%4==-1)
        {
            isSelect = 3;
            Continue.SetActive(false);
            Info.SetActive(false);
            secret.SetActive(false);
            toTitle.SetActive(true);
        }
        //if (firstFlag)
        //{
        //    if (isToGame)
        //    {
        //        UnityEngine.Debug.Log("�����I��1");
        //       return;
        //    }

        //    TextSizeChange(firstText, secondText);
        //    //secondText.transform.localScale = secondText.transform.localScale / 1.8f;
        //    //firstText.transform.localScale = firstText.transform.localScale * 1.4f;
        //    firstFlag = false;
        //    isToGame = true;
        //}


        //if (secondFlag)
        //{
        //    if (!isToGame)
        //    {
        //        UnityEngine.Debug.Log("�����I��2");
        //        return;
        //    }
        //    TextSizeChange(secondText, firstText);
        //    //firstText.transform.localScale = firstText.transform.localScale / 1.4f;
        //    //secondText.transform.localScale = secondText.transform.localScale * 1.8f;
        //    secondFlag = false;
        //    isToGame = false;
        //}

        //UnityEngine.Debug.Log(firstFlag);
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    //SceneManager.LoadScene("SampleScene");
        //}
    }

    public void ToNext(InputAction.CallbackContext context)
    {

        UnityEngine.Debug.Log("iloveyou");
        selectChoise.Play();
        if(selectFlag==true)
        {
            UniInfo.SetActive(false);
            topSecret.SetActive(false);
        }
        else
        {
            if (isSelect == 0)
            {
                //������
                UniInfo.SetActive(false);
                topSecret.SetActive(false);
                choise = 0;

                this.gameObject.SetActive(false);
            }
            else if (isSelect == 1)
            {
                //info�̕\��
                UniInfo.SetActive(true);
                selectFlag = true;
            }
            else if (isSelect == 2)
            {
                //???�̕\��
                topSecret.SetActive(true);
                selectFlag = true;
            }
            else if (isSelect == 3)
            {
                SceneManager.LoadScene("TitleProt");
            }
        }

    }


    void TextSizeChange(GameObject big, GameObject small)
    {
        big.transform.localScale = big.transform.localScale * 1.6f;
        small.transform.localScale = small.transform.localScale / 1.6f;
    }

}
