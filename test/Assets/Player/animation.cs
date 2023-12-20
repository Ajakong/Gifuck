using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class animation : MonoBehaviour
{
    Rigidbody rb;


    TrailRenderer trailRenderer;

    public GameObject sword;
    BoxCollider swordCol;

    Animator animator;

    Ray ray;
    Vector3 originRay;
    Vector3 RayCast;

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
        rb=GetComponent<Rigidbody>();
        RayCast = new Vector3(0, -1, 0);
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

            //TrailRendererの頂点情報からメッシュを生成する
            TrailRenderer paintObjectTrailRenderer = sword.GetComponent<TrailRenderer>();
            //子にコライダーだけ持つオブジェクトを作成する
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
        RaycastHit hit;
        originRay = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);

        ray = new Ray(originRay, RayCast);
        Debug.Log(originRay);
        if(Physics.Raycast(originRay,RayCast,-500,30))
        {
            
            rb.AddForce(0, 5, 0, ForceMode.Impulse);
            animator.SetTrigger("jumpTrigger");
        }
    }


}
