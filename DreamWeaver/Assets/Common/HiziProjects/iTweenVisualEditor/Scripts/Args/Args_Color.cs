using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Color : BaseITweenArg
	{
		public Args_Color ()
		{
			argName = "color";
			argDisplayName = "Color";

			typeOfArg = BaseITweenType.TypeOfArg.color;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Color };
			typeOfDisplay = DisplayType.Color;
		}

	}

}
