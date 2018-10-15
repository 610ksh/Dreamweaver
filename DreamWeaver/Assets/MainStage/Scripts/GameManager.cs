using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerCamera;
    public float cameraRotSpeed;

    public Transform playerPos;

    // Fade Out UI 생성
    public GameObject fadeOutUI;
    bool isFade = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // -5 지점부터 -17지점까지 카메라 위로 회전 (억지코드)
        if (playerPos.position.y < -5f && playerPos.position.y > -17f)
        {
            playerCamera.transform.Rotate(-Vector3.right * cameraRotSpeed);
        }

        if (playerPos.position.y < -15f)
        {
            
            playerCamera.transform.Rotate(Vector3.forward * 5f);

            if (!isFade)
            {
                isFade = true;
                fadeOutUI.gameObject.SetActive(true);
                fadeOutUI.transform.GetChild(0).GetComponent<FadeOut>().StartFadeAnim();
            }
        }


        if (playerPos.position.y < -200f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
