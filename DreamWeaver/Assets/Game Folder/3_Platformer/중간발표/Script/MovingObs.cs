using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObs : MonoBehaviour
{
    public float speed = 0.2f;
    public float maxPos = 4.0f;
    public GameObject player;

    float position;
    float originalPosition;

    // Use this for initialization
    void Start()
    {
        originalPosition = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position.x;
        if (position < originalPosition - maxPos || position > originalPosition + maxPos)
        {
            speed *= -1;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Player")) //
        {
            c.transform.parent = this.transform.parent;
        }
    }

    private void OnCollisionEnter(Collision c) //occur when player get in
    {
        if (c.gameObject.CompareTag("Player")) //
        {
            c.transform.parent = transform;
        }
    }
}
