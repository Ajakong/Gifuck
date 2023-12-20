using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject pauseIma;
    public GameObject menuIma;
    public GameObject Info;

    bool pause = false;
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
        //pauseIma.SetActive(pause);

        //menuIma.SetActive(pause);
        
       





    }

    public void Pausing(InputAction.CallbackContext context)
    {
            
        if(pauseIma.activeSelf==true)
        {
            pauseIma.SetActive (false);
            pause = false;
            backFlag = false;
            Info.SetActive(false);

            Time.timeScale = 1;
        }
        else if(pauseIma.activeSelf==false)
        {
            pause = true;
            backFlag = true;
            pauseIma.SetActive(true);

            Time.timeScale = 0;

        }


    }
}
