using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_QuizManager : Singleton<Room_QuizManager>
{
    
    // Quiz UI 오브젝트
    public GameObject quizUI;
    // Quiz UI 첫번째 자식 Button
    Transform quizButton;
    RectTransform quizButtonPosition;
    // QuizObject 스크립트 컴포넌트
    Room_QuizObject quizObject;


    // 플레이어 Raycasting 정보
    public Room_PlayerQuizRaycasting playerRaycasting;

    // 가장먼저 실행되어 할당.
    void Awake()
    {
        quizButton = quizUI.transform.GetChild(0);
        quizButtonPosition = quizUI.transform.GetChild(0).GetComponent<RectTransform>();
    }

    /// <summary>
    /// Player 정보
    /// </summary>
    /// <param name="isRaycasting"></param>

    // 플레이어 Raycasting 설정
    public void SetRaycasting(bool isRaycasting)
    {
        playerRaycasting.SetIsRaycasting(isRaycasting);
    }

    /// <summary>
    /// Quiz UI 정보
    /// </summary>
    /// <returns></returns>


    // Quiz UI 활성화 상태
    public bool IsQuizUI()
    {
        // 버튼 UI가 활성화 여부
        if (quizButton.gameObject.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 버튼 UI를 활성화를 설정한다
    public void SetQuizButtonState(bool state)
    {
        quizButton.gameObject.SetActive(state);
    }

    // 시작버튼 위치를 설정
    public void SetButtonPosition(Vector3 pos)
    {
        quizButtonPosition.position = pos;
    }

    /// <summary>
    /// QuizObject 정보
    /// </summary>

    // 현재 활성화된 퀴즈 오브젝트 이름
    public string GetQuizName()
    {
        // 예외처리
        if (quizObject)
        {
            return quizObject.quizName;
        }
        else
        {
            Debug.Log("스크립트 에러로 null을 return합니다");
            return null;
        }
    }

    // 현재 활성화된 퀴즈 이름 설정
    public void SetQuizName(string name)
    {
        // 예외처리
        if (quizObject)
        {
            quizObject.quizName = name;
        }
        else
        {
            Debug.Log("스크립트 에러로 null을 return합니다");
        }
    }

    // QuizObject 스크립트 게임 오브젝트로 받아오기
    public void SetQuizScript(Room_QuizObject script)
    {
        quizObject = script;
    }

    // QuizObject 퀴즈내용 string배열 받아오기
    public string GetDialog()
    {
        return quizObject.quizDialog;
    }
}