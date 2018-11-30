using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconClick : MonoBehaviour {
	
	//해설집
	public GameObject explanation;

	//해설집 자식들(따로 빼는게 편리해서 분리해서 놓음)
	public GameObject sineStory;

	//File종료버튼
	public GameObject exitIcon;

	//컴퓨터 종료 버튼
	public GameObject exitComputerButton;

	//부모 computer
	public GameObject computer;

	//싸인스토리 파일 클릭
	public void FileClick()
	{
		//해설집 활성화(화면에 보여주기)
		sineStory.SetActive(true);
		
		//해설집 종료버튼 활성화
		exitIcon.SetActive(true);

		//컴퓨터 종료버튼 비활성화
		exitComputerButton.SetActive(false);
	}

	//파일창 닫는버튼 클릭
	public void FileCloseClick()
	{
		//싸인스토리 모든 파일 비활성화
		explanation.transform.GetChild(0).gameObject.SetActive(false);
		explanation.transform.GetChild(1).gameObject.SetActive(false);
		explanation.transform.GetChild(2).gameObject.SetActive(false);

		//버튼 이것저것 누르다가 싸인스토리 부모 꺼져있는 경우가 발생해서 추가
		explanation.SetActive(true);
		
		//파일닫기버튼 비활성화 
		gameObject.SetActive(false);

		//컴퓨터 종료버튼 활성화
		exitComputerButton.gameObject.SetActive(true);
	}

	public void ShutDownComputerClick()
	{
		computer.SetActive(false);
		//잠금화면 호출
		computer.transform.GetChild(0).gameObject.SetActive(true);
		//일반화면 비활성화(잠금화면 호출을 위한 비활성화)
		computer.transform.GetChild(1).gameObject.SetActive(false);
		//비밀번호 입력창 호출
		computer.transform.GetChild(2).gameObject.SetActive(true);
		//잠금화면에서 ESC버튼 종료를 안만들어 놓을 경우 이거쓰면 됨
		R_GameManager.instance.computerUI.gameObject.SetActive(false);
	}
}
