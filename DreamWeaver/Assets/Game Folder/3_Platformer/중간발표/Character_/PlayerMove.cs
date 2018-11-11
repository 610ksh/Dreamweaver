using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour {

    public float moveSpeed = 5f;
    public float RotateSpeed = 10.0f;
    public float gravity = 9.8f;
    public float jumpForce = 4.0f;
    public int jumpCount = 0;

    new Rigidbody rigidbody;
    Animator animator;
    Vector3 playerInput;

    Quaternion newRotation;

    private Vector3 MoveDirection = Vector3.zero;
    private CharacterController characterController;
    private CollisionFlags collisionflags;
    Vector3 movementAmt = Vector3.zero;

    

    // Use this for initialization
    void Start ()
    {
         animator = GetComponent<Animator>();
         rigidbody = GetComponent<Rigidbody>();
         
	}

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
        SwitchState();


	}


    void Move()
    {
        

        float forwardKey = Input.GetKey(KeyCode.I) ? 1 : 0;
        float backKey = Input.GetKey(KeyCode.K) ? -1 : 0;
        //float leftRotateKey = Input.GetKey(KeyCode.U) ? -1 : 0;
        //float rightRotateKey = Input.GetKey(KeyCode.O) ? 1 : 0;
        float leftKey = Input.GetKey(KeyCode.J) ? -1 : 0;
        float rightKey = Input.GetKey(KeyCode.L) ? 1 : 0;

        float vertical = forwardKey + backKey;
        float horizontal = leftKey + rightKey;

        playerInput.Set(vertical, 0f, horizontal); //입력한 화살표(좌우, 상하)의 입력값을 Vector3형태로 만듭니다.

        //float v = Input.GetAxisRaw("Vertical");
        //float h = Input.GetAxisRaw("Horizontal");  

        Vector3 forward = transform.TransformDirection(Vector3.forward); //자신(플레이어)의 기준을 두고, forward(Vector3(0,0,1)) 방향 벡터를 가져옵니다/
        forward = forward.normalized; //정규화
        Vector3 right = transform.TransformDirection(Vector3.right); 


        MoveDirection = forward * vertical + right * horizontal; 

        movementAmt = (MoveDirection * moveSpeed * Time.deltaTime); //총 이동량은 forward방향 * 이동속도 * deltiTime

  
       transform.position += movementAmt; //이동
       
    }

    void Rotate()
    {
        float leftRotateKey = Input.GetKey(KeyCode.U) ? -1 : 0;
        float rightRotateKey = Input.GetKey(KeyCode.O) ? 1 : 0;


        if (leftRotateKey+rightRotateKey != 0)
        {
            Vector3 rotate = new Vector3((leftRotateKey + rightRotateKey), 0f, 0f); //h값에 따라 좌,우 회전인지를 구분합니다(1,-1)

            Quaternion next = Quaternion.identity; //(0,0,0)쿼터니언 선언
            next.SetLookRotation(rotate); //로테이션 설정
            next = next * transform.rotation; //global axis 이동
            Quaternion past = transform.rotation; //현재 이동 전 로테이션


            transform.rotation = Quaternion.RotateTowards(past, next, 300f * Time.deltaTime); //현재-> next로 이동
            
        }



    }
    void OnCollisionEnter(Collision col) //충돌판정(점프 On/Off)
    {
        if (col.gameObject.CompareTag("Floor") || col.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && jumpCount < 2)
        {
            jumpCount += 1;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            rigidbody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            
        }

    }

    void SwitchState()
    {

        if (playerInput == Vector3.zero)
        {
            animator.SetBool("Stand", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Stand", false);
            animator.SetBool("Run", true);
        }


    }

}
