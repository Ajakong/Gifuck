using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{


    public GameObject info;
    public GameObject Map;

    bool backFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(backFlag);
        Map.SetActive(backFlag);
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

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (backFlag == false)
            {

                backFlag = true;
                Map.SetActive(true);


            }
            else
            {

                backFlag = false;
                Map.SetActive(false);


            }

        }

        //ƒoƒO’¼‚µ—p
        if (Input.GetKeyDown(KeyCode.P))
        {
            backFlag= false;
        }
    }
}
