using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour 
{
    //오브젝트의 zPositon값을 업데이트
    public float positionSpeed = 0.01f;
    public float maxValue = 3.0f;

    Vector3 originPos;
    float pos;
    
    float timeWait;

	// Use this for initialization
	void Start () 
    {
        //오브젝트의 원래 위치 저장
        originPos = gameObject.transform.localPosition;
        pos = originPos.z;

        timeWait = Random.Range(0, 5.0f);
    }
	
	// Update is called once per frame
	void Update () 
    {
        StartCoroutine(UpdatePos());
    }

    //변화 시작 딜레이
    IEnumerator UpdatePos() 
    {
        yield return new WaitForSeconds(timeWait);

        pos -= positionSpeed;

        if (pos < -maxValue || pos > originPos.z)
        {
            positionSpeed *= -1;
        }

        transform.localPosition = new Vector3(originPos.x, originPos.y, pos);

      
    }
}
