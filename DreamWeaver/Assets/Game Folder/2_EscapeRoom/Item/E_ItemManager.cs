using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ItemManager : Singleton<E_ItemManager> {


    //public GameObject player;

    // C# 벡터는 리스트로 구현되어있다.
    public List<string> itemList = new List<string>();


	void Start () {
        StartCoroutine(Temp());
	}
	
	void Update () {
		
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
            yield return new WaitForSeconds(5f);
        }
    }
}
