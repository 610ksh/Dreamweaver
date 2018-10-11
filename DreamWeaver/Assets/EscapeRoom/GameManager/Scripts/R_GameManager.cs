using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_GameManager : MonoBehaviour {

    // 싱글톤 적용
    public static R_GameManager instance;

    // KeyPad 이미지
    public GameObject keypad;

    // Quiz 버튼
    public GameObject quiz;

    // Player
    public GameObject player;

	void Awake () {
        instance = this;
	}
	
	void Update () {
		
	}
}
