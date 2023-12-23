using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class standDirec : MonoBehaviour
{
    public GameObject Boss;
    public GameObject sun;
    public GameObject demonsSun;
    public GameObject demon;
    public GameObject gate;

    public GameObject Ui;

    bool MoveWorld=false;
    int MoveWorldInterval=0;

    // Start is called before the first frame update
    void Start()
    {
        Boss.SetActive(false);
        demonsSun.SetActive(false);
        sun.SetActive(true);
      demon.SetActive(false);
        Ui.SetActive(false);
        gate.SetActive(false);
    }

    // Update is called once per frame

    private void Update()
    {
        if (MoveWorldInterval>=50)
        {
            sun.SetActive(false);

        }
        if (MoveWorldInterval>=180)
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

    

    void OnTriggerEnter(Collider collision) // 当たり判定を察知
    {
        if(collision.gameObject.tag=="spirit")
        {
            Debug.Log("魂の検知");
            MoveWorld = true;

        }
    }
}
