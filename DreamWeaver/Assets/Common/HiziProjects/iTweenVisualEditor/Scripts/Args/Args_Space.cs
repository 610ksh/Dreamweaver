using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Space : BaseITweenArg
	{
		public Args_Space ()
		{
			argName = "space";
			argDisplayName = "Space";

			typeOfArg = BaseITweenType.TypeOfArg.space;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Space };
			typeOfDisplay = DisplayType.Space;
		}

	}

}
