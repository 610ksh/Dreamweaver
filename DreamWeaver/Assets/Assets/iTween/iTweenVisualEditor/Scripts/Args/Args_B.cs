using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_B : BaseITweenArg
	{
		public Args_B ()
		{
			argName = "b";
			argDisplayName = "B";

			typeOfArg = BaseITweenType.TypeOfArg.b;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
