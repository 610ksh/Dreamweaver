using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Y : BaseITweenArg
	{
		public Args_Y ()
		{
			argName = "y";
			argDisplayName = "Y";

			typeOfArg = BaseITweenType.TypeOfArg.y;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
