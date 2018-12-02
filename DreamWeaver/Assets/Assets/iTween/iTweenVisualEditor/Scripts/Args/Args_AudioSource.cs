using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_AudioSource : BaseITweenArg
	{
		public Args_AudioSource ()
		{
			argName = "audiosource";
			argDisplayName = "Audio Source";

			typeOfArg = BaseITweenType.TypeOfArg.audioSource;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.AudioSource };
			typeOfDisplay = DisplayType.AudioSource;
		}

	}

}
