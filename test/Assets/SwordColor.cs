using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordColor : MonoBehaviour
{
    int m_count;

    int colorR;
    int colorG;
    int colorB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_count>=60)
        {
            colorR=Random.Range(0,255);
            colorG=Random.Range(0,255);
            colorB=Random.Range(0,255);
            GetComponent<Renderer>().material.color = new Color32((byte)colorR, (byte)colorG, (byte)colorB, 1);
        }
    }

    private void FixedUpdate()
    {
        m_count++;
    }
}
