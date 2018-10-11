using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class R_Quiz_TypeWriterEffect : MonoBehaviour
{
    //  변수
	public float typingDelay=0.1f;
    public float skipDelay=0.2f;


    // 전체 대화창의 내용 (문자배열)
    public string[] fulltext;

    // 전체 대화창의 개수
    public int dialog_cnt;
    
    // 현재 대화창 위치
    int cnt;

    // 현재 대화창의 전체 내용
    string currentText;

    // 현재 텍스트 타이핑 상태(full : 끝, cut : 딜레이 생략)
    bool text_full;
    bool text_cut;
    
    // 최초 텍스트 시작호출
    public void Get_Typing()
    {
        //재사용을 위한 변수초기화
        text_full = false;
        text_cut = false;
        cnt = 0;

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
            transform.parent.parent.GetComponent<R_Quiz_ButtonEvent>().EndEvent();
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
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(typingDelay);
            }


            //탈출시 모든 문자출력
            //Debug.Log("Typing 종료");
            this.GetComponent<Text>().text = _fullText[cnt];
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
