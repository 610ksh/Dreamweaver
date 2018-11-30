using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Name : BaseITweenArg
	{
		public Args_Name ()
		{
			argName = "name";
			argDisplayName = "Name";

			typeOfArg = BaseITweenType.TypeOfArg.name;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.String };
			typeOfDisplay = DisplayType.String;
		}

	}

}
