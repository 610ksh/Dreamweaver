using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Plyaer_MouseRotation : MonoBehaviour
{
    // X축 회전, Y축 회전값을 열겨형으로 만듬
    public enum RotationAxis
    {
        MouseX = 1, // 마우스 좌우(Player에 넣기)
        MouseY = 2 // 마우스 상하(카메라에 넣기)
    }

    // 회전축 기본값은 X축
    public RotationAxis axes = RotationAxis.MouseX;

    // 민감도 좌우
    public float sensHorizontal = 3.0f;
    // 민감도 상하
    public float sensVertical = 3.0f;

    // X축 회전각 초기값 설정
    float _rotationX;

    // 상하 최고 최하 각도값
    public float minVert = -60.0f;
    public float maxVert = 45.0f;

    private void Start()
    {
        // X축 회전 초기값 기록
        _rotationX = transform.localEulerAngles.x;
    }

    void FixedUpdate()
    {
        if (R_GameManager.instance.GetPlayerRotation())
        {
            // 마우스 오른쪽 버튼 클릭시
            if (Input.GetMouseButton(1))
            {
                // 좌우 회전이라면 (Mouse X)
                if (axes == RotationAxis.MouseX)
                {
                    // 좌우 회전
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
                }
                // 상하 회전이라면 (Mouse Y)
                else if (axes == RotationAxis.MouseY)
                {
                    _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
                    _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

                    float rotationY = transform.localEulerAngles.y;

                    transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

                }
            }
        }
    }
}
