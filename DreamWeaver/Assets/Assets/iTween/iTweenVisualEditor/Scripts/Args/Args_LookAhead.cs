using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_LookAhead : BaseITweenArg
	{
		public Args_LookAhead ()
		{
			argName = "lookahead";
			argDisplayName = "Look Ahead";

			typeOfArg = BaseITweenType.TypeOfArg.lookAhead;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
