using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    Transform thisTransform;
    //カメラの親オブジェクト
    public GameObject cameraMoveBase;
    //カメラの親オブジェクトのtransform
    Transform cameraMoveBaseTra;

    Rigidbody cameraRb;

    rotest rotest;

    Quaternion rotate;

    //ジャンプ
    bool flag = false;
    //移動速度
    float speed = 10.0f;
    //カメラの回転速度
    float rotateSpeed = 0.5f;
    //スティックの入力情報(移動)
    Vector2 moveInfo;
    //スティックの入力情報(カメラ)
    Vector2 cameraInfo;

    Vector3 mov;


    // Start is called before the first frame update
    void Start()
    {
        rotest=cameraMoveBase.GetComponent<rotest>();

        cameraMoveBaseTra = cameraMoveBase.transform;

        cameraRb = cameraMoveBase.GetComponent<Rigidbody>();
    }

    void Update()
    {
        mov = transform.forward/10;

        rotate = new Quaternion(transform.rotation.x, Mathf.Atan(moveInfo.x / moveInfo.y)*90, transform.rotation.z, Mathf.Atan(moveInfo.x / moveInfo.y));

        // 移動方向を向く
        transform.forward = rotest.rotateMove;
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        if (moveInfo != Vector2.zero)
        {
            //Transform temp;

            //cameraMoveBaseTra = cameraMoveBase.transform;
            //temp = cameraMoveBaseTra;

            //var mov = new Vector3(moveInfo.x * speed * Time.deltaTime, 0, moveInfo.y * speed * Time.deltaTime);


           

            


            // 移動させる
            transform.position = transform.position + mov;
            
        }

        if(cameraInfo != Vector2.zero)
        {
            var mov = new Vector3(cameraInfo.x * rotateSpeed * Time.deltaTime, 0, cameraInfo.y * rotateSpeed * Time.deltaTime);

            // X方向に一定量移動していれば横回転
            if (Mathf.Abs(cameraInfo.x) > 0.001f)
            {
                // 回転軸はワールド座標のY軸
                //transform.RotateAround(this.transform.position, Vector3.up, cameraInfo.x * 5f);


            }
            // Y方向に一定量移動していれば縦回転
            //if (Mathf.Abs(cameraInfo.y) > 0.001f)
            //{
            //    // 回転軸はカメラ自身のX軸
            //    cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, cameraInfo.y * 1f);
            //}

            transform.rotation = rotate;

            // 移動させる
            cameraMoveBaseTra.localEulerAngles = cameraMoveBaseTra.localEulerAngles + mov;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            flag = false;
        }
    }

    //左スティックを倒したとき倒した向きと角度で移動
    public void OnMove(InputAction.CallbackContext context)
    {
        // スティックの入力を受け取る
        moveInfo = context.ReadValue<Vector2>();
    }

    //右スティックを倒したときのカメラの移動(今はx方向のみ)
    public void OnCameraMove(InputAction.CallbackContext context)
    {
        //Debug.Log("cameraMove");
        // スティックの入力を受け取る
        cameraInfo = context.ReadValue<Vector2>();

        //// 移動量を計算
        //var mov = new Vector3(cameraInfo.x * speed * Time.deltaTime, 0, cameraInfo.y * speed * Time.deltaTime);


        //if (context.phase == InputActionPhase.Waiting)
        //{
        //    return;
        //}
        //if (context.phase == InputActionPhase.Started)
        //{
        //    return;
        //}

        //if (context.phase == InputActionPhase.Performed)
        //{
        //    // X方向に一定量移動していれば横回転
        //    if (Mathf.Abs(cameraInfo.x) > 0.001f)
        //    {
        //        // 回転軸はワールド座標のY軸
        //        cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, Vector3.up, cameraInfo.x * 5f);
        //    }
        //    // Y方向に一定量移動していれば横回転
        //    if (Mathf.Abs(cameraInfo.y) > 0.001f)
        //    {
        //        // 回転軸はワールド座標のY軸
        //        cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, cameraInfo.y * 1f);
        //        return;
        //    }
        //}
        //if (context.phase == InputActionPhase.Canceled)
        //{
        //    return;
        //}

        //// 移動させる
        ////cameraMoveBaseTra.localEulerAngles = cameraMoveBaseTra.localEulerAngles + mov;
        //cameraMoveBaseTra.localEulerAngles += mov;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
             //Debug.Log("jumping");
             if(!flag)
            {
                flag = true;
                Vector3 force = 6f * Vector3.up;
                Rigidbody myRb = GetComponent<Rigidbody>();
                myRb.AddForce(force, ForceMode.Impulse);
            }
   
        }
        else
        {
            return;
        }
    }
}
