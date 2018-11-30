using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;
    public float jumpSpeed = 250.0f;

    // 움직임 제한하는 변수
    bool isMove = true;

    void Update()
    {
        //앞뒤 이동
        if (isMove)
        {
            //좌우 회전
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotSpeed);

            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

            //점프
            if (Input.GetButtonDown("Jump") && transform.position.y < 1.1f)
            {
                transform.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
            }
        }
    }

    public void SetMove(bool isMove)
    {
        this.isMove = isMove;
    }
}
