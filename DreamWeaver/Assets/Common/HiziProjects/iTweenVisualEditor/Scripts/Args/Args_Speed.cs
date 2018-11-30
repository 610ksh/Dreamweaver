using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Speed : BaseITweenArg
	{
		public Args_Speed ()
		{
			argName = "speed";
			argDisplayName = "Speed";

			typeOfArg = BaseITweenType.TypeOfArg.speed;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
