using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    Vector3 cameForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameForward=transform.rotation*transform.position.normalized;
    }

    public Vector3 forward
    {
        get { return cameForward; }

    }
    
    
}
