using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Door_DoorMove : MonoBehaviour
{

    public float moveSpeed = 6.0f;

    float curTime = 0.0f;
    bool isMove = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 시그널이 오면
        if (isMove)
        {
            Movement();
        }
    }

    public void MoveSignal()
    {
        curTime = 0.0f;
        isMove = true;
    }

    private void Movement()
    {
        curTime += Time.deltaTime; // 현재시간
                                   // 시간이 0초 ~ 5초 && 4m이전
        if (curTime < 6.0f && transform.position.x < 4.0f)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        // 시간이 6초이상 흘렀고 && 문의 위치가 0보다 크다면
        if (curTime >= 6.0f && transform.position.x > 0.1f)
        {
            // 다시 제자리로 이동
            transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
            // 만약 문의 위치가 0보다 작으면 문을 멈추다.
            if (transform.position.x <= 0.1)
            {
                isMove = false;
                //디버깅용. 무시해주세요 :D
                Debug.Log(curTime);
            }
        }
    }
}
