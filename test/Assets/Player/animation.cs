using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    TrailRenderer trailRenderer;

    public GameObject sword;
    Animator animator;

    Vector2 tempVec;

    public string parameterName = "";
    public bool parameterValue = true;

    public bool moveFlag;

    public bool dushFalg;

    bool m_attackFlag;
    int attackCount;
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer = sword.GetComponent<TrailRenderer>();

        animator = GetComponent<Animator>();
        dushFalg = false;
        moveFlag = false;

        trailRenderer.enabled = false;
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

        if(attackCount>=60)
        {
            attackCount = 0;
            m_attackFlag = false;
            trailRenderer.Clear();
            trailRenderer.enabled = false ;
        }
        Debug.Log(attackCount);
    }

    private void FixedUpdate()
    {
        if(m_attackFlag)
        {
            trailRenderer.enabled = true;
            attackCount++;
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
        if(m_attackFlag==false)
        {
            m_attackFlag = true;

            animator.SetTrigger("swordTrigger");
            
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        animator.SetTrigger("jumpTrigger");
    }


}
