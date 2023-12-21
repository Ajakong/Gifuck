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

    GameObject world;

    public GameObject Item;

   
    GameObject Drop;

    public GameObject Die;
    GameObject DieEffect;

    UniState state;

    theWorldTime time;

    KillEneCountCatch count;
    GameObject counter;

    EnemyHpCatch EneHp;
    GameObject EneHpUI;

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("world");
        time=world.GetComponent<theWorldTime>();
        Hp = maxHp;
        counter = GameObject.Find("EneKillingCount");
        count=counter.GetComponent<KillEneCountCatch>();
        EneHpUI = GameObject.Find("EneDFE");
        EneHp=EneHpUI.GetComponent<EnemyHpCatch>();
        
    }

    // Update is called once per frame
    void Update()
    {
        worldTime=time.timeMove;

        //transform.position = transform.position;
        //����
        if (Hp < 1)
        {
            count.KillMove += 1;
            DieEffect=Instantiate(Die);
            DieEffect.transform.position = transform.position;

            Destroy(this.gameObject);
            //itemDrop����i��
            Drop = Instantiate(Item);
            Drop.transform.position = transform.position;
            Destroy(gameObject);
        }
        
        if(worldTime>=powerUpInterval*powerUpCount)
        {
            maxHp += 20 ;
            powerUpCount++;
            EneHp.HpMove = maxHp;
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
