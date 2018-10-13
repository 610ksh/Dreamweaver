using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Quiz_Controller : MonoBehaviour
{

    // 퀴즈 텍스트 내용
    public string[] dialog;
    // 텍스트 개수

    // 출력할 버튼 UI 오브젝트 받아오기
    public GameObject text;

    bool isActive = false;
    int activeCnt = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //// 활성화되었고, 한번만 실행함
        //if (isActive == true && activeCnt == 0)
        //{
        //    WriteDialog();
        //    ++activeCnt;
        //    Debug.Log("성공?");
        //    isActive = false;
        //    Debug.Log("성공ok");
        //}
        //else if (isActive == false && activeCnt == 1)
        //{
        //    activeCnt = 0;
        //}
    }

    void WriteDialog()
    {
        // 문자열 내용을 넘겨줌.
        for (int i = 0; i < dialog.Length; ++i)
        {
            // 전체 개수와 각각의 문자열을 넘김
            //text.transform.GetChild(0).GetComponent<R_Quiz_TypeWriterEffect>().Write(dialog[i], dialog.Length);
        }
    }

    public void ActiveSignal()
    {
        isActive = true;
    }
}
