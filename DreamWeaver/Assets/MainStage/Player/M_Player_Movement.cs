using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Player_Movement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;
    public float jumpSpeed = 280.0f;
    bool isJump = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //앞뒤 이동
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
            GetComponent<Animator>().SetBool("Run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }

        //좌우 회전
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotSpeed); // Time.deltaTime으로 하면 너무 속도가 느림.

        // Ground 태그와 닿았을때만 점프
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
            isJump = true;
            GetComponent<Animator>().SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
            GetComponent<Animator>().SetBool("Jump", false);
        }
    }

}
