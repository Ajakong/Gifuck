using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseIma;

    bool pause = false;
    bool backFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //pauseIma.SetActive(pause);

        //menuIma.SetActive(pause);


        if (pauseIma.activeSelf == true)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;

        }



    }

    public void Pausing(InputAction.CallbackContext context)
    {
        if(pauseIma.activeSelf==true)
        {
            pauseIma.SetActive(false);
            pause = false;
            backFlag = false;
        }
        else
        {
            pause = true;
            backFlag = true;
            pauseIma.SetActive(true);
        }


    }
}
