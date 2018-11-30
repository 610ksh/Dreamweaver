using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_AmountVector3 : BaseITweenArg
	{
		public Args_AmountVector3 ()
		{
			argName = "amount";
			argDisplayName = "Amount";

			typeOfArg = BaseITweenType.TypeOfArg.amountVector3;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.Vector3 };
			typeOfDisplay = DisplayType.Vector3;
		}

	}

}
