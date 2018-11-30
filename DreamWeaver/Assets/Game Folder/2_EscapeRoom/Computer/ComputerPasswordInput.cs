using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ComputerPasswordInput : MonoBehaviour {


	//암호를 적을 공간 받아옴
	public InputField inputPassword;

	//패스워드 정답
	private string correctComputerPassword = "20000207";

	
	public void InputText(Text password)
	{
		
		//위에서 선언한 암호 적을 공간속의 TEXT들을 password라 명명함
		password.text = inputPassword.text;

		//내가 적은 TEXT와 정답과 비교
		if (password.text == correctComputerPassword)
		{
			//잠금화면 비활성화
			R_GameManager.instance.computerUI.transform.GetChild(0).gameObject.SetActive(false);
			//암호적는 공간 비활성화
			R_GameManager.instance.computerUI.transform.GetChild(2).gameObject.SetActive(false);
			//컴퓨터화면 활성화
			R_GameManager.instance.computerUI.transform.GetChild(1).gameObject.SetActive(true);

			//다음에 컴퓨터 킬 때에도 다시 암호 입력하도록 초기화
			inputPassword.text = null;


			
		}
		else
		{
			//암호 틀리면 초기화
			inputPassword.text = null;
		}
		
	}

	void Update()
	{
		//잠금화면에는 shutdown버튼을 안만들어놓음
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			R_GameManager.instance.computerUI.gameObject.SetActive(false);

		}
	}
}
