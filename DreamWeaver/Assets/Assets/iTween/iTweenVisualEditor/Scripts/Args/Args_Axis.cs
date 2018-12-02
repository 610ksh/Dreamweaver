using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Axis : BaseITweenArg
	{
		public Args_Axis ()
		{
			argName = "axis";
			argDisplayName = "Axis";

			typeOfArg = BaseITweenType.TypeOfArg.axis;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.String };
			typeOfDisplay = DisplayType.String;
		}

	}

}
