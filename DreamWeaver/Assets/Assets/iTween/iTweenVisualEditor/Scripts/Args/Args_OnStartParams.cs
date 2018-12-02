using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnStartParams : BaseITweenArg
	{
		public Args_OnStartParams ()
		{
			argName = "onstartparams";
			argDisplayName = "On Start Params";

			typeOfArg = BaseITweenType.TypeOfArg.onStartParams;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Object };
			typeOfDisplay = DisplayType.Object;
		}

	}

}
