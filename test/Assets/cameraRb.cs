using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraRb : MonoBehaviour
{
    
    //プレイヤーのtransform
    public Transform player;

    Transform thisTra;

    Rigidbody camerapos;
    //スティックの入力情報(カメラ)
    Vector2 cameraInfo;

    //カメラの回転速度
    float rotateSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        

        //cameraMoveBaseTra = cameraMoveBase.transform;

        camerapos = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraInfo != Vector2.zero)
        {
            var mov = new Vector3(cameraInfo.x * rotateSpeed * Time.deltaTime, 0, cameraInfo.y * rotateSpeed * Time.deltaTime);

            // X方向に一定量移動していれば横回転
            if (Mathf.Abs(cameraInfo.x) > 0.001f)
            {
                // 回転軸はワールド座標のY軸
                this.transform.RotateAround(this.transform.position, Vector3.up, cameraInfo.x * 5f);
            }
            // Y方向に一定量移動していれば縦回転
            //if (Mathf.Abs(cameraInfo.y) > 0.001f)
            //{
            //    // 回転軸はカメラ自身のX軸
            //    cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, cameraInfo.y * 1f);
            //}



            // プレイヤーを移動させる
            //cameraMoveBaseTra.localEulerAngles = cameraMoveBaseTra.localEulerAngles + mov;
        }
        thisTra = player.GetComponent<Transform>();
        this.transform.position = thisTra.position;
    }

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

}
