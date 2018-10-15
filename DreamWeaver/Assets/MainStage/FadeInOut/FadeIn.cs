using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float animTime = 2f; // Fade 애니메이션 재생 시간

    Image fadeImage; // Image 컴퍼넌트 참조 변수

    float start = 1f;
    float end = 0f;
    float time = 0f;

    bool isPlaying = false;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFadeAnim()
    {
        // 애니메이션 재생중이면 중복 재생 안되도록 리턴
        if (isPlaying == true)
            return;

        StartCoroutine("PlayFadeIn");
    }

    // Fade 애니메이션 메소드
    IEnumerator PlayFadeIn()
    {
        isPlaying = true;

        // 이미지 색상 값 읽어오기.
        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animTime; // 2초동안 재생될수 있도록 시간 나누기
            color.a = Mathf.Lerp(start, end, time); // 알파값 계산

            fadeImage.color = color; // 계산한 알파 값 다시 설정.
            yield return null;
        }

        isPlaying = false;
    }
}
