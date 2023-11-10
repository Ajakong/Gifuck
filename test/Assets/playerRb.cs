using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerRb : MonoBehaviour
{
    public GameObject camera;

    Rigidbody myRb;

    Rigidbody cameraRb;

    //cameraRotate cameForWard;

    Vector2 moveInfo;

    Vector3 forWard;

    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        //cameForWard = camera.GetComponent<cameraRotate>();

        myRb = this.GetComponent<Rigidbody>();
        cameraRb =camera.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W))
        {
           
        }




        if (moveInfo != Vector2.zero)
        {

            var mov = cameraRb.transform.forward * 0.08f;

            if (Mathf.Abs(moveInfo.x) > 0.001f)
            {
                mov.x *= Mathf.Cos(moveInfo.x);
                mov.z *= Mathf.Sin(moveInfo.x);
            }

            transform.rotation = new Quaternion(transform.rotation.x, mov.y, transform.rotation.z, Mathf.Atan(moveInfo.y / moveInfo.x));

            mov.y = 0;

            myRb.velocity = mov;
            rotation.y = Mathf.Atan(moveInfo.y / moveInfo.x) * 90;

            Debug.Log(rotation);

            transform.forward += mov;


            moveInfo = Vector2.zero;
        }
        //if (Mathf.Abs(moveInfo.x) > 0.001f)
        //{
        //    // 回転軸はワールド座標のY軸
        //    this.transform.RotateAround(this.transform.position, Vector3.up, moveInfo.x * 5f);
        //}
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // スティックの入力を受け取る
        moveInfo = context.ReadValue<Vector2>();
    }

}
