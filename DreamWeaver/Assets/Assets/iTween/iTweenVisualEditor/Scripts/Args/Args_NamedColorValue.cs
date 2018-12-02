using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_NamedColorValue : BaseITweenArg
	{
		public Args_NamedColorValue ()
		{
			argName = "namedcolorvalue";
			argDisplayName = "Named Color Value";

			typeOfArg = BaseITweenType.TypeOfArg.namedColorValue;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.NameColorValue, DisplayType.String };
			typeOfDisplay = DisplayType.NameColorValue;
		}

	}

}
