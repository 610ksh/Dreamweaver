using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float force = 50f;
    public GameObject player;

    private void OnTriggerEnter(Collider c) //occur when player get in
    {
        if (c.tag == "Player")
        {
            Force();
        }

    }

    void Force()
    {
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 2, 0) * force, ForceMode.Impulse);
    }
}