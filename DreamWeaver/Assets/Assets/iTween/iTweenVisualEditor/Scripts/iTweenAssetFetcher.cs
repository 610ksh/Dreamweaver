using UnityEngine;
using System.Collections;
using HiziProjects;

//[CreateAssetMenu (menuName = "AssetFetcher")]
[System.Serializable]
public class iTweenAssetFetcher : ScriptableObject
{
	public BaseITweenType[] allTypes;

	public iTweenAssetFetcher ()
	{
		allTypes = new BaseITweenType[System.Enum.GetNames (typeof(BaseITweenType.TypeOfAnimation)).Length];
	}
}

