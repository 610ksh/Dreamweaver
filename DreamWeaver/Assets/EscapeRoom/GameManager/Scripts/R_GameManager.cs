using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class R_GameManager : MonoBehaviour
{

    // 싱글톤 적용
    public static R_GameManager instance;

    // KeyPad 이미지
    public GameObject keypadUI;

    // Quiz 버튼
    public GameObject quiz;

    public GameObject quiz2;

    // Player
    public GameObject player;

    // 메인 빛
    public GameObject mainLight;

    // 불 버튼
    public GameObject lightButton;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (player.transform.position.y < -30)
        {
            SceneManager.LoadScene(2);
        }
    }
}
