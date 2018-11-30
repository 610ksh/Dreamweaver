using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_EaseType : BaseITweenArg
	{
		public Args_EaseType ()
		{
			argName = "easetype";
			argDisplayName = "Ease Type";

			typeOfArg = BaseITweenType.TypeOfArg.easeType;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.EaseType, DisplayType.String };
			typeOfDisplay = DisplayType.EaseType;
		}

	}

}
