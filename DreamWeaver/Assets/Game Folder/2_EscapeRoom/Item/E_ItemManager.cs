using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ItemManager : Singleton<E_ItemManager> {

    // C# 벡터는 리스트로 구현되어있다.
    public List<string> itemList = new List<string>();

    public GameObject Lock;

	void Start () {
        // 디버깅용 코루틴
        StartCoroutine(Temp());
	}
	
	void Update () {

        if (itemList.Exists(x => x == "BoxKey"))
        {
            Lock.SetActive(true);
        }
    }

    // 잘 들어가는지 테스트용
    IEnumerator Temp()
    {
        while(true)
        {
            foreach (var item in itemList)
            {
                Debug.Log(item);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    public bool CheckItem()
    {
        int count = 0;
        foreach (var item in itemList)
        {
            if(item=="Keyboard"||item=="Mouse"||item=="MousePad")
            {
                count++;
            }
        }

        if (count == 3)
            return true;
        else
            return false;
    }
}
