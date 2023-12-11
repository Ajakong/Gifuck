using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int maxHp = 100;
    public int Hp = 100;

    public int attack = 5;

    public GameObject Item;
    GameObject Drop;
    
    UniState state;

    Vector3 hitVec;
    Vector3 hitVecY;

    Rigidbody velo;
    // Start is called before the first frame update
    void Start()
    {
        hitVecY= new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
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
            hitVec.x=collision.gameObject.transform.position.x - transform.position.x;  
            hitVec.z=collision.gameObject.transform.position.y - transform.position.y;
            hitVec.Normalize();
            transform.position-=hitVec*5;
            
           

            state = collision.gameObject.GetComponent<UniState>();
            state.UniHpMove -= attack;
        }
    }
}
