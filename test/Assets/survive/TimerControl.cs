using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{
    //float countTimer = 0;
    float countSecond = 0.49f;
    int countMinute = 1;
    // Start is called before the first frame update
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {
        countSecond -= Time.deltaTime;
        //countTimer -= Time.deltaTime;
        ////countTimer‚ð60‚ÅŠ„‚Á‚½‚à‚Ì‚ð•ª‚É“ü‚ê‚é‚±‚Æ‚Åint‚È‚Ì‚Å
        //countMinute = (int)(countTimer / 60f);

        //countSecond = (60f % countTimer);

        if (countSecond < -0.5000f)
        {
            countSecond = 59.49999f;
            countMinute += -1;
        }
        if (countMinute <= 0 && countSecond <= 0)
        {
            countSecond = 0;
            countMinute = 0;
            SceneManager.LoadScene("AddClear");
        }

        GetComponent<Text>().text = countMinute.ToString("00") + ":" + countSecond.ToString("00");
        //Debug.Log(countSecond +" : "+ GetComponent<Text>().text);
    }
}

