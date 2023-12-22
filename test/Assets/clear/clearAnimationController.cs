using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class clearAnimationController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Bbool",true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnX(InputAction.CallbackContext context)
    {
        animator.SetTrigger("XTri");
    }

    public void OnY(InputAction.CallbackContext context)
    {
        animator.SetTrigger("YTri");
    }

    public void OnA(InputAction.CallbackContext context)
    {
        animator.SetTrigger("ATri");
    }
}

