
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Diagnostics;
using System.Collections.Specialized;

public class tutoPauseSelect : MonoBehaviour
{
    public AudioSource select;
    public AudioSource selectChoise;

    public GameObject Continue;
   
    public GameObject toTitle;

    Vector3 startFirstTextSize;
    Vector3 startSecondTextSize;

    public bool firstFlag = true;
    public bool secondFlag = false;



    int isSelect = 0;

    Vector2 axis = Vector2.zero;

    int choise = 0;

    bool selectFlag = false;
    bool choiseInter = false;

    public GameObject pause;
    



    // Start is called before the first frame update
    void Awake()
    {

        //panelのコントロール
        Continue.SetActive(false);
        
        toTitle.SetActive(false);

        
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


        if (axis == Vector2.zero)
        {
            UnityEngine.Debug.Log(axis.y);
            firstFlag = true;
            //secondFlag = false;
        }

        if (axis.y >= 0.6f && selectFlag == false)
        {
            if (choiseInter == false)
            {
                select.Play();
                choise--;
            }
            choiseInter = true;
        }
        if (axis.y <= -0.6f && selectFlag == false)
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

        if (choise % 2 == 0)
        {
            isSelect = 0;
            Continue.SetActive(true);
            
            toTitle.SetActive(false);
        }
        if (choise % 2 == 1)
        {
            isSelect = 1;
            Continue.SetActive(false);
           
            toTitle.SetActive(true);
        }
        
        //if (firstFlag)
        //{
        //    if (isToGame)
        //    {
        //        UnityEngine.Debug.Log("強制終了1");
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
        //        UnityEngine.Debug.Log("強制終了2");
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


        //selectChoise.Play();
        if (selectFlag == true)
        {
            selectFlag = false;
           
        }
        else
        {
            if (isSelect == 0)
            {
                //初期化
                
                choise = 0;

                this.gameObject.SetActive(false);
            }
            else if (isSelect == 1)
            {
                
           
                SceneManager.LoadScene("TitleProt");
            }
        }

    }

    public void Pausing(InputAction.CallbackContext context)
    {
        if (this.gameObject.activeSelf == true)
        {
            choise = 0;
            selectFlag = false;

        }

        else if (this.gameObject.activeSelf == false)
        {



        }


    }

    void TextSizeChange(GameObject big, GameObject small)
    {
        big.transform.localScale = big.transform.localScale * 1.6f;
        small.transform.localScale = small.transform.localScale / 1.6f;
    }

}
