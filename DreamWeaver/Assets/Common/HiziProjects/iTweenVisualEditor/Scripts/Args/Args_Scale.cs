using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_ScaleVector3 : BaseITweenArg
	{
		public Args_ScaleVector3 ()
		{
			argName = "scale";
			argDisplayName = "Scale";

			typeOfArg = BaseITweenType.TypeOfArg.scaleVector3;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Vector3, DisplayType.Transform };
			typeOfDisplay = DisplayType.Vector3;
		}

	}

}
