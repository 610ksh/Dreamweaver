using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCubeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            //부모의 isSelected, isPlayerStay를 true로 바꿔줌 
            transform.parent.GetComponent<SelectCubeEle>().isSelected = true;
            transform.parent.GetComponent<SelectCubeEle>().isPlayerStay = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //부모의 isPlayerStay를 false로 바꿔줌 
            transform.parent.GetComponent<SelectCubeEle>().isPlayerStay = false;
        }
    }

}
