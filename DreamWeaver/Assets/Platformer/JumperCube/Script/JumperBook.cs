using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperBook : MonoBehaviour
{
    public float force = 25f;
    public GameObject player;

    Vector3 directVector;

    private void OnCollisionEnter(Collision c) //occur when player get in
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Force();
        }

    }

    void Force()
    {
        directVector = transform.TransformDirection(Vector3.forward);
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody>().AddForce(directVector * force, ForceMode.Impulse);

    }
}