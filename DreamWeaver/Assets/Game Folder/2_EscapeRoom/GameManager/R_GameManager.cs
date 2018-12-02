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
    R_Player_Movement playerMovement; // 키보드 움직임 제한
    bool isRotate = false; // 카메라 회전 제한

    // 메인 빛
    public GameObject mainLight;

    // 불 버튼
    public GameObject lightButtonUI;
    RectTransform lightButtonPos;

    // Fade Effect UI
    public GameObject fadeEffectUI;
    bool isFade = false; // Fade Effect 현재 실행 여부 변수

    // fadeIn 변수
    Transform fade;

    // MessageUI
    public GameObject messageUI;

    // 컴퓨터 UI
    public GameObject computerUI;
    public GameObject computerSet; // 컴퓨터 도구
    public GameObject computerScreen;

    // Box iTween
    public GameObject boxHead;

    // 파티클
    public GameObject particle;

    void Awake()
    {
        // 싱글톤
        instance = this;
        playerMovement = player.GetComponent<R_Player_Movement>();
        PlayerMovement(false);
    }

    private void Start()
    {
        //iTween.MoveTo(boxHead, iTween.Hash("Path", iTweenPath.GetPath("Path1"), "time", 10f));

        // Fade 캐싱
        fade = fadeEffectUI.transform.GetChild(0);

        // Fade 실행
        fade.gameObject.SetActive(true);
        fade.GetComponent<FadeEffect>().StartFade();

        // 전등 버튼 UI 위치값 변수
        lightButtonPos = lightButtonUI.GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    fade.GetComponent<FadeEffect>().StartFade();
        //}

        // 13m 밑으로 떨어지면 FadeOut 시작
        if (player.transform.position.y < -13f)
        {
            fade.GetComponent<FadeEffect>().StartFade();
        }

        // 80m 밑으로 떨어지면 플랫포머로
        if (player.transform.position.y < -40f)
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

    public void PlayerMovement(bool isMove)
    {
        playerMovement.SetMove(isMove);
    }

    public bool GetPlayerRotation()
    {
        return isRotate;
    }
    public void SetPlayerRotation(bool isRotate)
    {
        this.isRotate = isRotate;
    }

    // 박스 itween
    public void OpenLock()
    {
        iTween.MoveTo(boxHead, iTween.Hash("Path", iTweenPath.GetPath("Path1"), "time", 10f, "easyType", "easelnCirc"));
    }
}