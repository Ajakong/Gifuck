using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public GameObject player;

    UniState state;
    // Start is called before the first frame update
    void Start()
    {
        state=player.GetComponent<UniState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision) // “–‚½‚è”»’è‚ðŽ@’m
    {

        if (collision.gameObject==player)
        {
            state.UniHpMove -= 5;


        }
    }
}
