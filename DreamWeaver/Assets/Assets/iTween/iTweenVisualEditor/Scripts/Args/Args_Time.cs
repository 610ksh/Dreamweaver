using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Time : BaseITweenArg
	{
		public Args_Time ()
		{
			argName = "time";
			argDisplayName = "Time";

			typeOfArg = BaseITweenType.TypeOfArg.time;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
