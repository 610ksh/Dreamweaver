using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HiziProjects;

//[CreateAssetMenu (menuName = "New iTween Type")]
[System.Serializable]
public class BaseITweenType : ScriptableObject
{
	#region Enums

	/// <summary>
	/// Enumeration of all the types of animation offered by our lord and savior iTween.
	/// </summary>
	public enum TypeOfAnimation
	{
		audioFrom,
		audioTo,
		audioUpdate,
		cameraFadeFrom,
		cameraFadeTo,
		colorFrom,
		colorTo,
		colorUpdate,
		fadeFrom,
		fadeTo,
		fadeUpdate,
		lookFrom,
		lookTo,
		lookUpdate,
		moveAdd,
		moveBy,
		moveFrom,
		moveTo,
		moveUpdate,
		punchPosition,
		punchRotation,
		punchScale,
		rotateAdd,
		rotateBy,
		rotateFrom,
		rotateTo,
		rotateUpdate,
		scaleAdd,
		scaleBy,
		scaleFrom,
		scaleTo,
		scaleUpdate,
		shakePosition,
		shakeRotation,
		shakeScale,
		stab,
		valueTo
	}

	//Enumeration of all the types of parameters
	public enum TypeOfArg
	{
		//Value
		target,
		name,
		amountF,
		speed,
		fromF,
		from,
		fromVector2,
		fromColor,
		fromRect,
		toF,
		to,
		toVector2,
		toColor,
		toRect,

		//Position / Direction / Rotation / Scale
		amountVector3,
		rotationVector3,
		rotationTransform,
		scaleVector3,
		scaleTransform,
		lookTarget,
		axis,
		position,
		path,
		x,
		y,
		z,
		lookTime,
		lookAhead,
		space,

		//Color
		color,
		r,
		g,
		b,
		a,
		alpha,
		namedColorValue,

		//Time
		time,
		delay,

		//Audio
		audioSource,
		audioClip,
		volume,
		pitch,

		//Loop
		easeType,
		loopType,

		//Event
		onStart,
		onStartTarget,
		onStartParams,
		onUpdate,
		onUpdateTarget,
		onUpdateParams,
		onComplete,
		onCompleteTarget,
		onCompleteParams,

		//flags
		ignoreTimescale,
		includeChildren,
		orientToPath,
		moveToPath,
		isLocal,
	}

	#endregion

	//Name of the iTween animation
	public string iTweenName;

	public TypeOfAnimation iTweenType;

	[SerializeField]bool _isComplex = false;

	public bool isComplex {
		get { 
			return _isComplex; 
		}
		set { 
			if (_isComplex != value) {
				_isComplex = value; 
				allArgs.Clear ();

				if (!_isComplex) {
					for (int i = 0; i < basicParams.Length; i++)
						allArgs.Add (GetArg (basicParams [i]));
				} else {
					if (basicParams [0] == TypeOfArg.target)
						allArgs.Add (GetArg (allParams [0]));
				}
			}
		}
	}

	//Arg storage
	public List<BaseITweenArg> allArgs;

	//Basic Parameters
	public TypeOfArg[] basicParams;

	//All Parameters
	public TypeOfArg[] allParams;

	public BaseITweenType ()
	{
		if (allArgs == null)
			allArgs = new List<BaseITweenArg> ();
	}

	/// <summary>
	/// Gets a new argument according to a given enum value
	/// </summary>
	/// <returns>The argument.</returns>
	/// <param name="newType">New type.</param>
	public BaseITweenArg GetArg (BaseITweenType.TypeOfArg newType)
	{
		string newTypeToString = newType.ToString ();
		string argName = "HiziProjects.Args_";

		for (int i = 0; i < newTypeToString.Length; i++) {
			string tmp = newTypeToString [i].ToString ();
			if (i == 0)
				tmp = tmp.ToUpper ();

			argName += tmp;
		}

		argName += ", Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";

		System.Type argType = System.Type.GetType (argName.ToString ());
		return (BaseITweenArg)System.Activator.CreateInstance (argType);
	}
}
