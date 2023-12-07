using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    Animator animator;

    Vector2 tempVec;

    public string parameterName = "";
    public bool parameterValue = true;

    public bool moveFlag;

    public bool dushFalg;
    // Start is called before the first frame update
    void Start()
    {


        animator = GetComponent<Animator>();
        dushFalg = false;
        moveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        tempVec = Vector2.zero;

        animator.SetBool("move", false);
        if (moveFlag)
        {
            animator.SetBool("move", true);
        }


        if (moveFlag && dushFalg)
        {
            animator.SetBool("dashBool", true);

        }
        else
        {
            animator.SetBool("dashBool", false);

        }

    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        tempVec = context.ReadValue<Vector2>();
        if (tempVec != Vector2.zero)
        {
            moveFlag = true;
        }
        else
        {
            moveFlag = false;
        }

    }


    public void OnDash(InputAction.CallbackContext context)
    {
        //if (tempVec == Vector2.zero)
        //{
        //    return;
        //}

        dushFalg = true;
    }

    public void OnRelease(InputAction.CallbackContext context)
    {
       // if (!context.performed) return;

        dushFalg = false;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        animator.SetTrigger("swordTrigger");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        animator.SetTrigger("jumpTrigger");
    }


}
