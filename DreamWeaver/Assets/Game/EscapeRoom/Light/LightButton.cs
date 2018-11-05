using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightButton : MonoBehaviour
{

    string nextState = "OFF";
    bool isState = true;

    public Text text;

    public void Button()
    {
        //불 끄기
        if (isState)
        {
            nextState = "ON";
            isState = false;
            R_GameManager.instance.mainLight.SetActive(false);
        }
        //불 켜기
        else
        {
            nextState = "OFF";
            isState = true;
            R_GameManager.instance.mainLight.SetActive(true);
        }
    }

    public void ChangeString()
    {
        text.text = nextState;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
