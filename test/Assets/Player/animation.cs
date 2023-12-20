using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    TrailRenderer trailRenderer;

    public GameObject sword;
    BoxCollider swordCol;

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
        swordCol=sword.GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        swordCol.enabled = true;

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
        //Debug.Log(attackCount);
        
       
    }

    private void FixedUpdate()
    {
       
        if (attackCount >= 60)
        {
            swordCol.enabled = false;
            attackCount = 0;
            m_attackFlag = false;
            if (trailRenderer.enabled == true)
            {
                trailRenderer.Clear();
                trailRenderer.enabled = false;
            }
        }
        if (m_attackFlag)
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
            swordCol.enabled = true;
            animator.SetTrigger("swordTrigger");

            //TrailRenderer�̒��_��񂩂烁�b�V���𐶐�����
            TrailRenderer paintObjectTrailRenderer = sword.GetComponent<TrailRenderer>();
            //�q�ɃR���C�_�[�������I�u�W�F�N�g���쐬����
            GameObject colliderContainer = new GameObject("TrailCollider");
            colliderContainer.transform.SetParent(sword.transform);
            MeshCollider meshCollider = colliderContainer.AddComponent<MeshCollider>();
            //Mesh mesh = new Mesh();
            //paintObjectTrailRenderer.BakeMesh(mesh);
            //meshCollider.sharedMesh = mesh;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        animator.SetTrigger("jumpTrigger");
    }


}
