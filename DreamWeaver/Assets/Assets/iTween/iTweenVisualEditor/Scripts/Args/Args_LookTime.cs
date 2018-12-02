using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_LookTime : BaseITweenArg
	{
		public Args_LookTime ()
		{
			argName = "looktime";
			argDisplayName = "Look Time";

			typeOfArg = BaseITweenType.TypeOfArg.lookTime;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
