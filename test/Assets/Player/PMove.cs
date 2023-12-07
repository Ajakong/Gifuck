using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PMove : MonoBehaviour
{
    Rigidbody myRb;

    Vector3 gravity;

    [Header("移動の速さ"), SerializeField]
    private float _speed = 3;

    [Header("カメラ"), SerializeField]
    private Camera _targetCamera;

    private Transform _transform;
    private CharacterController _characterController;

    private Vector2 _inputMove;
    private float _verticalVelocity;
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
        gravity = new Vector3(0.0f, -5000f, 0.0f);
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        //myRb = GetComponent<Rigidbody>();
        if (_targetCamera == null)
            _targetCamera = Camera.main;

        dushSpeed = 1;
    }

    private void Update()
    {
        //if (dushFlag)
        //{
        //    dushSpeed = 6;
        //}
        //else
        //{
        //    dushSpeed = 1;
        //}


        // カメラの向き（角度[deg]）取得
        var cameraAngleY = _targetCamera.transform.eulerAngles.y;

        // 操作入力と鉛直方向速度から、現在速度を計算
        var moveVelocity = new Vector3(
            _inputMove.x * _speed,
            myRb.velocity.y,
            _inputMove.y * _speed
        );
        // カメラの角度分だけ移動量を回転


        moveVelocity = Quaternion.Euler(0, cameraAngleY, 0) * moveVelocity;
        //myRb.transform.forward= Quaternion.Euler(0, cameraAngleY, 0) *transform.forward;


        if (_inputMove != Vector2.zero)
        {
            // 移動入力がある場合は、振り向き動作も行う

            // 操作入力からy軸周りの目標角度[deg]を計算
            var targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
                * Mathf.Rad2Deg + 90;
            // カメラの角度分だけ振り向く角度を補正
            targetAngleY += cameraAngleY;

            // イージングしながら次の回転角度[deg]を計算
            var angleY = Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetAngleY,
                ref _turnVelocity,
                0.1f
            );

            // オブジェクトの回転を更新
            _transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
        else
        {
            dushFlag = false;
        }

        // 現在フレームの移動量を移動速度から計算
        var moveDelta = new Vector3(moveVelocity.x * Time.deltaTime * dushSpeed, moveVelocity.y * Time.deltaTime, moveVelocity.z * Time.deltaTime * dushSpeed);

        //_rotation.x = moveVelocity.x; _rotation.y = moveVelocity.y;

        //_rotation.z = moveVelocity.z;

        //_rotation.w = transform.rotation.w;

        //transform.forward= moveVelocity;


        _characterController.Move(moveDelta);
        if (groundFlag == false)
        {
            Debug.Log("tuintuin");
            myRb.AddForce(gravity, ForceMode.Acceleration);
        }

        if (_inputMove != Vector2.zero)
        {
            //myRb.velocity= moveDelta;
            // CharacterControllerに移動量を指定し、オブジェクトを動かす



        }
        Debug.Log(groundFlag);

    }


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