using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnStartTarget : BaseITweenArg
	{
		public Args_OnStartTarget ()
		{
			argName = "onstarttarget";
			argDisplayName = "On Start Target";

			typeOfArg = BaseITweenType.TypeOfArg.onStartTarget;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.GameObject };
			typeOfDisplay = DisplayType.GameObject;
		}

	}

}
