using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperCube : MonoBehaviour
{
    public float force = 25f;

    private void OnTriggerEnter(Collider c) //occur when player get in
    {
        if (c.tag == "Player")
        {
            c.GetComponent<Rigidbody>().velocity = Vector3.zero;
            c.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }

    }
}