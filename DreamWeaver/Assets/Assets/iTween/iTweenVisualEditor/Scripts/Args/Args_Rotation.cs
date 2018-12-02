using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_RotationVector3 : BaseITweenArg
	{
		public Args_RotationVector3 ()
		{
			argName = "rotation";
			argDisplayName = "Rotation";

			typeOfArg = BaseITweenType.TypeOfArg.rotationVector3;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Vector3, DisplayType.Transform };
			typeOfDisplay = DisplayType.Vector3;
		}

	}

}
