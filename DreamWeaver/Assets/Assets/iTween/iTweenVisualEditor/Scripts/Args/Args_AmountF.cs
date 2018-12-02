using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_AmountF : BaseITweenArg
	{
		public Args_AmountF ()
		{
			argName = "amount";
			argDisplayName = "Amount";

			typeOfArg = BaseITweenType.TypeOfArg.amountF;

			allowedDisplayTypes = new DisplayType[2]{ DisplayType.Float, DisplayType.Double };
			typeOfDisplay = DisplayType.Float;
		}

	}

}
