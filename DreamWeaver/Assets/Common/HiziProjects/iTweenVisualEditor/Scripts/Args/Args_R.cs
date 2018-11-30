using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_R : BaseITweenArg
	{
		public Args_R ()
		{
			argName = "r";
			argDisplayName = "R";

			typeOfArg = BaseITweenType.TypeOfArg.r;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
