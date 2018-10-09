using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Password_ButtonEvent : MonoBehaviour
{
    // 열라고 하는 문
    // ※ 사용하려면 반드시 열라는 오브젝트를 넣어줘야합니다!!
    public GameObject door;
    
    // 숫자입력시 나타나는 텍스트창
    public Text outputNum;
    
    // KeyPad 정답
    public string answer = "1234";

    // 숫자를 누르면 텍스트에 출력
    public void ClickNum(string num)
    {
        outputNum.text += num;
    }

    // 빨간색 버튼 누르면 텍스트 초기화
    public void Cancel()
    {
        outputNum.text = "";
    }

    // 초록색 버튼 누르면 정답과 비교
    public void CheckNum()
    {
        // 현재 입력된 텍스트와 정답 비교
        if (outputNum.text == answer)
        {
            // 정답이 맞다면 문 오브젝트의 문열림 함수호출
            door.GetComponent<R_Door_DoorMove>().MoveSignal();
            // 텍스트 초기화
            outputNum.text = "";
            // 패스워드 UI 비활성
            gameObject.SetActive(false);
        }
        // 비밀번호가 정답과 틀리다면 초기화
        else
        {
            outputNum.text = "";
        }
    }
}
