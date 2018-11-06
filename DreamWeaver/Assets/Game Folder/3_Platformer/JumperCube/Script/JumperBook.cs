using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperBook : MonoBehaviour
{
    public float force = 25f;
    Vector3 directVector;

    private void OnCollisionEnter(Collision c) //occur when player get in
    {
        if (c.gameObject.CompareTag("Player"))
        {
            directVector = transform.TransformDirection(Vector3.forward);
            c.collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
            c.collider.GetComponent<Rigidbody>().AddForce(directVector * force, ForceMode.Impulse);
        }

    }
}