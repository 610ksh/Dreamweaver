using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Volume : BaseITweenArg
	{
		public Args_Volume ()
		{
			argName = "volume";
			argDisplayName = "Volume";

			typeOfArg = BaseITweenType.TypeOfArg.volume;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
