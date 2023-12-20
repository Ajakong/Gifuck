using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCapsule : MonoBehaviour
{
    public GameObject Item;
    GameObject drop;

    Rigidbody itemRb;
    int HitCount=0;

    Vector3 RandomVel;

    Vector3 dropScale;

    Renderer dropRen;

    int colorR;
    int colorG;
    int colorB;

    // Start is called before the first frame update
    void Start()
    {
        dropScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(HitCount>=3)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            for(int i=0;i<4;i++)
            {
                drop = Instantiate(Item);
                dropRen=drop.GetComponent<Renderer>();
                colorR = Random.Range(0, 255);
                colorG = Random.Range(0, 255);
                colorB = Random.Range(0, 255);
                dropRen.material.color = new Color32((byte)colorR, (byte)colorG, (byte)colorB, 1);

                drop.transform.localScale = dropScale;
                drop.transform.position = transform.position;
                itemRb = drop.GetComponent<Rigidbody>();
                RandomVel = new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), 5f, Random.Range(transform.position.z - 10, transform.position.z + 10));
                itemRb.AddForce(RandomVel);
            }
            HitCount++;





        }
    }

}
