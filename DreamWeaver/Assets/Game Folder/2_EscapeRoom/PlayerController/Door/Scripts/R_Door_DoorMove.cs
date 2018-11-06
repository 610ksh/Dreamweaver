using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Door_DoorMove : MonoBehaviour
{

    // 문 속도
    public float moveSpeed = 6.0f;

    // 회전 속도
    public float rotateSpeed = 1.0f;

    // 시간
    float curTime = 0.0f;
    bool isMove = false;
    bool isRotate = false;

    void Update()
    {
        // 시그널이 오면
        if (isMove)
        {
            TranslateDoor();
        }

        if (isRotate)
        {
            RotateDoor();
        }
    }

    // 외부에서 문 여는 신호를 보내는 용도
    public void MoveSignal()
    {
        curTime = 0.0f;
        isMove = true;
    }

    // 외부에서 문 회전 신호
    public void RotateSignal()
    {
        isRotate = true;
    }

    // 실제 문 돌아가는 로직
    void RotateDoor()
    {
        // 끝까지 돌아가지 않았다면
        if (transform.rotation.y < 0.1f)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotateSpeed);
        }
        else
        {
            isRotate = false;
        }
    }


    // 실제 문 열리는 로직
    private void TranslateDoor()
    {
        //문이 열린 시간을 누적해서 기록
        curTime += Time.deltaTime;

        // 시간이 0초 ~ 5초 && 문의 x좌표가 4보다 작다면
        if (curTime < 5.0f && transform.position.x < 4.0f)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        // 시간이 5초이상 흘렀고 && 문의 x좌표가 0보다 크다면
        if (curTime >= 5.0f && transform.position.x > 0.1f)
        {
            // 다시 제자리로 이동
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);

            // 만약 문의 위치가 0보다 작으면 문을 멈추다.
            if (transform.position.x <= 0.1)
            {
                isMove = false;
                //디버깅용. 무시해주세요 :D
                //Debug.Log(curTime);
            }
        }
    }
}
