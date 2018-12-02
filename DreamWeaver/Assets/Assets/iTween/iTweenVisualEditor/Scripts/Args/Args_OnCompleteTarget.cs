using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnCompleteTarget : BaseITweenArg
	{
		public Args_OnCompleteTarget ()
		{
			argName = "oncompletetarget";
			argDisplayName = "On Complete Target";

			typeOfArg = BaseITweenType.TypeOfArg.onCompleteTarget;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.GameObject };
			typeOfDisplay = DisplayType.GameObject;
		}

	}

}
