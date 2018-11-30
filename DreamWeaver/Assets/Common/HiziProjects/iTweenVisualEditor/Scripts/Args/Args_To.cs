using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_To : BaseITweenArg
	{
		public Args_To ()
		{
			argName = "to";
			argDisplayName = "To";

			typeOfArg = BaseITweenType.TypeOfArg.to;

			allowedDisplayTypes = new DisplayType[6] {
				DisplayType.Float,
				DisplayType.Double,
				DisplayType.Vector3,
				DisplayType.Vector2,
				DisplayType.Color,
				DisplayType.Rect
			};
			typeOfDisplay = DisplayType.Float;
		}

	}

}
