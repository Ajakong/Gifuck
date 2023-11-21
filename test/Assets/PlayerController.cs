using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;

    Vector3 PlayerMove;

    Rigidbody myRb;

    //�X�e�B�b�N�̓��͏��(�ړ�)
    Vector2 moveInfo;

    // Start is called before the first frame update
    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        PlayerMove = new Vector3(0, 0, 0);
    }

    public void Update()
    {
        transform.forward = camera.transform.forward / 5;

        PlayerMove.x = transform.forward.x * 0.02f;
        PlayerMove.z = transform.forward.y * 0.02f;

    }

    private void FixedUpdate()
    {
        if(moveInfo.y>=0)
        {
           
            PlayerMove.y = 0;

            myRb.velocity = PlayerMove;
        }

        
    }



    public void OnMove(InputAction.CallbackContext context)
    {
        // �X�e�B�b�N�̓��͂��󂯎��
        moveInfo = context.ReadValue<Vector2>();
    }
}
