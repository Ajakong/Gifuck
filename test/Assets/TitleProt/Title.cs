using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Diagnostics;
using System.Collections.Specialized;

public class Title : MonoBehaviour
{
    GameObject firstText;
    GameObject secondText;

    Vector3 startFirstTextSize;
    Vector3 startSecondTextSize;

    public bool firstFlag = true;
    public bool secondFlag = false;

    //���̃t���O��true�̂Ƃ��Q�[����
    //false�̂Ƃ��`���[�g���A����
    bool isToGame = false;

    Vector2 axis = Vector2.zero;

    // Start is called before the first frame update
    void Awake()
    {
        firstText = GameObject.Find("GameStart");
        startFirstTextSize = firstText.transform.localScale;
        secondText = GameObject.Find("toTutorial");
        startSecondTextSize = secondText.transform.localScale;
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
        if (isToGame)
        {
            SceneManager.LoadScene("SampleScene");

        }
        else if (!isToGame)
        {
            SceneManager.LoadScene("tutoreal");
        }

    }


    void TextSizeChange(GameObject big, GameObject small)
    {
        big.transform.localScale = big.transform.localScale * 1.6f;
        small.transform.localScale = small.transform.localScale / 1.6f;
    }

}
