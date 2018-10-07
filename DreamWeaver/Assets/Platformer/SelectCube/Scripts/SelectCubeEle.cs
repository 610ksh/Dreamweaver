using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCubeEle : MonoBehaviour
{

    public Material targetMat;
    public GameObject preventCollider;

    public bool isSelected = false;
    public bool isPlayerStay = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            //자식으로부터 isSelected값이 바뀌면
            //큐브의 색을 바꾼다.
            ChangeCubeColor();
            //한번 선택된 발판을 다시 밟지 못하게 한다 
            PreventEnterAgain();
        }
    }
    void ChangeCubeColor()
    {
        GetComponent<MeshRenderer>().material = targetMat;
    }
    void PreventEnterAgain()
    {
        if (!isPlayerStay)
            preventCollider.SetActive(true);
    }

}
