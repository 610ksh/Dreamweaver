using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
    //move 변수
    public float speed = 5f;
    // y축방향 순간속도
    public float yVelocity = 0;
    public float gravity = 14f;
    public float jumpPower = 5f;

    
    float acc;
    Vector3 moveVector;
    Vector3 moveVector_local;

    CharacterController cc;
    Animator animator;

    Vector3 playerInput;

    //로테이트 변수
    public float lookSensitvity = 5;
    public float lookSmoothDamp = 0.1f;
    float xRotation;
    float yRotation;


    void Start () {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {

        playerInput.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); //입력한 화살표(좌우, 상하)의 입력값을 Vector3형태로 만듭니다.
        PlayerMove();
        SwitchState();
        //Rotate();

    }

    // 플레이어 움직임
    void PlayerMove()
    {
        // 캐릭터 컨트롤러의 바닥 영역이라면
        if (cc.isGrounded)
        {
            acc = gravity;
            // y축 방향의 속도를 
            yVelocity = -gravity * Time.deltaTime;
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity += acc;
                yVelocity = jumpPower;
                acc = 0;
            }
            animator.SetBool("Stand", true);
            animator.SetBool("Jump", false);
        }
        else
        {
            yVelocity -= gravity * Time.deltaTime;
            animator.SetBool("Jump", true);
            //if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)) Jump();

        }
        moveVector = Vector3.zero;
        moveVector.x = playerInput.x * speed;
        moveVector.y = yVelocity;
        moveVector.z = playerInput.z * speed;

        //캐릭터 컨트롤러의 move는 월드 좌표 기준으로 움직이기 때문에 moveVector를 로컬 기준으로 바꿔주어야 함 
        moveVector_local = transform.TransformDirection(moveVector);
        cc.Move(moveVector_local * Time.deltaTime);

    }

    // 애니메이션 상태 변환함수
    void SwitchState()
    {
        // 방향키를 누르지 않은 Default 상태일때
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

    // 회전 함수 (현재 사용하지 않고 있음. 회전은 따로 스크립트로 사용중)
    void Rotate()
    {
        //xRotation += -Input.GetAxis("Mouse Y") * lookSensitvity;
        yRotation += Input.GetAxis("Mouse X") * lookSensitvity;

        //transform.rotation = Quaternion.Euler(0, yRotation, 0);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

}
