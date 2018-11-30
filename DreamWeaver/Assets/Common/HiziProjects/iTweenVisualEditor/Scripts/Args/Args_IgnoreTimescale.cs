using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_IgnoreTimescale : BaseITweenArg
	{
		public Args_IgnoreTimescale ()
		{
			argName = "ignoretimescale";
			argDisplayName = "Ignore Timescale";

			typeOfArg = BaseITweenType.TypeOfArg.ignoreTimescale;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Bool };
			typeOfDisplay = DisplayType.Bool;
		}

	}

}
