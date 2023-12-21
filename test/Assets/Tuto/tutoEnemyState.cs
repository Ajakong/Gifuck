using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoEnemyState : MonoBehaviour
{
    
    public int Hp = 2000;

    public int attack = 5;

    public GameObject Item;
    GameObject Drop;

    tutoUniState state;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Hp);
        //transform.position = transform.position;
        //Ž€‚ñ‚¾
        if (Hp <= 0)
        {
            
            Hp = 500;
            Drop.transform.position = transform.position;
            transform.position = new Vector3(0,2,10);
            //itemDrop‚·‚éƒiƒŠ
            Drop = Instantiate(Item);
           
            
        }
        
    }
    public int HpMove
    {
        get { return Hp; }
        set { Hp = value; }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            state = collision.gameObject.GetComponent<tutoUniState>();
            state.UniHpMove -= attack;
        }
    }
}
