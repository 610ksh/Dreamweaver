using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_MoveToPath : BaseITweenArg
	{
		public Args_MoveToPath ()
		{
			argName = "movetopath";
			argDisplayName = "Move To Path";

			typeOfArg = BaseITweenType.TypeOfArg.moveToPath;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Bool };
			typeOfDisplay = DisplayType.Bool;
		}

	}

}
