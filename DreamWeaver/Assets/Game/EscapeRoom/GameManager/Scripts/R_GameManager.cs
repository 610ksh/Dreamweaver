﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_GameManager : MonoBehaviour
{

    // 싱글톤 적용
    public static R_GameManager instance;

    // KeyPad 이미지
    public GameObject keypadUI;

    // Player
    public GameObject player;

    // 메인 빛
    public GameObject mainLight;

    // 불 버튼
    public GameObject lightButtonUI;
    RectTransform lightPos;

    // Fade In UI
    public GameObject fadeInUI;

    // Fade Out UI
    public GameObject fadeOutUI;
    bool isFade = false;
    
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fadeInUI.gameObject.SetActive(true);
        fadeInUI.transform.GetChild(0).GetComponent<FadeIn>().StartFadeAnim();
        lightPos = lightButtonUI.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (player.transform.position.y < -13f)
        {
            if (!isFade)
            {
                isFade = true;
                fadeOutUI.gameObject.SetActive(true);
                fadeOutUI.transform.GetChild(0).GetComponent<FadeOut>().StartFadeAnim();
            }
        }

        if (player.transform.position.y < -80f)
        {
            SceneManager.LoadScene(2);
        }
    }

    // 불 버튼 위치 설정
    public void SetLightButtonPos(Vector3 pos)
    {
        lightPos.position = pos;
    }
}
