using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public GameObject player;

    UniState state;

    int AttackInterCount=0;

    bool flag=false;
    // Start is called before the first frame update
    void Start()
    {
        state=player.GetComponent<UniState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(flag==true)
        {
            AttackInterCount++;
        }
        if(AttackInterCount>=30)
        {
            flag=false;
            AttackInterCount=0;
        }
    }

    void OnTriggerEnter(Collider collision) // “–‚½‚è”»’è‚ðŽ@’m
    {
        if(flag==false)
        {
            
            if (collision.gameObject == player)
            {
                state.UniHpMove -= 50;


            }

            flag = true;
        }
        
    }
}
