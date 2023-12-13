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

    [Header("�ړ��̑���"), SerializeField]
    private float _speed = 500f;

    [Header("�J����"), SerializeField]
    private Camera _targetCamera;

    private Transform _transform;
    

    private Vector2 _inputMove;
    
    private float _turnVelocity;

    public bool dushFlag = false;
    bool groundFlag = true;

    int dushSpeed = 1;

    /// <summary>
    /// �ړ�Action(PlayerInput������Ă΂��)
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
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



    //    // �J�����̌����i�p�x[deg]�j�擾
    //    var cameraAngleY = _targetCamera.transform.eulerAngles.y;

    //    // ������͂Ɖ����������x����A���ݑ��x���v�Z
    //    var moveVelocity = new Vector3(
    //        _inputMove.x,
    //        0,
    //        _inputMove.y
    //    );
    //    moveVelocity.Normalize();
    //    // �J�����̊p�x�������ړ��ʂ���]


    //    moveVelocity = Quaternion.Euler(0, cameraAngleY, 0) * moveVelocity*_speed;
    //    //myRb.transform.forward= Quaternion.Euler(0, cameraAngleY, 0) *transform.forward;


    //    if (_inputMove != Vector2.zero)
    //    {
    //        // �ړ����͂�����ꍇ�́A�U�����������s��

    //        // ������͂���y������̖ڕW�p�x[deg]���v�Z
    //        var targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
    //            * Mathf.Rad2Deg;
    //        // �J�����̊p�x�������U������p�x��␳
    //        targetAngleY += cameraAngleY;

    //        // �C�[�W���O���Ȃ��玟�̉�]�p�x[deg]���v�Z
    //        var angleY = Mathf.SmoothDampAngle(
    //            _transform.eulerAngles.y,
    //            targetAngleY,
    //            ref _turnVelocity,
    //            0.1f
    //        );



    //        // �I�u�W�F�N�g�̉�]���X�V
    //        _transform.rotation = Quaternion.Euler(0, angleY, 0);
    //    }
    //    else
    //    {
    //        dushFlag = false;
    //    }

    //    // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
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

    // �����ꂽ�u�Ԃ̃R�[���o�b�N
    public void OnRelease(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        dushSpeed = 1;
    }



}