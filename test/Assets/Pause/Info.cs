using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{


    public GameObject info;

    bool backFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(backFlag);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (backFlag == false)
            {

                backFlag = true;
                info.SetActive(true);


            }
            else
            {

                backFlag = false;
                info.SetActive(false);


            }

        }


        //ƒoƒO’¼‚µ—p
        if (Input.GetKeyDown(KeyCode.P))
        {
            backFlag= false;
        }
    }
}
