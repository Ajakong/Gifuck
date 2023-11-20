using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    
    //�J�����̐e�I�u�W�F�N�g��transform
    Transform cameraMoveBaseTra;

    

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

    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(moveInfo == Vector2.zero)
        {
            // �ړ�����������
            transform.forward = camera.transform.forward;
        }
        else
        {
            transform.forward = moveInfo; 
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cameraInfo != Vector2.zero)
        {
            
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
