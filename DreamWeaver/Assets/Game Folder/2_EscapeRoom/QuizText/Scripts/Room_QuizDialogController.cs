using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room_QuizDialogController : MonoBehaviour
{

    //  변수
    public float typingDelay = 0.1f;
    public float skipDelay = 0.2f;


    // 전체 대화창의 내용 (문자배열)
    string[] fulltext;

    // 전체 대화창의 개수
    int dialog_cnt;

    // 현재 대화창 위치
    int cnt;

    // 현재 대화창의 전체 내용
    string currentText;

    // 현재 텍스트 타이핑 상태(full : 끝, cut : 딜레이 생략)
    bool text_full;
    bool text_cut;

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // 최초 텍스트 시작호출
    public void Get_Typing()
    {
        //재사용을 위한 변수초기화
        text_full = false;
        text_cut = false;
        cnt = 0;

        // 퀴즈 내용 받아오기
        fulltext = Room_QuizManager.Instance.GetDialog();

        // 퀴즈 내용 개수 받아오기
        dialog_cnt = fulltext.Length;

        //타이핑 코루틴시작
        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        //모든텍스트 종료
        if (cnt >= dialog_cnt)
        {
            //text_exit = true;
            StopCoroutine("ShowText");
            transform.parent.parent.GetComponent<Room_QuizController>().EndEvent();
        }
        else
        {
            //기존문구clear
            currentText = "";
            //타이핑 시작
            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                //타이핑중도탈출
                if (text_cut == true)
                {
                    break;
                }
                //단어하나씩출력
                currentText = _fullText[cnt].Substring(0, i + 1);
                text.text = currentText;
                yield return new WaitForSeconds(typingDelay);
            }
            
            //탈출시 모든 문자출력
            //Debug.Log("Typing 종료");
            text.text = _fullText[cnt];
            yield return new WaitForSeconds(skipDelay);

            //스킵_지연후 종료
            //Debug.Log("Enter 대기");
            text_full = true;
        }
    }

    // 다음버튼함수와 연결짓기
    public void End_Typing()
    {
        //다음 텍스트 호출
        if (text_full == true)
        {
            cnt++;
            text_full = false;
            text_cut = false;
            StartCoroutine(ShowText(fulltext));
        }
        //텍스트 타이핑 생략
        else
        {
            text_cut = true;
        }
    }

}
