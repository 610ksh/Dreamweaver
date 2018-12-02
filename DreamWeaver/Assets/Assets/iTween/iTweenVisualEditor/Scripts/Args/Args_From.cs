using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_From : BaseITweenArg
	{
		public Args_From ()
		{
			argName = "from";
			argDisplayName = "From";

			typeOfArg = BaseITweenType.TypeOfArg.from;

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
