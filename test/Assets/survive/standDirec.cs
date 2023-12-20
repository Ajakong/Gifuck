using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class standDirec : MonoBehaviour
{
    public GameObject Boss;
    public GameObject sun;
    public GameObject demonsSun;

    bool MoveWorld=false;
    int MoveWorldInterval=0;

    // Start is called before the first frame update
    void Start()
    {
        Boss.SetActive(false);
        demonsSun.SetActive(false);
        sun.SetActive(true);
    }

    // Update is called once per frame

    private void Update()
    {
        if (MoveWorldInterval>=50)
        {
            sun.SetActive(false);

        }
        if (MoveWorldInterval>=60)
        {
            demonsSun.SetActive(true);
            Boss.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        if (MoveWorld == true)
        {
            MoveWorldInterval++;
        }
        
    }

    

    void OnTriggerStay(Collider collision) // “–‚½‚è”»’è‚ğ@’m
    {
        if(collision.gameObject.tag=="spirit")
        {
            Debug.Log("°‚ÌŒŸ’m");
            MoveWorld = true;

        }
    }
}
