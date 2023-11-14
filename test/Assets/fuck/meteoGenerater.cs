using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoGenerater : MonoBehaviour
{
    public GameObject meteoPrefab;
    GameObject go;
    float span = 1.0f;
    float delta = 0;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > 5)
        {
            this.delta = 0;
            go = Instantiate(meteoPrefab);
            
           
            go.transform.position = new Vector3(Random.Range(-22, 117), 2.2f, Random.Range(-100, 72));
        }
    }
}
