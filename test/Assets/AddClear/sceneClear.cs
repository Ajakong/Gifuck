using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Diagnostics;
using System.Collections.Specialized;

public class sceneClear : MonoBehaviour
{

    public GameObject endRoll;
    public GameObject staffRoll;
    public GameObject toTitle;

    Vector3 startFirstTextSize;
    Vector3 startSecondTextSize;

    public bool firstFlag = true;
    public bool secondFlag = false;



    int isToGame = 0;

    Vector2 axis = Vector2.zero;

    int choise = 0;

    bool choiseInter = false;



    // Start is called before the first frame update
    void Awake()
    {

        endRoll.SetActive(true);
        toTitle.SetActive(false);
        staffRoll.SetActive(false);

        
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

        if (axis.y >= 0.9f)
        {
            if (choiseInter == false)
            {
               
                choise--;
            }
            choiseInter = true;
        }
        if (axis.y <= -0.9f)
        {
            if (choiseInter == false)
            {
                
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
            isToGame = 0;
            endRoll.SetActive(true);
            toTitle.SetActive(false);
           
        }
        if (choise % 2 == 1 || choise % 3 == -1)
        {
            isToGame = 1;
            endRoll.SetActive(false);
            toTitle.SetActive(true);
            
        }
        

        //if (firstFlag)
        //{
        //    if (isToGame)
        //    {
        //        UnityEngine.Debug.Log("‹­§I—¹1");
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
        //        UnityEngine.Debug.Log("‹­§I—¹2");
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
       
        if (isToGame == 0)
        {
            if(staffRoll.activeSelf)
            {
                staffRoll.SetActive(false);
            }
            else 
            {
                staffRoll.SetActive(true);

            }
            //SceneManager.LoadScene("SampleScene");

        }
        else if (isToGame == 1)
        {
            
            SceneManager.LoadScene("TitleProt");
        }
        
    }


    void TextSizeChange(GameObject big, GameObject small)
    {
        big.transform.localScale = big.transform.localScale * 1.6f;
        small.transform.localScale = small.transform.localScale / 1.6f;
    }

}
