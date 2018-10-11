﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player_Raycasting : MonoBehaviour
{

    // Raycasting 거리 변수
    public float rayDistance = 5.0f;

    bool isEvent = false;

    void Update()
    {
        // 메인카메라의 화면에서 마우스 커서 위치값을 현재위치 기준으로 Ray값으로 변환 (현재 카메라 위치 ~ 마우스 커서 위치)
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 게임화면에서는 안보이는 Ray 선을 표기. (시작위치,방향과 거리,색깔)
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        // Ray충돌처리가 발생하면 할당되는 변수
        RaycastHit hit;

        // 만약 카메라 화면에서 마우스 커서가 오브젝트와 충돌하면 실시간 무한 true 반환.
        if (Physics.Raycast(ray, out hit))
        {
            // 마우스 커서에 물체가 Quiz 태그 && 클릭 이벤트가 발생하지 않았다면
            if (hit.transform.tag.Equals("Quiz") && R_GameManager.instance.quiz.transform.GetChild(1).gameObject.activeSelf == false)
            {
                // 사정거리 안이라면
                if (hit.distance < rayDistance)
                {
                    // 메인 커서 이미지 감추기
                    Cursor.visible = false;
                    // 퀴즈 버튼 이미지 활성화
                    R_GameManager.instance.quiz.transform.GetChild(0).gameObject.SetActive(true);
                    // 퀴즈 버튼 이미지를 커서를 따라다니게 함.
                    R_GameManager.instance.quiz.transform.GetChild(0).GetComponent<RectTransform>().position = mousePosition;
                }
            }
            // 퀴즈 오브젝트와 닿지 않았고 && Cursor가 꺼져있다면
            else if (hit.transform.tag.Equals("Quiz") == false && Cursor.visible == false)
            {
                Cursor.visible = true;
                R_GameManager.instance.quiz.transform.GetChild(0).gameObject.SetActive(false);
            }

            // 자동문을 만났을때
            if (hit.transform.tag.Equals("Door"))
            {
                if (hit.distance < rayDistance)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.GetComponent<R_Door_DoorMove>().MoveSignal();
                    }
                }

            }

            // PasswordDoor을 만났을때
            if (hit.transform.tag.Equals("PasswordDoor"))
            {
                if (hit.distance < rayDistance)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        R_GameManager.instance.keypad.gameObject.SetActive(true);
                        GetComponent<R_Player_Movement>().SetMove(false);
                        isEvent = true;
                    }
                }
            }
        }
    }

    public void SetIsEvent(bool isEvent)
    {
        this.isEvent = isEvent;
    }

    public bool GetIsEvent()
    {
        return isEvent;
    }
}
