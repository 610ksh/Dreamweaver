using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnStart : BaseITweenArg
	{
		public Args_OnStart ()
		{
			argName = "onstart";
			argDisplayName = "On Start";

			typeOfArg = BaseITweenType.TypeOfArg.onStart;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.String };
			typeOfDisplay = DisplayType.String;
		}

	}

}
