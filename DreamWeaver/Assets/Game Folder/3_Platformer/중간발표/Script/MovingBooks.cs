using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBooks : MonoBehaviour
{
    public float speed = 0.2f;
    public float maxPos = 4.0f;
    public GameObject player;
    public GameObject parents;

    Transform originalParent;
    float position;
    float originalPosition;
 //   Vector3 originalScale;

    // Use this for initialization
    void Start()
    {
        originalPosition = this.transform.position.x;
        originalParent = player.transform.parent;
//        originalScale = this.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position.x;
        if (position < originalPosition - maxPos || position > originalPosition + maxPos)
        {
            speed *= -1;
        }
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Player")) //
        {
            c.transform.parent = originalParent;
        }
    }

    private void OnCollisionEnter(Collision c) //occur when player get in
    {
        if (c.gameObject.CompareTag("Player")) //
        {
            c.transform.parent = parents.transform;

//            player.GetComponent<Transform>().localScale = originalScale;
        }
    }
}
