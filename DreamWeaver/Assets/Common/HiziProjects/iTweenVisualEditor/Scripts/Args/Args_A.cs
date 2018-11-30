using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_A : BaseITweenArg
	{
		public Args_A ()
		{
			argName = "a";
			argDisplayName = "A";

			typeOfArg = BaseITweenType.TypeOfArg.a;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
