using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int maxHp = 100;
    public int Hp = 100;

    public int attack = 5;

    int powerUpCount;

    int powerUpInterval=2;

    float worldTime;

    public GameObject world;

    public GameObject Item;
    GameObject Drop;
    
    UniState state;

    theWorldTime time; 
   

    
    // Start is called before the first frame update
    void Start()
    {
        
        time=world.GetComponent<theWorldTime>();
        Hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        worldTime=time.timeMove;

        //transform.position = transform.position;
        //Ž€‚ñ‚¾
        if (Hp < 1)
        {
           
            Destroy(this.gameObject);
            //itemDrop‚·‚éƒiƒŠ
            Drop = Instantiate(Item);
            Drop.transform.position = transform.position;
            Destroy(gameObject);
        }
        
        if(worldTime>=powerUpInterval*powerUpCount)
        {
            maxHp += 20 ;
            powerUpCount++;
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
           


            state = collision.gameObject.GetComponent<UniState>();
            state.UniHpMove -= attack;
        }
    }
}
