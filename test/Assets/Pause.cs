using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseIma;
    public GameObject menuIma;

    bool pause=false;
    bool backFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseIma.SetActive(pause);
        menuIma.SetActive(pause);
    }

    // Update is called once per frame
    void Update()
    {
        pauseIma.SetActive(pause);
        menuIma.SetActive(pause);
        //ê‡ñæÇÕïsóvÉiÉä
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (backFlag == false)
            {
                pause = true;
                backFlag = true;

                
                Time.timeScale = 0;
            }
            else
            {
                pause = false;
                backFlag = false;


                Time.timeScale = 1;
            }

            
        }

        
    }
}
