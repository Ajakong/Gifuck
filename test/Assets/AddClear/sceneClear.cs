using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class sceneClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         
        }
    }

    public void toNext(InputAction.CallbackContext context)
    {
        Debug.Log("panpanpanpanpanpan");
        SceneManager.LoadScene("TitleProt");
    }
}
