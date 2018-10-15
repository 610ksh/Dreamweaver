using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startUI : MonoBehaviour
{

    float alpha = 255;
    //bool isFadingOut = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fadeOut()
    {
        Debug.Log("fadeOut");
        while (alpha > 0)
        {
            if (alpha >= 0)
            {
                alpha -= 0.1f;
                GetComponent<RawImage>().color = new Color(255, 255, 255, alpha / Time.deltaTime);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }


    }

    public void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
