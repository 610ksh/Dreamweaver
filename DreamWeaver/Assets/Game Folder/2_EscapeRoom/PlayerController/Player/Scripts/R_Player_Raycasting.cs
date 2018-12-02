using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player_Raycasting : MonoBehaviour
{

    // Raycasting 거리 변수
    public float rayDistance = 5.0f;

    // 레이어 마스크
    int layerMask;

    // 현재 UI가 켜져있는게 있는지 체크
    bool isUIEvent = false;
    // 컴퓨터 UI 사용여부
    bool isComputer = false;

    private void Start()
    {
        // 레이어 등록 (레이어 EscapeRoom 추가해줘야함)
        layerMask = 1 << LayerMask.NameToLayer("EscapeRoom");
    }


    void FixedUpdate()
    {
        // 메인카메라의 화면에서 마우스 커서 위치값을 현재위치 기준으로 Ray값으로 변환 (현재 카메라 위치 ~ 마우스 커서 위치)
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 게임화면에서는 안보이는 Ray 선을 표기. (시작위치,방향과 거리,색깔)
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        // Ray충돌처리가 발생하면 할당되는 변수
        RaycastHit hit;

        // 만약 카메라 화면에서 마우스 커서가 오브젝트와 충돌하면 실시간 무한 true 반환.
        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {

            // Light 이름의 오브젝트를 만났을때
            if (hit.transform.name.Equals("LightSwitch"))
            {
                // 마우스 커서 없애기
                Cursor.visible = false;
                // light 버튼 UI 활성화
                R_GameManager.instance.lightButtonUI.SetActive(true);

                // light 버튼 UI 커서 따라다니기
                R_GameManager.instance.SetLightButtonPos(mousePosition);

                // UI 활성화
                isUIEvent = true;
            }

            // PowerBook 에셋을 만나면
            if (hit.transform.name == "Book")
            {
                // 버튼을 클릭하면
                if (Input.GetMouseButtonDown(0))
                {
                    // UI 켜기
                    PBookManager.Instance.pBookUI.gameObject.SetActive(true);
                    PBookManager.Instance.pBookUI.OpenBook();
                }
            }

            // Password 이름의 오브젝트를 만났을때
            if (hit.transform.name.Equals("Password"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // keypad UI를 활성화 시킨다.
                    R_GameManager.instance.keypadUI.gameObject.SetActive(true);
                    // 플레이어의 움직임을 일시적으로 멈춘다
                    GetComponent<R_Player_Movement>().SetMove(false);
                    // 이벤트 발생여부 체크
                    isUIEvent = true;
                }
            }

            // Item 태그를 만났을때
            if (hit.transform.tag == "Item")
            {
                Debug.Log("Item을 발견하다");
                // 마우스 버튼 클릭하면
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("아이템을 클릭했다");
                    // 해당하는 아이템이 발동된다.
                    if(hit.collider.GetComponent<E_Item>())
                        hit.collider.GetComponent<E_Item>().AcquireItem();
                    if(hit.collider.name=="BoxComputerSet")
                    {
                        // 파티클켜고
                        R_GameManager.instance.particle.gameObject.SetActive(true);
                    }
                }
            }

            // Box를 만났을때
            if (hit.transform.name == "Lock")
            {
                Debug.Log("박스를 확인했다");
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.GetComponent<E_Item>())
                    {
                        Debug.Log("박스를 확인했다2");
                        hit.collider.GetComponent<E_Item>().OpenItem();
                    }
                }
            }

            //Computer를 만났을 때
            if(isComputer)
            {
                if (hit.transform.name == "Computer")
                {
                    if (hit.distance < rayDistance)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            //computer UI 활성화
                            R_GameManager.instance.computerUI.gameObject.SetActive(true);
                            // 플레이어의 움직임을 멈춤
                            //GetComponent<R_Player_Movement>().SetMove(false);
                            //R_GameManager.instance.PlayerMovement(fals)
                            // 이벤트 발생 여부 체크
                            isUIEvent = true;
                        }
                    }
                }
            }

            //
            if(hit.transform.name == "Particle")
            {
                // 버튼을 누르면
                if(Input.GetMouseButtonDown(0))
                {
                    // 이펙트 종료하고 컴퓨터 설치
                    R_GameManager.instance.particle.gameObject.SetActive(false);
                    R_GameManager.instance.computerSet.gameObject.SetActive(true);
                    R_GameManager.instance.computerScreen.gameObject.SetActive(true);
                    isComputer = true;
                }
            }
        }

        // 레이캐스팅 안되면
        else
        {
            // 켜져 있다면 끄기
            if (R_GameManager.instance.lightButtonUI.activeSelf)
            {
                R_GameManager.instance.lightButtonUI.SetActive(false);
                isUIEvent = false;
                Cursor.visible = true;
            }
        }
    }

    public void SetUIEvent(bool isEvent)
    {
        this.isUIEvent = isEvent;
    }

    public bool GetUIEvent()
    {
        return isUIEvent;
    }
}
