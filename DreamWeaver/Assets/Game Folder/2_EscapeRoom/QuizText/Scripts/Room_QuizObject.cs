using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_QuizObject : MonoBehaviour {

    // 퀴즈 내용
    public string quizDialog;

    // 퀴즈 오브젝트 이름
    string quiz_name;
	
    // 퀴즈 이름 설정
    public string quizName
    {
        get
        {
            return quiz_name;
        }
        set
        {
            quiz_name = value;
            Debug.Log(quiz_name);
        }
    }

}
