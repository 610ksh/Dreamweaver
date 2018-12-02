using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_G : BaseITweenArg
	{
		public Args_G ()
		{
			argName = "g";
			argDisplayName = "G";

			typeOfArg = BaseITweenType.TypeOfArg.g;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
