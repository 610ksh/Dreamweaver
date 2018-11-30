using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Pitch : BaseITweenArg
	{
		public Args_Pitch ()
		{
			argName = "pitch";
			argDisplayName = "Pitch";

			typeOfArg = BaseITweenType.TypeOfArg.pitch;

			allowedDisplayTypes = new DisplayType[2] { DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
