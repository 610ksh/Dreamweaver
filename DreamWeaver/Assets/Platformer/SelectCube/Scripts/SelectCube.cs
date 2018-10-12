using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCube : MonoBehaviour {
    public GameObject disappearingWall;

    bool isAllChildSelected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //자식 큐브들이 모두 선택되었는지 검사 
        if(isAllChildSelected)
        {
            DisappearWall();
            Debug.Log("all child selected");
        }
        else 
        {
            int count = 0;
            for (int i = 0; i < transform.childCount; ++i)
            {

                if(this.transform.GetChild(i).GetComponent<SelectCubeEle>().isSelected)
                {
                    ++count; 
                }
                if (count == transform.childCount) isAllChildSelected = true;
            }
        }
	}
    void DisappearWall()
    {
        //public으로 받아온 벽을 밀어버린다
        if(disappearingWall)
            disappearingWall.transform.Translate(-1, 0, 0);
        Destroy(disappearingWall, 1);
    }

}
