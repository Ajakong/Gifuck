using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Member;

public class unitychanMove : MonoBehaviour
{

    public Transform cameraPos;

    Rigidbody myRb;
    //移動速度
    float moveSpeed;

    //視点の移動速度

    //前に進んでいるか
    bool moveFrontFlag = false;
    //後ろに進んでいるかどうか
    bool moveBackFlag = false;
    //右
    bool moveRightFlag = false;
    //左
    bool moveLeftFlag = false;

    //カメラPos
    Vector3 CPos;
    Vector3 move1;
    Vector3 move2;

    //ジャンプ関係
    Vector3 forceDirection;
    float forcePower;
    Vector3 force;
    bool jumpFlag = false;
    public bool flag = false;

    bool runFlag = false;

    //剣関係
    GameObject sword;
    Transform swordTransform;

    public bool equipmentFlag = false;

    GameObject handObj;
    GameObject equipObj;

    //カメラの親オブジェクト
    public GameObject cameraMoveBase;
    //カメラの親オブジェクトのtransform
    Transform cameraMoveBaseTra;

    //InputSystem
    float speed = 30.0f;
    //入力されたスティックの角度と向きを入れるよう(？)
    public Vector2 v;

    Vector2 moveInfo;
    float turnVelocity;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.15f;
        myRb = this.GetComponent<Rigidbody>();

        forceDirection = new Vector3(0f, 1.0f, 0f);
        forcePower = 6f;
        force = forcePower * forceDirection;

        sword = GameObject.Find("ObjSword");

        handObj = GameObject.Find("Character1_RightHandMiddle1");
        equipObj = GameObject.Find("J_Mune_root_00");

        cameraMoveBase = GameObject.Find("cameraMather");
        cameraMoveBaseTra = cameraMoveBase.transform;

        turnVelocity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        CPos = cameraPos.position;
        move1 = transform.forward * moveSpeed;
        move2 = transform.right * moveSpeed;

        // マウスの移動量を取得
        float mx = Input.GetAxis("Mouse X");

        // X方向に一定量移動していれば横回転
        if (Mathf.Abs(mx) > 0.00001f)
        {
            // 回転軸はワールド座標のY軸
            transform.RotateAround(myRb.transform.position, Vector3.up, mx * 1.5f);
        }


        //if (Input.GetKey(KeyCode.W))
        //{
        //    moveFrontFlag = true;
        //}
        //else
        //{
        //    moveFrontFlag = false;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    moveBackFlag = true;
        //}
        //else
        //{
        //    moveBackFlag = false;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveRightFlag = true;
        //}
        //else
        //{
        //    moveRightFlag = false;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    moveLeftFlag = true;
        //}
        //else
        //{
        //    moveLeftFlag = false;
        //}

        if(moveInfo != null)
        {
            //transform. += moveInfo.x;
        }

        //マウスカーソルを消す
        if (Input.GetMouseButton(2))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && !flag)
        {
            jumpFlag = true;

        }
        else
        {
            jumpFlag = false;
        }

        //走る
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runFlag = true;
        }
        else
        {
            runFlag = false;
            moveSpeed = 0.15f;
        }

        //剣をしまう
        if (Input.GetKeyDown(KeyCode.Tab) && !equipmentFlag)
        {
            //equipmentFlag = true;
        }

    }

    void FixedUpdate()
    {
        //if (moveFrontFlag)
        //{
        //    myRb.position += move1;
        //}

        //if (moveBackFlag)
        //{
        //    myRb.position -= move1;
        //}

        //if (moveRightFlag)
        //{
        //    myRb.position += move2;
        //}

        //if (moveLeftFlag)
        //{
        //    myRb.position -= move2;
        //}

        if (jumpFlag)
        {
            flag = true;
            myRb.AddForce(force, ForceMode.Impulse);
            CPos.y -= 2;
            cameraPos.transform.position = CPos;
        }

        if (runFlag)
        {
            moveSpeed = 0.4f;
        }

        //しまう
        if (equipmentFlag)
        {
            sword.gameObject.transform.parent = equipObj.gameObject.transform;

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

        //// 移動量を計算
        //var mov = new Vector3(v.x * speed * Time.deltaTime, 0, v.y * speed * Time.deltaTime);

        //switch (context.phase)
        //{
        //    case InputActionPhase.Started:
        //        // 入力開始

        //        // 移動方向を向く
        //        transform.forward = mov;
        //        break;
        //    case InputActionPhase.Canceled:
        //        // 入力終了
        //        break;
        //    default:
        //        // 移動方向を向く
        //        transform.forward = mov;
        //        break;
        //}

        ////Performedフェーズ(倒し続けているとき)の処理
        //if (context.phase == InputActionPhase.Performed)
        //{
        //    // 移動方向を向く
        //    transform.forward = mov;

        //    // 移動させる
        //    transform.position = transform.position + mov;
        //}


    }

    //右スティックを倒したときのカメラの移動(今はx方向のみ)
    public void OnCameraMove(InputAction.CallbackContext context)
    {
        // スティックの入力を受け取る
        var v = context.ReadValue<Vector2>();

        // 移動量を計算
        var mov = new Vector3(v.x * speed * Time.deltaTime, 0, v.y * speed * Time.deltaTime);


        if (context.phase == InputActionPhase.Waiting)
        {
            return;
        }
        if (context.phase == InputActionPhase.Started)
        {
            return;
        }

        if (context.phase == InputActionPhase.Performed)
        {
            // X方向に一定量移動していれば横回転
            if (Mathf.Abs(v.x) > 0.001f)
            {
                // 回転軸はワールド座標のY軸
                cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, Vector3.up, v.x * 5f);
            }
            // Y方向に一定量移動していれば横回転
            if (Mathf.Abs(v.y) > 0.001f)
            {
                // 回転軸はワールド座標のY軸
                cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, v.y * 1f);
                return;
            }
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            return;
        }

        // 移動させる
        //cameraMoveBaseTra.localEulerAngles = cameraMoveBaseTra.localEulerAngles + mov;
        cameraMoveBaseTra.localEulerAngles +=  mov;
    }
}
