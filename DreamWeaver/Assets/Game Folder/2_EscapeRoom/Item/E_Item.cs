using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 각각의 아이템 오브젝트에 들어갈 스크립트 입니다.
/// 오브젝트가 가지고 있을 아이템을 등록하면 됩니다.
/// </summary>

public class E_Item : MonoBehaviour
{
    // item 이름
    string itemName;

    // 상자 아이템의 이름
    public string[] keyName;

    void Start()
    {
        // 현재 오브젝트 이름을 변수에 넣음
        itemName = name;
    }
    
    // 아이템을 습득하면 발동하는 함수
    public void AcquireItem()
    {
        // 아이템 매니저에 추가해주기
        E_ItemManager.Instance.itemList.Add(itemName);

        // 비활성화 시키기
        gameObject.SetActive(false);
    }

    // ItemManager에 해당하는 아이템이 있으면 이벤트 발생
    public void OpenItem()
    {
        foreach (var item in E_ItemManager.Instance.itemList)
        {
            if (item == keyName[0])
            {
                Debug.Log("자물쇠를 열었습니다");
            }
        }
    }

}
