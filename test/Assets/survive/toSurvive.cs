using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toSurvive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision) // �����蔻����@�m
    {

        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene("SampleScene");
        }
    }

}

