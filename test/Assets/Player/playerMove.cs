using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class playerMove : MonoBehaviour
{
    Rigidbody myRb;

    Vector3 postVelocity;

    [Header("�ړ��̑���"), SerializeField]
    private float _speed = 3;

    [Header("�J����"), SerializeField]
    private Camera _targetCamera;

    private Transform _transform;
    private CharacterController _characterController;

    private Vector2 _inputMove;
    private float _turnVelocity;

    bool dushFlag = false;
  


    int dushSpeed = 1;

    Vector3 pos;

    /// <summary>
    /// �ړ�Action(PlayerInput������Ă΂��)
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        _inputMove = context.ReadValue<Vector2>();
        dushFlag = false;
    }


    private void Awake()
    {
        myRb = GetComponent<Rigidbody>();
       postVelocity = myRb.velocity;
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        //myRb = GetComponent<Rigidbody>();
        if (_targetCamera == null)
            _targetCamera = Camera.main;
    }

    private void Update()
    {
        postVelocity = new Vector3(0,myRb.velocity.y,0);

        dushSpeed = 1;

        if (dushFlag == true)
        {
            dushSpeed = 6;
        }


        // �J�����̌����i�p�x[deg]�j�擾
        var cameraAngleY = _targetCamera.transform.eulerAngles.y;

        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        var moveVelocity = new Vector3(
            _inputMove.x * _speed,
            myRb.velocity.y,
            _inputMove.y * _speed
        );
        // �J�����̊p�x�������ړ��ʂ���]


        moveVelocity = Quaternion.Euler(0, cameraAngleY, 0) * moveVelocity;
        //myRb.transform.forward= Quaternion.Euler(0, cameraAngleY, 0) *transform.forward;


        if (_inputMove != Vector2.zero)
        {
            // �ړ����͂�����ꍇ�́A�U�����������s��

            // ������͂���y������̖ڕW�p�x[deg]���v�Z
            var targetAngleY = -Mathf.Atan2(_inputMove.y, _inputMove.x)
                * Mathf.Rad2Deg + 90;
            // �J�����̊p�x�������U������p�x��␳
            targetAngleY += cameraAngleY;

            // �C�[�W���O���Ȃ��玟�̉�]�p�x[deg]���v�Z
            var angleY = Mathf.SmoothDampAngle(
                _transform.eulerAngles.y,
                targetAngleY,
                ref _turnVelocity,
                0.1f
            );

            // �I�u�W�F�N�g�̉�]���X�V
            _transform.rotation = Quaternion.Euler(0, angleY, 0);
        }

        // ���݃t���[���̈ړ��ʂ��ړ����x����v�Z
        var moveDelta = new Vector3(moveVelocity.x * Time.deltaTime * dushSpeed,0, moveVelocity.z * Time.deltaTime * dushSpeed);

        //_rotation.x = moveVelocity.x; _rotation.y = moveVelocity.y;

        //_rotation.z = moveVelocity.z;

        //_rotation.w = transform.rotation.w;

        //transform.forward= moveVelocity;


        Debug.Log(moveDelta);
        moveDelta += postVelocity;
        _characterController.Move(moveDelta);
       
        
       

    }


    

    public void OnDush(InputAction.CallbackContext context)
    {
        dushFlag = true;
    }



}