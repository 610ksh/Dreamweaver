using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OnUpdateParams : BaseITweenArg
	{
		public Args_OnUpdateParams ()
		{
			argName = "onupdateparams";
			argDisplayName = "On Update Params";

			typeOfArg = BaseITweenType.TypeOfArg.onUpdateParams;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Object };
			typeOfDisplay = DisplayType.Object;
		}

	}

}
