using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerMove : MonoBehaviour
{
    Rigidbody myRb;

    Vector3 moveForward;

    Vector3 moveSide;

    Vector3 moveVelocity;

    Vector3 targetCameForward;

    [Header("移動の速さ"), SerializeField]
    private float _speed = 500f;

    [Header("カメラ"), SerializeField]
    private Camera _targetCamera;

    private Transform _transform;
    

    private Vector2 _inputMove;
    
    private float _turnVelocity;

    public bool dushFlag = false;
    bool groundFlag = true;

    int dushSpeed = 1;


    int ItemCount=0;

    public GameObject SwordInfo;

    GameObject sword2;

    GameObject oyaObj;

    /// <summary>
    /// 移動Action(PlayerInput側から呼ばれる)
    /// </summary>
    public void OnMove(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        _inputMove = context.ReadValue<Vector2>();
    }


    private void Awake()
    {
        myRb = GetComponent<Rigidbody>();
        oyaObj = GameObject.Find("Character1_RightHandMiddle1");

        _transform = transform;
        if (_targetCamera == null)
            _targetCamera = Camera.main;

        dushSpeed = 1;
    }

    private void Update()
    {
        targetCameForward = Vector3.Scale(_targetCamera.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;

        moveForward = targetCameForward * _inputMove.y;
        moveSide = _targetCamera.transform.right * _inputMove.x;

        moveVelocity = moveForward + moveSide;

        transform.forward = Vector3.Slerp(transform.forward, moveVelocity, Time.deltaTime * 30.0f);

        
        moveVelocity.y=myRb.velocity.y;
        moveVelocity.x = moveVelocity.x*_speed*dushSpeed;
        moveVelocity.z = moveVelocity.z * _speed * dushSpeed;
       
        myRb.velocity = moveVelocity;
       
    }

    private void FixedUpdate()
    {
       
    }

    

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            groundFlag = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
       

        if (col.gameObject.tag == "ground")
        {

            groundFlag = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag=="item")
        {
            ItemCount++;
            
            //if (ItemCount == 10)
            //{
            //    GameObject sword = GameObject.Find("ObjSword");
            //    Transform transform = sword.transform;
            //    sword2 = Instantiate(SwordInfo);
            //    sword2.gameObject.transform.parent = oyaObj.gameObject.transform;
            //    sword2.transform.position = transform.position;
            //    sword2.transform.localEulerAngles = transform.localEulerAngles;
            //    sword2.transform.localScale = transform.localScale;

            //    Destroy(sword.gameObject);


            //}
        }
        

    }

public void OnDush(InputAction.CallbackContext context)
    {

        //if (_inputMove != Vector2.zero)
        //{
        //    if (dushFlag)
        //    {
        //        dushFlag = false;
        //    }
        //    else
        //    {
        //        dushFlag = true;
        //    }
        //}
        dushSpeed = 4;
    }

    // 離された瞬間のコールバック
    public void OnRelease(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        dushSpeed = 1;
    }



}