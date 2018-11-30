using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBookManager : Singleton<PBookManager> {

    public ExampleUIController pBookUI;

    // 전방 카메라
    public GameObject Cam;

    // 책 닫으면
    public void ClosePBookUI()
    {
        pBookUI.gameObject.SetActive(false);
        Cam.gameObject.SetActive(false);
    }

    // 책 열면
    public void OpenBook()
    {
        Cam.gameObject.SetActive(true);
    }
}
