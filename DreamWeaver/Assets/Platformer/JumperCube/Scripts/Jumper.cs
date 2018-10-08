using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    public float force = 100f;

    private Vector3 pos;
    Rigidbody rb;
    int cnt;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        pos = this.GetComponent<Transform>().position;
    }
	/*
	// Update is called once per frame
	void Update ()
    {
        if (Player.instance.grounded == true && cnt >= 1)
        {
            Init();
        }
    }
    */
    private void OnTriggerEnter(Collider c) //occur when player get in
    {
        if (c.tag == "Player" && cnt == 0)
        {
            Invoke("Force", 1.3f);

            rb.useGravity = true;  //Set gravity of rigidbody of this obj true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }

    }

    void Force()
    {
        rb.AddForce(new Vector3(0, 2, 0) * force, ForceMode.Impulse);
//        cnt++;
    }

    void Init()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        this.GetComponent<Transform>().position = pos;
        cnt = 0;
    }
}