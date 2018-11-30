using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_OrientToPath : BaseITweenArg
	{
		public Args_OrientToPath ()
		{
			argName = "orienttopath";
			argDisplayName = "Orient To Path";

			typeOfArg = BaseITweenType.TypeOfArg.orientToPath;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Bool };
			typeOfDisplay = DisplayType.Bool;
		}

	}

}
