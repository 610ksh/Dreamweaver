using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnComplete : BaseITweenArg
	{
		public Args_OnComplete ()
		{
			argName = "oncomplete";
			argDisplayName = "On Complete";

			typeOfArg = BaseITweenType.TypeOfArg.onComplete;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.String };
			typeOfDisplay = DisplayType.String;
		}

	}

}
