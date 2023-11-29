using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PMove : MonoBehaviour
{
    Rigidbody myRb;

    [Header("�ړ��̑���"), SerializeField]
    private float _speed = 3;

    [Header("�J����"), SerializeField]
    private Camera _targetCamera;

    private Transform _transform;
    private CharacterController _characterController;

    private Vector2 _inputMove;
    private float _verticalVelocity;
    private float _turnVelocity;

    bool dushFlag = false;

    int dushSpeed = 1;

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
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        //myRb = GetComponent<Rigidbody>();
        if (_targetCamera == null)
            _targetCamera = Camera.main;
    }

    private void Update()
    {

        dushSpeed = 1;

        if (dushFlag == true)
        {
            dushSpeed = 10;
        }


        // �J�����̌����i�p�x[deg]�j�擾
        var cameraAngleY = _targetCamera.transform.eulerAngles.y;

        // ������͂Ɖ����������x����A���ݑ��x���v�Z
        var moveVelocity = new Vector3(
            _inputMove.x * _speed,
            _verticalVelocity,
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
        var moveDelta = moveVelocity * Time.deltaTime * dushSpeed;
        
        //_rotation.x = moveVelocity.x; _rotation.y = moveVelocity.y;

        //_rotation.z = moveVelocity.z;

        //_rotation.w = transform.rotation.w;

        //transform.forward= moveVelocity;



        if (_inputMove != Vector2.zero)
        {
            //myRb.velocity= moveDelta;
            // CharacterController�Ɉړ��ʂ��w�肵�A�I�u�W�F�N�g�𓮂���
            _characterController.Move(moveDelta);


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
    }


    public void OnDush(InputAction.CallbackContext context)
    {
        dushFlag = true;
    }



}