//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using static Unity.VisualScripting.Member;

//public class unitychanMove : MonoBehaviour
//{

//    public Transform cameraPos;

//    Rigidbody myRb;
//    //�ړ����x
//    float moveSpeed;

//    //���_�̈ړ����x

//    //�J����Pos
//    Vector3 CPos;
//    Vector3 move1;
//    Vector3 move2;

//    //�W�����v�֌W
//    Vector3 forceDirection;
//    float forcePower;
//    Vector3 force;
//    bool jumpFlag = false;
//    public bool flag = false;

//    bool runFlag = false;

//    //���֌W
//    GameObject sword;


//    public bool equipmentFlag = false;

//    GameObject handObj;
//    GameObject equipObj;

//    //�J�����̐e�I�u�W�F�N�g
//    public GameObject cameraMoveBase;
//    //�J�����̐e�I�u�W�F�N�g��transform
//    Transform cameraMoveBaseTra;

//    //InputSystem
//    float speed = 30.0f;
//    //���͂��ꂽ�X�e�B�b�N�̊p�x�ƌ���������悤(�H)
//    public Vector2 v;

//    Vector2 moveInfo;
//    float turnVelocity;

//    // Start is called before the first frame update
//    void Start()
//    {
//        moveSpeed = 0.15f;
//        myRb = this.GetComponent<Rigidbody>();

//        forceDirection = new Vector3(0f, 1.0f, 0f);
//        forcePower = 6f;
//        force = forcePower * forceDirection;

//        sword = GameObject.Find("ObjSword");

//        handObj = GameObject.Find("Character1_RightHandMiddle1");
//        equipObj = GameObject.Find("J_Mune_root_00");

//        cameraMoveBase = GameObject.Find("cameraMather");
//        cameraMoveBaseTra = cameraMoveBase.transform;

//        turnVelocity = 0.5f;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        CPos = cameraPos.position;
//        move1 = transform.forward * moveSpeed;
//        move2 = transform.right * moveSpeed;

//        // �}�E�X�̈ړ��ʂ��擾
//        float mx = Input.GetAxis("Mouse X");

//        // X�����Ɉ��ʈړ����Ă���Ή���]
//        if (Mathf.Abs(mx) > 0.00001f)
//        {
//            // ��]���̓��[���h���W��Y��
//            transform.RotateAround(myRb.transform.position, Vector3.up, mx * 1.5f);
//        }


//        //if (Input.GetKey(KeyCode.W))
//        //{
//        //    moveFrontFlag = true;
//        //}
//        //else
//        //{
//        //    moveFrontFlag = false;
//        //}

//        //if (Input.GetKey(KeyCode.S))
//        //{
//        //    moveBackFlag = true;
//        //}
//        //else
//        //{
//        //    moveBackFlag = false;
//        //}

//        //if (Input.GetKey(KeyCode.D))
//        //{
//        //    moveRightFlag = true;
//        //}
//        //else
//        //{
//        //    moveRightFlag = false;
//        //}

//        //if (Input.GetKey(KeyCode.A))
//        //{
//        //    moveLeftFlag = true;
//        //}
//        //else
//        //{
//        //    moveLeftFlag = false;
//        //}

//        if(moveInfo != null)
//        {
//            //transform. += moveInfo.x;
//        }

//        //�}�E�X�J�[�\��������
//        if (Input.GetMouseButton(2))
//        {
//            Cursor.visible = false;
//            Cursor.lockState = CursorLockMode.Locked;
//        }

//        //�W�����v
//        if (Input.GetKey(KeyCode.Space) && !flag)
//        {
//            jumpFlag = true;

//        }
//        else
//        {
//            jumpFlag = false;
//        }

//        //����
//        if (Input.GetKey(KeyCode.LeftShift))
//        {
//            runFlag = true;
//        }
//        else
//        {
//            runFlag = false;
//            moveSpeed = 0.15f;
//        }

//        //�������܂�
//        if (Input.GetKeyDown(KeyCode.Tab) && !equipmentFlag)
//        {
//            //equipmentFlag = true;
//        }

//    }

//    void FixedUpdate()
//    {
//        //if (moveFrontFlag)
//        //{
//        //    myRb.position += move1;
//        //}

//        //if (moveBackFlag)
//        //{
//        //    myRb.position -= move1;
//        //}

//        //if (moveRightFlag)
//        //{
//        //    myRb.position += move2;
//        //}

//        //if (moveLeftFlag)
//        //{
//        //    myRb.position -= move2;
//        //}

//        if (jumpFlag)
//        {
//            flag = true;
//            myRb.AddForce(force, ForceMode.Impulse);
//            CPos.y -= 2;
//            cameraPos.transform.position = CPos;
//        }

//        if (runFlag)
//        {
//            moveSpeed = 0.4f;
//        }

//        //���܂�
//        if (equipmentFlag)
//        {
//            sword.gameObject.transform.parent = equipObj.gameObject.transform;

//        }

//    }

//    private void OnCollisionEnter(Collision other)
//    {
//        if (other.gameObject.tag == "ground")
//        {
//            flag = false;
//        }
//    }

//    //���X�e�B�b�N��|�����Ƃ��|���������Ɗp�x�ňړ�
//    public void OnMove(InputAction.CallbackContext context)
//    {
//        // �X�e�B�b�N�̓��͂��󂯎��
//        moveInfo = context.ReadValue<Vector2>();

//        //// �ړ��ʂ��v�Z
//        //var mov = new Vector3(v.x * speed * Time.deltaTime, 0, v.y * speed * Time.deltaTime);

//        //switch (context.phase)
//        //{
//        //    case InputActionPhase.Started:
//        //        // ���͊J�n

//        //        // �ړ�����������
//        //        transform.forward = mov;
//        //        break;
//        //    case InputActionPhase.Canceled:
//        //        // ���͏I��
//        //        break;
//        //    default:
//        //        // �ړ�����������
//        //        transform.forward = mov;
//        //        break;
//        //}

//        ////Performed�t�F�[�Y(�|�������Ă���Ƃ�)�̏���
//        //if (context.phase == InputActionPhase.Performed)
//        //{
//        //    // �ړ�����������
//        //    transform.forward = mov;

//        //    // �ړ�������
//        //    transform.position = transform.position + mov;
//        //}


//    }

//    //�E�X�e�B�b�N��|�����Ƃ��̃J�����̈ړ�(����x�����̂�)
//    public void OnCameraMove(InputAction.CallbackContext context)
//    {
//        // �X�e�B�b�N�̓��͂��󂯎��
//        var v = context.ReadValue<Vector2>();

//        // �ړ��ʂ��v�Z
//        var mov = new Vector3(v.x * speed * Time.deltaTime, 0, v.y * speed * Time.deltaTime);


//        if (context.phase == InputActionPhase.Waiting)
//        {
//            return;
//        }
//        if (context.phase == InputActionPhase.Started)
//        {
//            return;
//        }

//        if (context.phase == InputActionPhase.Performed)
//        {
//            // X�����Ɉ��ʈړ����Ă���Ή���]
//            if (Mathf.Abs(v.x) > 0.001f)
//            {
//                // ��]���̓��[���h���W��Y��
//                cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, Vector3.up, v.x * 5f);
//            }
//            // Y�����Ɉ��ʈړ����Ă���Ή���]
//            if (Mathf.Abs(v.y) > 0.001f)
//            {
//                // ��]���̓��[���h���W��Y��
//                cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, v.y * 1f);
//                return;
//            }
//        }
//        if (context.phase == InputActionPhase.Canceled)
//        {
//            return;
//        }

//        // �ړ�������
//        //cameraMoveBaseTra.localEulerAngles = cameraMoveBaseTra.localEulerAngles + mov;
//        cameraMoveBaseTra.localEulerAngles +=  mov;
//    }
//}
