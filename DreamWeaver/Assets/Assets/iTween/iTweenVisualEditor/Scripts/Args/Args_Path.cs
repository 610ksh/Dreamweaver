using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Path : BaseITweenArg
	{
		public Args_Path ()
		{
			argName = "path";
			argDisplayName = "Path";

			typeOfArg = BaseITweenType.TypeOfArg.path;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Vector3Array, DisplayType.TransformArray };
			typeOfDisplay = DisplayType.Vector3Array;
		}

	}

}
