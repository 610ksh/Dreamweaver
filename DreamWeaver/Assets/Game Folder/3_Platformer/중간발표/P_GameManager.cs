using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_GameManager : MonoBehaviour
{

    //싱글톤
    public static P_GameManager instance;

    // Fade In UI
    public GameObject fadeInUI;

    // Fade Out UI
    public GameObject fadeOutUI;
    bool isCollision = false;
    float colTime = 0f;

    // Player
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        fadeInUI.gameObject.SetActive(true);
        fadeInUI.transform.GetChild(0).GetComponent<FadeIn>().StartFadeAnim();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.y < -30f)
        {
            SceneManager.LoadScene(2);
        }


        // 플라토닉 충돌 이후 누적시간 검사
        if (isCollision)
        {
            colTime += Time.deltaTime;
        }

        // 플라토닉 충돌 시간이 7초 이상흐르면 처음 씬으로 돌아가라
        if (colTime > 4.5f)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void SetCollision(bool isCollision)
    {
        this.isCollision = isCollision;
    }
}
