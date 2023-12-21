using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossZoneTle : MonoBehaviour
{
    public GameObject Player;

    Vector3 BossZonePos;
    // Start is called before the first frame update
    void Start()
    {
        BossZonePos = new Vector3(1500, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision) // “–‚½‚è”»’è‚ðŽ@’m
    {

        if (collision.gameObject.tag == "Player")
        {

            Player.transform.position = BossZonePos;
        }
    }
}
