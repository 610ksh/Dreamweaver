using UnityEngine;
using System.Collections;

namespace HiziProjects
{
	[System.Serializable]
	public class Args_AudioClip : BaseITweenArg
	{
		public Args_AudioClip ()
		{
			argName = "audioclip";
			argDisplayName = "Audio Clip";

			typeOfArg = BaseITweenType.TypeOfArg.audioClip;

			allowedDisplayTypes = new DisplayType[1]{ DisplayType.AudioClip };
			typeOfDisplay = DisplayType.AudioClip;
		}

	}

}
