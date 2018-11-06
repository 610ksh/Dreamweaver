using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Room_QuizController : MonoBehaviour {

    // Quiz UI 자식 버튼 4개 배열화
    Transform[] buttonUI = new Transform[4];


    private void Start()
    {
        // 퀴즈버튼 초기화
        for(int i=0;i<buttonUI.Length; ++i)
        {
            buttonUI[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {

    }

    public void QuizButtonClick()
    {
        // 퀴즈 버튼(1) 비활성화
        SetQuizButton(false);
        // 버튼 2,3,4 활성화
        SetQuizDialog(true);
        // 커서 활성화
        Cursor.visible = true;
    }

    // 퀴즈 버튼 활성화 설정 (1번째 버튼)
    public void SetQuizButton(bool isQuizButton)
    {
        buttonUI[0].gameObject.SetActive(isQuizButton);
    }

    // 퀴즈 Dialolg 활성화 설정 (2,3,4 버튼)
    public void SetQuizDialog(bool isQuizDialog)
    {
        buttonUI[1].gameObject.SetActive(isQuizDialog);
        buttonUI[2].gameObject.SetActive(isQuizDialog);
        buttonUI[3].gameObject.SetActive(isQuizDialog);
    }
    
    // Event가 종료되면
    public void EndEvent()
    {
        // 버튼 2,3,4를 끈다
        SetQuizDialog(false);
        // 레이캐스팅을 재시작한다.
        Room_QuizManager.Instance.SetRaycasting(true);
    }
}