using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    Slider slider;
    CanvasGroup canvasGroup;

    bool appFlag = true;

    bool deleteFlag = false;
    public int count = 0;

    //GameObject obj = GameObject.Find("Boss");
    //Boss1State state;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0.005)
        {
            deleteFlag = true;
        }
    }

    private void FixedUpdate()
    {
        if (deleteFlag)
        {
            count++;
            if (count > 100)
            {
                canvasGroup.alpha -= 0.1f;
            }
        }

        if (canvasGroup.alpha <= 1 && appFlag)
        {
            slider.value += 0.01f;
            canvasGroup.alpha += 0.01f;

            if(slider.value == 1)
            {
                appFlag = false;
            }
        }


    }
}
