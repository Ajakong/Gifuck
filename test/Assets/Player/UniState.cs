using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UniState : MonoBehaviour
{
    public int HealItem = 3;

    int UniHp = 100;

    public GameObject healLight;
    bool healFlag = false;
    int lightTimer;

    public int power=0;

    GameObject hpBar;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        healLight.SetActive(false);
        hpBar = GameObject.Find("playerHP");
        slider = hpBar.GetComponent<Slider>();
        slider.value = 0;
        power = 30;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = UniHp;

        if (UniHp <= 0)
        {
            UniHp = 0;
            //ですエフェクト
            SceneManager.LoadScene("GameOver");
        }

        //if (Input.GetKeyUp(KeyCode.H))
        //{


        //}

        if (healFlag == true)
        {
            lightTimer++;
            healLight.SetActive(true);
            if (lightTimer >= 150)
            {
                healFlag = false;
                lightTimer = 0;
                healLight.SetActive(false);
            }
        }
    }

    public int UniHpMove
    {
        get { return UniHp; }
        set { UniHp = value; }
    }

    public int HealNum
    {
        get { return HealItem; }
    }

    public int powerNum
    {
        get { return power; }
    }
    public void Heal(InputAction.CallbackContext context)
    {
        if (HealItem >= 1)
        {
            if (UniHp < 100)
            {
                UniHp += 60;
                HealItem--;
                healFlag = true;
            }
            else
            {
                Debug.Log("HPがマンタンDEATH！");
            }

        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "item")
        {
            Debug.Log("powerUp");
            if (power <= 80)
            {  
                power++;
            }
            Destroy(hit.gameObject);
        }
    }
}
