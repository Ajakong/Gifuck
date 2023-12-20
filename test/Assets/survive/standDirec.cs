using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class standDirec : MonoBehaviour
{
    public GameObject Boss;

    bool MoveWorld=false;
    int MoveWorldInterval=0;

    // Start is called before the first frame update
    void Start()
    {
        Boss.SetActive(false);
    }

    // Update is called once per frame

    private void Update()
    {
        if(MoveWorldInterval>=60)
        {
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

    

    void OnTriggerStay(Collider collision) // 当たり判定を察知
    {
        if(collision.gameObject.tag=="spirit")
        {
            Debug.Log("魂の検知");
            MoveWorld = true;

        }
    }
}
