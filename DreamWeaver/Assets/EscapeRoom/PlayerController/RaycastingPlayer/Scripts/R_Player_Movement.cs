using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;
    public float jumpSpeed = 250.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //앞뒤 이동
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        //좌우 회전
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotSpeed); // Time.deltaTime으로 하면 너무 속도가 느림.

        //점프
        if (Input.GetButtonDown("Jump") && transform.position.y < 1.1f)
        {
            transform.GetComponent<Rigidbody>().AddForce(0,jumpSpeed,0);
        }
    }
}
