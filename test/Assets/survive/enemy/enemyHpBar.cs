using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHpBar : MonoBehaviour
{
    public GameObject enemy;

    EnemyState state;

    GameObject camera;

    Vector3 localScale;
    Vector3 position;

    float barLongX;
    float barPosX;

    float test;
    // Start is called before the first frame updte
    void Start()
    {
        state = enemy.GetComponent<EnemyState>();

        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

        /*enemyÇÃHPÇ∆HPÉoÅ[Ç™òAìÆÇ∑ÇÈÇÊÇ§Ç…*/
        barLongX = (state.Hp * 0.02f);
        localScale = transform.localScale;
        localScale.x = barLongX;
        transform.localScale = localScale;



        this.transform.rotation = camera.transform.rotation;
    }
}
