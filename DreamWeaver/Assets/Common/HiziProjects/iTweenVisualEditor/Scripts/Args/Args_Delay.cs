using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Delay : BaseITweenArg
	{
		public Args_Delay ()
		{
			argName = "delay";
			argDisplayName = "Delay";

			typeOfArg = BaseITweenType.TypeOfArg.delay;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
