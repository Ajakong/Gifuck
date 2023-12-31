using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tutoCanvasManager : MonoBehaviour
{
    public GameObject HpbarInfo;
    public GameObject HpbarLowInfo;
    public GameObject PotionInfo;
    public GameObject TimerInfo;
    public GameObject ButtonInfo;

    public GameObject unitychan;

    PHpDecCount HpCount;

    int UIManageCounter=0;

    int timer = 0;

    int playerHp;

    bool lowHpFlag=false;

    Vector3 scale;


    RectTransform trans;

    // Start is called before the first frame update
    void Start()
    {
        HpbarInfo.SetActive(false);
        HpbarLowInfo.SetActive(false);
        PotionInfo.SetActive(false);
        TimerInfo.SetActive(false);
        ButtonInfo.SetActive(false);
        
        HpCount=unitychan.GetComponent<PHpDecCount>();


        scale = new Vector3(0.25f, 0.25f, 1);
        trans=ButtonInfo.GetComponent<RectTransform>();    
    }

    // Update is called once per frame
    void Update()
    {
        playerHp = HpCount.HpCounting;
       

        if(UIManageCounter==0&&timer>=100)
        {
            HpbarInfo.SetActive(true);
        }
        if(UIManageCounter == 1 && timer >= 100&&playerHp >=2)
        {
            HpbarLowInfo.SetActive(true);
            lowHpFlag=true;
        }
        if (UIManageCounter == 2 && timer >= 100&&lowHpFlag==true)
        {
            PotionInfo.SetActive(true);
        }
        if (UIManageCounter == 3 && timer >= 100)
        {
            TimerInfo.SetActive(true);
        }
        if (UIManageCounter == 4)
        {
            ButtonInfo.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        
        timer++;
    }

    public void ToNext(InputAction.CallbackContext context)
    {
        if(UIManageCounter==0&& timer >= 100)
        {
            HpbarInfo.SetActive(false);
            timer = 0;
            UIManageCounter++;
            Time.timeScale = 1.0f;
        }
        if(UIManageCounter == 1 && timer >= 100 && playerHp >= 2)
        {
            HpbarLowInfo.SetActive(false);
            timer = 0;
            UIManageCounter++;
            Time.timeScale = 1.0f;
        }
        if (UIManageCounter == 2&& timer >= 100 && lowHpFlag == true)
        {
            PotionInfo.SetActive(false);
            timer = 0;
            UIManageCounter++;
            Time.timeScale = 1.0f;
        }
        if (UIManageCounter == 3&& timer >= 100)
        {
            TimerInfo.SetActive(false);
            timer = 0;
            UIManageCounter++;
            Time.timeScale = 1.0f;
        }
        if(UIManageCounter==4 && timer >= 100)
        {
           
            ButtonInfo.transform.localScale = scale;
            trans.anchoredPosition = new Vector3(-242, 484, 1);

        }
    }
}