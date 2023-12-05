using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tutoCanvasManager : MonoBehaviour
{
    public GameObject HpbarInfo;
    public GameObject PotionInfo;
    public GameObject TimerInfo;

    int UIManageCounter=0;

    int timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        HpbarInfo.SetActive(false);
        PotionInfo.SetActive(false);
        TimerInfo.SetActive(false); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManageCounter==0&&timer>=100)
        {
            HpbarInfo.SetActive(true);
        }
        if (UIManageCounter == 1 && timer >= 100)
        {
            PotionInfo.SetActive(true);
        }
        if (UIManageCounter == 2 && timer >= 100)
        {
            TimerInfo.SetActive(true);
        }

        Debug.Log(timer);
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
        if (UIManageCounter == 1&& timer >= 100)
        {
            PotionInfo.SetActive(false);
            timer = 0;
            UIManageCounter++;
            Time.timeScale = 1.0f;
        }
        if (UIManageCounter == 2&& timer >= 100)
        {
            TimerInfo.SetActive(false);
            timer = 0;
            UIManageCounter++;
            Time.timeScale = 1.0f;
        }
    }
}