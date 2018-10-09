using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // 싱글톤 적용
    public static GameManager instance;

    // KeyPad 이미지
    public GameObject Keypad;

	void Awake () {
        instance = this;
	}
	
	void Update () {
		
	}
}
