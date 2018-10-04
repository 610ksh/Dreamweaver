using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float rotSpeed = 3.0f;
    public float jumpSpeed = 250.0f;

    // Update is called once per frame
    void Update () {
        //앞뒤 이동
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        
        //좌우 회전
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotSpeed);

        //점프
        if (Input.GetButtonDown("Jump") && transform.position.y < 1.1f)
        {
            transform.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0);
        }
    }
}
