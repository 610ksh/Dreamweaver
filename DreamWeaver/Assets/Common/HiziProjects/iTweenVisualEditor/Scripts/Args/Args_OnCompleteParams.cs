using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnCompleteParams : BaseITweenArg
	{
		public Args_OnCompleteParams ()
		{
			argName = "oncompleteparams";
			argDisplayName = "On Complete Params";

			typeOfArg = BaseITweenType.TypeOfArg.onCompleteParams;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Object };
			typeOfDisplay = DisplayType.Object;
		}

	}

}
