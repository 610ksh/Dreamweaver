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

    // Player
    public GameObject player;
    R_Player_Movement playerMovement;

    // 메인 빛
    public GameObject mainLight;

    // 불 버튼
    public GameObject lightButtonUI;
    RectTransform lightButtonPos;

    // Fade Effect UI
    public GameObject fadeEffectUI;
    // Fade Effect 현재 실행 여부 변수
    bool isFade = false;

    // fadeIn 변수
    GameObject fadeIn;

    // MessageUI
    public GameObject messageUI;

    void Awake()
    {
        // 싱글톤
        instance = this;
        playerMovement = player.GetComponent<R_Player_Movement>();
        playerMovement.SetMove(false);
    }

    private void Start()
    {
        // FadeIn 캐싱
        fadeIn = fadeEffectUI.transform.GetChild(0).gameObject;
        // FadeIn 실행
        fadeIn.SetActive(true);
        fadeEffectUI.transform.GetChild(0).GetComponent<FadeEffect>().StartFade();
        
        // 전등 버튼 UI 위치값 변수
        lightButtonPos = lightButtonUI.GetComponent<RectTransform>();
    }

    void Update()
    {
        // fadeIn이 끝나면
        if(!fadeIn.activeSelf)
        {
            // 플레이어 이동을 풀어준다.
            playerMovement.SetMove(true);
        }

        // 13m 밑으로 떨어지면 FadeOut 시작
        if (player.transform.position.y < -13f)
        {
            if (!isFade)
            {
                isFade = true;
                fadeEffectUI.transform.GetChild(1).gameObject.SetActive(true);
                fadeEffectUI.transform.GetChild(1).GetComponent<FadeEffect>().StartFade();
            }
        }

        // 80m 밑으로 떨어지면 플랫포머로
        if (player.transform.position.y < -80f)
        {
            SceneManager.LoadScene(2);
        }
    }

    // 불 버튼 위치 설정
    public void SetLightButtonPos(Vector3 pos)
    {
        lightButtonPos.position = pos;
    }

    // 최초 메시지 출력 함수
    public void StartDialog()
    {
        // 컨트롤러에 있는 
        messageUI.gameObject.SetActive(true);
        messageUI.GetComponent<MessageUIController>().StartDialog();
    }

}
