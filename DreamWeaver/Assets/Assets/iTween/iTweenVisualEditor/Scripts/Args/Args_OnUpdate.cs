using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnUpdate : BaseITweenArg
	{
		public Args_OnUpdate ()
		{
			argName = "onupdate";
			argDisplayName = "On Update";

			typeOfArg = BaseITweenType.TypeOfArg.onUpdate;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.String };
			typeOfDisplay = DisplayType.String;
		}

	}

}
