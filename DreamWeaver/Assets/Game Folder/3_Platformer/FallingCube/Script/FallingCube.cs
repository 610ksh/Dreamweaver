using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public float inactivationTime = 3f;
    public float respawnTime = 5f;
    private Animator ani;
    private Vector3 pos;

    Material oriMaterial;
    Color oriColor;

    private void Awake()    //consturctor, similar with start() setting parameters and etc.
    {
        ani = this.GetComponent<Animator>(); //Get component of Animator
        pos = this.GetComponent<Transform>().position;
        oriMaterial = this.GetComponent<MeshRenderer>().materials[0];
        oriColor = this.GetComponent<MeshRenderer>().material.color;
    }

    private void OnTriggerEnter(Collider c) //occur when player get in
    {
        if (c.tag == "Player") //
        {
            ani.SetBool("Rotate", true);  //Set bool value "Rotate" of parameters true

            Invoke("AniFalse", 1.2f);   //invoke function 'AniFalse' after 1.2f seconds
            Invoke("ObjFall", 1f);   //invoke function 'ObjFall' after 1f seconds
            Invoke("Inactivate", inactivationTime);
            Invoke("Respawn", respawnTime);
        }
    }

    void AniFalse()  //Set bool value "Rotate" of parameters false
    {
        ani.SetBool("Rotate", false);
    }

    void ObjFall()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //unfreezePosition for gravity
        this.GetComponent<Rigidbody>().useGravity = true;  //Set gravity of rigidbody of this obj true;
        this.GetComponent<MeshRenderer>().material.color = new Color(255 / 255f, 112 / 255f, 112 / 255f);  //change color of this color
    }

    void Inactivate()
    {
        this.gameObject.SetActive(false);
        //        Destroy(gameObject);  //remove object
    }

    void Respawn()
    {
        this.GetComponent<Transform>().position = pos;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<MeshRenderer>().material.color = oriColor;
        this.GetComponent<MeshRenderer>().materials[0] = oriMaterial;
        this.gameObject.SetActive(true);
    }
}
