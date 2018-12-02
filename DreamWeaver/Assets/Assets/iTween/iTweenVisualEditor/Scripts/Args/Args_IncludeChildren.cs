using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_IncludeChildren : BaseITweenArg
	{
		public Args_IncludeChildren ()
		{
			argName = "includechildren";
			argDisplayName = "Include Children";

			typeOfArg = BaseITweenType.TypeOfArg.includeChildren;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Bool };
			typeOfDisplay = DisplayType.Bool;
		}

	}

}
