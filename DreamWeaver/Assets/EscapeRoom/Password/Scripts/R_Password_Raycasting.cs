using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Password_Raycasting : MonoBehaviour
{

    // 레이캐스팅 거리
    public float rayDistance = 5.0f;

    // 이미지파일
    public GameObject Keypad;

    void Update()
    {
        // 마우스 커서 위치 Ray값 계산
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        // 마우스 왼쪽 버튼을 클릭하면
        if (Input.GetMouseButtonDown(0))
        {
            // ray 충돌값을 hit에 넣어줌
            if (Physics.Raycast(ray, out hit))
            {
                // 충돌한 오브젝트 태그가 Door이고, 충돌한 물체와 화면의 거리가 사정거리 내에 있으면
                if (hit.collider.tag.Equals("PasswordDoor") && hit.distance < rayDistance)
                {
                    KeypadController();
                }
            }

        }

    }

    // 키패드 이미지 활성화
    void KeypadController()
    {
        Keypad.gameObject.SetActive(true);
    }
}
