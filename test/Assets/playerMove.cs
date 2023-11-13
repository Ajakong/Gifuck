using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    Transform thisTransform;
    //�J�����̐e�I�u�W�F�N�g
    public GameObject cameraMoveBase;
    //�J�����̐e�I�u�W�F�N�g��transform
    Transform cameraMoveBaseTra;

    Rigidbody cameraRb;

    rotest rotest;

    Quaternion rotate;

    //�W�����v
    bool flag = false;
    //�ړ����x
    float speed = 10.0f;
    //�J�����̉�]���x
    float rotateSpeed = 0.5f;
    //�X�e�B�b�N�̓��͏��(�ړ�)
    Vector2 moveInfo;
    //�X�e�B�b�N�̓��͏��(�J����)
    Vector2 cameraInfo;

    Vector3 mov;


    // Start is called before the first frame update
    void Start()
    {
        cameraMoveBaseTra = cameraMoveBase.transform;
        rotest=cameraMoveBase.GetComponent<rotest>();


        cameraRb = cameraMoveBase.GetComponent<Rigidbody>();
    }

    void Update()
    {
        mov = transform.forward/10;

        rotate = new Quaternion(transform.rotation.x, Mathf.Atan(moveInfo.x / moveInfo.y)*90, transform.rotation.z, Mathf.Atan(moveInfo.x / moveInfo.y));

        // �ړ�����������
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


           

            


            // �ړ�������
            transform.position = transform.position + mov;
            
        }

        if(cameraInfo != Vector2.zero)
        {
            var mov = new Vector3(cameraInfo.x * rotateSpeed * Time.deltaTime, 0, cameraInfo.y * rotateSpeed * Time.deltaTime);

            // X�����Ɉ��ʈړ����Ă���Ή���]
            if (Mathf.Abs(cameraInfo.x) > 0.001f)
            {
                // ��]���̓��[���h���W��Y��
                //transform.RotateAround(this.transform.position, Vector3.up, cameraInfo.x * 5f);


            }
            // Y�����Ɉ��ʈړ����Ă���Ώc��]
            //if (Mathf.Abs(cameraInfo.y) > 0.001f)
            //{
            //    // ��]���̓J�������g��X��
            //    cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, cameraInfo.y * 1f);
            //}

            transform.rotation = rotate;

            // �ړ�������
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

    //���X�e�B�b�N��|�����Ƃ��|���������Ɗp�x�ňړ�
    public void OnMove(InputAction.CallbackContext context)
    {
        // �X�e�B�b�N�̓��͂��󂯎��
        moveInfo = context.ReadValue<Vector2>();
    }

    //�E�X�e�B�b�N��|�����Ƃ��̃J�����̈ړ�(����x�����̂�)
    public void OnCameraMove(InputAction.CallbackContext context)
    {
        //Debug.Log("cameraMove");
        // �X�e�B�b�N�̓��͂��󂯎��
        cameraInfo = context.ReadValue<Vector2>();

        //// �ړ��ʂ��v�Z
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
        //    // X�����Ɉ��ʈړ����Ă���Ή���]
        //    if (Mathf.Abs(cameraInfo.x) > 0.001f)
        //    {
        //        // ��]���̓��[���h���W��Y��
        //        cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, Vector3.up, cameraInfo.x * 5f);
        //    }
        //    // Y�����Ɉ��ʈړ����Ă���Ή���]
        //    if (Mathf.Abs(cameraInfo.y) > 0.001f)
        //    {
        //        // ��]���̓��[���h���W��Y��
        //        cameraMoveBase.transform.RotateAround(cameraMoveBase.transform.position, -Vector3.right, cameraInfo.y * 1f);
        //        return;
        //    }
        //}
        //if (context.phase == InputActionPhase.Canceled)
        //{
        //    return;
        //}

        //// �ړ�������
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
