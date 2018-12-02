using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnUpdateTarget : BaseITweenArg
	{
		public Args_OnUpdateTarget ()
		{
			argName = "onupdatetarget";
			argDisplayName = "On Update Target";

			typeOfArg = BaseITweenType.TypeOfArg.onUpdateTarget;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.GameObject };
			typeOfDisplay = DisplayType.GameObject;
		}

	}

}
