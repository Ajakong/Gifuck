using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1State : MonoBehaviour
{
    public int maxHp = 1;
    public int Hp = 1;

    public GameObject Item;
    GameObject Drop;

    GameObject hpBar;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.Find("BossHp");
        slider = hpBar.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position;
        if (Hp <= 0)
        {
            Destroy(this.gameObject);

            Drop = Instantiate(Item);
            Drop.transform.position = transform.position;
        }

    }



    public int HpMove
    {
        get { return Hp; }
        set { Hp = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("hit");

            slider.value -= 0.2f;
            if(slider.value <= 0.005)
            {
                Hp = 0;
            }
        }
    }
}
