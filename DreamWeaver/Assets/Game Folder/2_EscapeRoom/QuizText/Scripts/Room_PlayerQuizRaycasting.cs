using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_PlayerQuizRaycasting : MonoBehaviour
{
    public float rayDistance;
    int layerMask;

    // 레이캐스팅을 실행 여부
    bool isRaycasting = true;

    private void Start()
    {
        // layerMask 설정
        layerMask = 1 << LayerMask.NameToLayer("Quiz");
    }
    private void FixedUpdate()
    {
        // 마우스 위치값 설정
        Vector3 mousePosition = Input.mousePosition;
        // 화면상 마우스 위치값을 Ray값으로 설정
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (isRaycasting)
        {
            // 디버깅용 Ray
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
            // Quiz Layer만 충돌검사
            if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
            {
                if(hit.collider.tag=="Item")
                {
                    // 버튼이 활성화 되어있다면
                    if (Room_QuizManager.Instance.IsQuizUI())
                    {
                        Debug.Log("커서를 끕니다");
                        //메인 커서를 끈다
                        Cursor.visible = false;

                        //충돌한 퀴즈 오브젝트의 이름과 현재 활성화된 버튼의 퀴즈 오브젝트 이름이 같은지 체크
                        if (hit.collider.name == Room_QuizManager.Instance.GetQuizName())
                        {
                            // 커서에 퀴즈 이미지 버튼을 따라다니게 한다
                            Debug.Log("동일한 퀴즈 버튼이 켜져있으므로 따라다닙니다.");
                            Room_QuizManager.Instance.SetButtonPosition(mousePosition);
                        }
                        // 충돌한 오브젝트가 다르다면 => 붙어있는 다른 퀴즈와 충돌했다면
                        else
                        {
                            // 기존 버튼을 종료하고 리턴.
                            Debug.Log("붙어있는 퀴즈! 기존 버튼을 종료합니다.");
                            Room_QuizManager.Instance.SetQuizButtonState(false);
                        }
                    }
                    // 버튼이 비활성화 상태라면
                    else
                    {
                        Debug.Log("버튼이 꺼져있네요. 새로운 퀴즈 버튼을 생성합니다.");

                        // 부딪힌 물체가 갖고 있는 스크립트를 가져온다(물체가 퀴즈내용을 가지고 있음)
                        Room_QuizObject script = hit.collider.GetComponent<Room_QuizObject>();

                        // QuizObject 스크립트를 게임매니저에게 넘겨줌
                        if (script)
                        {
                            Room_QuizManager.Instance.SetQuizScript(script);
                        }
                        // 예외처리
                        else
                        {
                            Debug.Log("error : QuizObject 스크립트를 인식하지 못했습니다");
                        }

                        // 마우스 위치에 이미지를 생성
                        Room_QuizManager.Instance.SetButtonPosition(mousePosition);
                        // 퀴즈 버튼 이미지를 생성한다.
                        Room_QuizManager.Instance.SetQuizButtonState(true);
                        // 퀴즈 버튼의 이름을 설정한다.
                        Room_QuizManager.Instance.SetQuizName(hit.collider.name);
                    }
                }
            }
            // 퀴즈가 아닌 곳에 레이캐스팅 됐을때
            else
            {
                // 만약 이전에 켜져있었던 버튼이 있었다면 위치 따라다니기
                // 메인 커서를 활성화 시키고,
                Cursor.visible = true;
                // 퀴즈 버튼 UI를 끈다
                if (Room_QuizManager.Instance.IsQuizUI())
                {
                    Room_QuizManager.Instance.SetQuizButtonState(false);
                }
                // QuizScript를 null로 초기화
                Room_QuizManager.Instance.SetQuizScript(null);

            } // Physics.Raycast
        } // isRaycasting
    } // FixedUpdate


    // isRaycasting 설정
    public void SetIsRaycasting(bool isRaycasting)
    {
        this.isRaycasting = isRaycasting;
    }

    // isRaycasting 반환
    public bool GetIsRaycasting()
    {
        return isRaycasting;
    }
}
