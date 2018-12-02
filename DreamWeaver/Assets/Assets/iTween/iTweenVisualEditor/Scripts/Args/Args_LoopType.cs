using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_LoopType : BaseITweenArg
	{
		public Args_LoopType ()
		{
			argName = "looptype";
			argDisplayName = "Loop Type";

			typeOfArg = BaseITweenType.TypeOfArg.loopType;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.LoopType, DisplayType.String };
			typeOfDisplay = DisplayType.LoopType;
		}

	}

}
