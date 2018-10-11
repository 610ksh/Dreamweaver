using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Quiz_ButtonEvent : MonoBehaviour
{

    private void Update()
    {
        // 퀴즈 내용이 실행됐다면 (조사하기 버튼 클릭후)
        if (transform.GetChild(1).gameObject.activeSelf)
        {
            // Raycasting의 isEvent가 false라면 true로 바꿔줌
            if (R_GameManager.instance.player.GetComponent<R_Player_Raycasting>().GetIsEvent()==false)
            {
                R_GameManager.instance.player.GetComponent<R_Player_Raycasting>().SetIsEvent(true);
            }

            //커서가 없다면 다시 보이게 하기
            if (Cursor.visible == false)
            {
                Cursor.visible = true;
            }
        }
    }

    public void Click()
    {
        //자식 세번째 오브젝트를 비활성화 시킨다. (버튼)
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        R_GameManager.instance.player.GetComponent<R_Player_Movement>().SetMove(false);
    }

    // 모두 종료시키기
    public void EndEvent()
    {
        //Debug.Log("안전하게 종료");
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        R_GameManager.instance.player.GetComponent<R_Player_Movement>().SetMove(true);
    }
}
