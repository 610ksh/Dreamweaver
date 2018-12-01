using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    public float playTime = 5f; // Fade애니메이션 플레이시간
    Image fadeImage; // Fade 이미지 참조변수
    float startAlpha; // 시작할때 알파값
    float endAlpha; // 끝날때 알파값
    float time; // 실행시간

    bool isPlaying = false;

    // Fade Effect 열거형 (public으로 해야 외부에서 사용가능)
    public enum Effect
    {
        FadeIn,
        FadeOut,
    }

    // 열거형을 밖으로 뽑아내서 할당하고 싶을때
    Effect fadeEffect;

    //public void SetFadeEffect(int Effect)
    //{
    //    // 1이면 Fade In 밝아짐
    //    if (Effect == 1)
    //    {
    //        fadeEffect = FadeEffect.Effect.FadeIn;
    //    }
    //    // 1이면 Fade Out 어두워짐
    //    else
    //    {
    //        fadeEffect = FadeEffect.Effect.FadeOut;
    //    }
    //}

    // 시작하기전에 캐싱
    void Awake()
    {
        fadeImage = GetComponent<Image>();
        fadeEffect = Effect.FadeIn;
    }

    public void StartFade()
    {
        // 이미 실행된 경우는 중복재생을 막는다. (예외처리)
        if (isPlaying == true)
            return;
        // Fade 코루틴 시작.
        StartCoroutine(PlayFadeEffect(fadeEffect));
    }

    // FadeIn 애니메이션 코루틴
    IEnumerator PlayFadeEffect(Effect fadeEffect)
    {
        // 플레이 상태변수 true
        isPlaying = true;

        // 초기 이미지 칼라값 변수
        //Color initialColor = fadeImage.color;

        // 현재 이미지 칼라값을 변수로 저장
        Color color = fadeImage.color;

        time = 0f; // 시간 초기화

        // FadeIn 선택(검정 -> 투명)
        if (fadeEffect == Effect.FadeIn)
        {
            bool isStartDialog = false;
            startAlpha = 1;
            endAlpha = 0;
            // 알파값이 0이 되기전까지 실행
            while (color.a > 0f)
            {
                time += Time.deltaTime / playTime; // 작동시간 조절
                // 알파값 선형 보간법 1에서 0으로 점점 선형적으로 변함.
                color.a = Mathf.Lerp(startAlpha, endAlpha, time);
                // 바뀐 알파값을 현재 화면에 적용
                fadeImage.color = color;

                // 알파값이 0.5보다 작아지면 시작한다.
                if (color.a < 0.5f)
                {
                    if (!isStartDialog)
                    {
                        R_GameManager.instance.StartDialog();
                        isStartDialog = true;
                    }
                }
                yield return null;
            }
            this.fadeEffect = Effect.FadeOut;
        }

        // FadeOut 선택(투명 -> 검정)
        else if (fadeEffect == Effect.FadeOut)
        {
            startAlpha = 0;
            endAlpha = 1;
            // 알파값이 0이 되기전까지 실행
            while (color.a < 1f)
            {
                time += Time.deltaTime / playTime; // 작동시간 조절
                // 알파값 선형 보간법 1에서 0으로 점점 선형적으로 변함.
                color.a = Mathf.Lerp(startAlpha, endAlpha, time);
                // 바뀐 알파값을 현재 화면에 적용
                fadeImage.color = color;
                yield return null;
            }
            this.fadeEffect = Effect.FadeIn;
        }
        // 예외처리
        else
        {
            Debug.Log("에러 입니다");
            throw new System.ArgumentException("Fade 매개변수를 잘못 넣으셨습니다");
        }

        // 코루틴 종료
        isPlaying = false;

        // 오브젝트 끄기
        //gameObject.SetActive(false);

        // 초기 알파값으로 다시 조정
        //fadeImage.color = initialColor;
    }
}