using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_LookTarget : BaseITweenArg
	{
		public Args_LookTarget ()
		{
			argName = "looktarget";
			argDisplayName = "Look Target";

			typeOfArg = BaseITweenType.TypeOfArg.lookTarget;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Vector3, DisplayType.Transform };
			typeOfDisplay = DisplayType.Vector3;
		}

	}

}
