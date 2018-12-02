using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Z : BaseITweenArg
	{
		public Args_Z ()
		{
			argName = "z";
			argDisplayName = "Z";

			typeOfArg = BaseITweenType.TypeOfArg.z;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
