using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCon : MonoBehaviour
{
    Rigidbody myRb;

    Vector3 DropUp;

    //親オブジェクトにするオブジェクト名
    GameObject oyaObj;

    public GameObject SwordInfo;

    GameObject sword2; 
    // Start is called before the first frame update
    void Start()
    {
        oyaObj = GameObject.Find("Character1_RightHandMiddle1");
        DropUp =new Vector3(0,3f,0);
        //myRb.AddForce(DropUp,ForceMode.Impulse);
        transform.position += DropUp; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject sword = GameObject.Find("ObjSword");
            Transform transform = sword.transform;
            sword2 = Instantiate(SwordInfo);
            sword2.gameObject.transform.parent = oyaObj.gameObject.transform;
            sword2.transform.position = transform.position;
            sword2.transform.localEulerAngles = transform.localEulerAngles;
            sword2.transform.localScale = transform.localScale;

            Destroy(sword.gameObject);


            Destroy(this.gameObject);
        }
    }
}
