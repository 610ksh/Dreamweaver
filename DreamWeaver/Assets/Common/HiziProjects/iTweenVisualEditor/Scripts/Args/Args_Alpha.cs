using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_Alpha : BaseITweenArg
	{
		public Args_Alpha ()
		{
			argName ="alpha";
			argDisplayName ="Alpha";

			typeOfArg = BaseITweenType.TypeOfArg.alpha;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Float };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
