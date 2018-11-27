using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObject : MonoBehaviour {

    // 대화내용 변수
    public string[] dialog;

    public string[] GetDialog()
    {
        return dialog;
    }
}
