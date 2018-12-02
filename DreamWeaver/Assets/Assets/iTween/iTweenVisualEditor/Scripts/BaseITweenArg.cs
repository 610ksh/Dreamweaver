using UnityEngine;
using System.Collections;
using HiziProjects;

namespace HiziProjects
{
	public enum DisplayType
	{
		//System
		Int,
		Float,
		Double,
		String,
		Bool,
		Color,

		//Object
		GameObject,
		Object,

		//Unity Stuff
		AudioSource,
		AudioClip,
		Vector3,
		Vector3Array,
		Vector2,
		Transform,
		TransformArray,
		Rect,

		//iTween Stuff
		EaseType,
		LoopType,
		NameColorValue,
		Space,
	}

	[System.Serializable]
	public class BaseITweenArg
	{
		//Naming
		public string argName;
		public string argDisplayName;

		public BaseITweenType.TypeOfArg typeOfArg;

		//Type Of Variables
		public DisplayType[] allowedDisplayTypes;
		public DisplayType typeOfDisplay;

		//Values
		public int intValue;
		public float floatValue;
		public double doubleValue;
		public string stringValue;
		public bool boolValue;
		public Color colorValue;
		public GameObject gameObjectValue;
		public Object objectValue;
		public AudioSource audioSourceValue;
		public AudioClip audioClipValue;
		public Vector3 vector3Value;
		public Vector3[] vector3ArrayValue;
		public Vector2 vector2Value;
		public Transform transformValue;
		public Transform[] transformArrayValue;
		public Rect rectValue;
		public iTween.EaseType easeTypeValue;
		public iTween.LoopType loopTypeValue;
		public iTween.NamedValueColor namedValueColorValue;
		public Space spaceValue;
	}
}