using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Position : BaseITweenArg
	{
		public Args_Position ()
		{
			argName = "position";
			argDisplayName = "Position";

			typeOfArg = BaseITweenType.TypeOfArg.position;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Vector3, DisplayType.Transform };
			typeOfDisplay = DisplayType.Vector3;
		}

	}

}
