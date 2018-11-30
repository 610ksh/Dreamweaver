using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_IsLocal : BaseITweenArg
	{
		public Args_IsLocal ()
		{
			argName = "islocal";
			argDisplayName = "Is Local";

			typeOfArg = BaseITweenType.TypeOfArg.isLocal;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Bool };
			typeOfDisplay = DisplayType.Bool;
		}

	}

}
