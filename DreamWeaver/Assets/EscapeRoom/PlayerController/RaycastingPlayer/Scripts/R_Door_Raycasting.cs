using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Door_Raycasting : MonoBehaviour
{

    public float rayDistance = 5.0f;

    void Start()
    {

    }

    void Update()
    {
        // 메인카메라의 화면에서 마우스 커서 위치값을 현재위치 기준으로 Ray값으로 변환 (현재 카메라 위치 ~ 마우스 커서 위치)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 게임화면에서는 안보이는 Ray 선을 표기. (시작위치,방향과 거리,색깔)
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        // Ray충돌처리가 발생하면 할당되는 변수
        RaycastHit hit;

        // 만약 카메라 화면에서 마우스 커서가 오브젝트와 충돌하면 실시간 무한 true 반환.
        if (Physics.Raycast(ray, out hit))
        {
            // 충돌했던 오브젝트의 태그가 Door 이고, 부딪힌 오브젝트(hit)의 위치가 사용자 지정 변수 거리보다 작으면(지정된 사정 거리 내에 있다면)
            if (hit.transform.tag.Equals("Door") && hit.distance < rayDistance)
            {
                // 마우스 왼쪽 버튼이 눌렸다면
                if (Input.GetMouseButtonDown(0))
                {
                    // 부딪힌 오브젝트의 컴포넌트중 DoorMove 스크립트의 Movement()함수를 실행
                    hit.transform.GetComponent<R_Door_DoorMove>().MoveSignal();
                }
            }
        }
    }
}
