using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Target : BaseITweenArg
	{
		public Args_Target ()
		{
			argName = "target";
			argDisplayName = "Target";

			typeOfArg = BaseITweenType.TypeOfArg.target;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.GameObject };
			typeOfDisplay = DisplayType.GameObject;
		}

	}

}
