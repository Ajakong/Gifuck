using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLisner : MonoBehaviour
{
    public GameObject stand;
    AudioSource Bgm;
    Vector3 Range;
    // Start is called before the first frame update
    void Start()
    {
        Bgm= GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Range.x = stand.transform.position.x - transform.position.x;
        Range.z = stand.transform.position.z - transform.position.z;
        Range.y = 0;
        if (stand.activeSelf == false)
        {
            Range.x = 1000;
        }

        if (Mathf.Sqrt(Range.x*Range.x+Range.z*Range.z)<=200)
        {
            Bgm.volume-=0.01f;
        }
        if (Mathf.Sqrt(Range.x * Range.x + Range.z * Range.z) >= 200)
        {
            Bgm.volume += 0.01f;
        }
        
    }
}
