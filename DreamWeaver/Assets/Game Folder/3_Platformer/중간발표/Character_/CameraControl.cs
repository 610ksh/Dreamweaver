using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float cameraDistance = 4.0f; //카메라와 Target의 거리를 지정합니다.
    public float cameraHeight = 1.2f; // 카메라가 위치할 높이를 지정합니다.

    public float heightDamping = 2.0f; 
    public float rotationDamping = 10.0f;

    public GameObject target; //player

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    void LateUpdate() // 카메라 조정에 관련된 코드는 주로 LateUpdate에 쓴다고 합니다.
    {
        CameraTrace();
    }


    void CameraTrace()
    {
        if (target == null)
            target = GameObject.FindWithTag("Player"); //Player태그를 가진 오브젝트를 가져옵니다.
        else
        {
            float wantedRotationAngle = target.transform.eulerAngles.y; // 카메라가 이동해야 할 회전각(타겟 오브젝트의 y각도(Angle) 값)
            float wantedHeight = target.transform.position.y + cameraHeight; //카메라가 이동해야 할 높이(타겟오브젝트의 y좌표값 + 변수 추가분)


            float currentRotationAngle = transform.eulerAngles.y; // 현재 위치한(이동하기 전) 회전각
            float currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime); // 스무스한 이동을 위해, LerpAngle을 사용하여 이동합니다.
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime); 

            Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngle, 0f); //오일러 각을 쿼터니언으로 변환하고, Vector3형태로 만듭니다. (오일러 각 사용시 짐벌락 발생 가능)

            transform.position = target.transform.position; //카메라의 좌표를 타겟 위치로 옮긴 후
            transform.position -= currentRotation * Vector3.forward * cameraDistance; // 각을 설정하고 높이를 올립니다.
            //transform.position += Vector3.up * cameraHeight;
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
            transform.LookAt(target.transform); //카메라가 타겟을 바라보게 합니다. 
        }
    }
}
