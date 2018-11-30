using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_X : BaseITweenArg
	{
		public Args_X ()
		{
			argName = "x";
			argDisplayName = "X";

			typeOfArg = BaseITweenType.TypeOfArg.x;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
