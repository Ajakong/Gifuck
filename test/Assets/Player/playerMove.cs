using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerMove : MonoBehaviour
{
    Rigidbody myRb;

    Vector3 moveForward;

    Vector3 moveSide;

    Vector3 moveVelocity;

    Vector3 targetCameForward;

    [Header("移動の速さ"), SerializeField]
    private float _speed = 500f;

    [Header("カメラ"), SerializeField]
    private Camera _targetCamera;

    private Transform _transform;
    

    private Vector2 _inputMove;
    
    private float _turnVelocity;

    public bool dushFlag = false;
    bool groundFlag = true;

    int dushSpeed = 1;

    /// <summary>
    /// 移動Action(PlayerInput側から呼ばれる)
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        _inputMove = context.ReadValue<Vector2>();
    }


    private void Awake()
    {
        myRb = GetComponent<Rigidbody>();


        _transform = transform;
        if (_targetCamera == null)
            _targetCamera = Camera.main;

        dushSpeed = 1;
    }

    private void Update()
    {
        targetCameForward = Vector3.Scale(_targetCamera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        moveForward = targetCameForward * _inputMove.y;
        moveSide = _targetCamera.transform.right * _inputMove.x;

        moveVelocity = moveForward + moveSide;

        transform.forward = Vector3.Slerp(transform.forward, moveVelocity, Time.deltaTime * 30.0f);

        
        moveVelocity.y=myRb.velocity.y;
        moveVelocity.x = moveVelocity.x*_speed*dushSpeed;
        moveVelocity.z = moveVelocity.z * _speed * dushSpeed;
        //Debug.Log(moveVelocity.x + "," + moveVelocity.y + "," + moveVelocity.z);
        myRb.velocity = moveVelocity;
       
    }

    private void FixedUpdate()
    {
       
    }

    //private void Update()
    //{



    //    // カメラの向き（角度[deg]）取得
    //    var cameraAngleY = _targetCamera.transform.eulerAngles.y;

    //    // 操作入力と鉛直方向速度から、現在速度を計算
    //    var moveVelocity = new Vector3(
    //        _inputMove.x,
    //        0,
    //        _inputMove.y
    //    );
    //    moveVelocity.Normalize();
    //    // カメラの角度分だけ移動量を回転


    //    moveVelocity = Quaternion.Euler(0, cameraAngleY, 0) * moveVelocity*_speed;
    //    //myRb.transform.forward= Quaternion.Euler(0, cameraAngleY, 0) *transform.forward;


    //    if (_inputMove != Vector2.zero)
    //    {
    //        // 移動入力がある場合は、振り向き動作も行う

    //        // 操作入力からy軸周りの目標角度[deg]を計算
    //        var targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
    //            * Mathf.Rad2Deg;
    //        // カメラの角度分だけ振り向く角度を補正
    //        targetAngleY += cameraAngleY;

    //        // イージングしながら次の回転角度[deg]を計算
    //        var angleY = Mathf.SmoothDampAngle(
    //            _transform.eulerAngles.y,
    //            targetAngleY,
    //            ref _turnVelocity,
    //            0.1f
    //        );



    //        // オブジェクトの回転を更新
    //        _transform.rotation = Quaternion.Euler(0, angleY, 0);
    //    }
    //    else
    //    {
    //        dushFlag = false;
    //    }

    //    // 現在フレームの移動量を移動速度から計算
    //    var moveDelta = new Vector3(moveVelocity.x* dushSpeed,0, moveVelocity.z * dushSpeed);

    //    //_rotation.x = moveVelocity.x; _rotation.y = moveVelocity.y;

    //    //_rotation.z = moveVelocity.z;

    //    //_rotation.w = transform.rotation.w;

    //    //transform.forward= moveVelocity;

    //    moveDelta.Normalize();
    //    myRb.velocity = moveDelta;


    //    Debug.Log(groundFlag);




    //}

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            groundFlag = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("hit");
        //if (col.gameObject.tag == "Enemy")
        //{
        //    foreach (ContactPoint point in col.contacts)
        //    {
        //        Vector3 relativePoint = transform.InverseTransformPoint(point.point);
        //        relativePoint.Normalize();
        //        relativePoint.y = 0;
        //        transform.position += relativePoint;

        //    }
        //}

        if (col.gameObject.tag == "ground")
        {

            groundFlag = true;
        }
    }

    public void OnDush(InputAction.CallbackContext context)
    {

        //if (_inputMove != Vector2.zero)
        //{
        //    if (dushFlag)
        //    {
        //        dushFlag = false;
        //    }
        //    else
        //    {
        //        dushFlag = true;
        //    }
        //}
        dushSpeed = 4;
    }

    // 離された瞬間のコールバック
    public void OnRelease(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        dushSpeed = 1;
    }



}