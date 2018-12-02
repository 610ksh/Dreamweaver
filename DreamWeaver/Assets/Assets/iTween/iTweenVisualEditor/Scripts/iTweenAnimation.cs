using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HiziProjects;

public class iTweenAnimation : MonoBehaviour
{
	//Storage for all the ITWEENS.
	public List<BaseITweenTypeC> itweenDatas;

	//Defines if the tween will play on enable
	public bool playOnEnable = false;

	//Defines if the tween will play on start
	public bool playOnStart = false;

	//Defines if the tween will delete all ongoing tweens on Disable
	public bool stopTweensOnDisable = false;

	//Camera fade storage
	public Texture2D cameraFadeTex;
	public int cameraFadeDepth;

	iTweenAnimation ()
	{
		if (itweenDatas == null)
			itweenDatas = new List<BaseITweenTypeC> ();
	}

	void OnEnable ()
	{
		if (playOnEnable)
			iTweenStart ();
	}

	void Start ()
	{
		if (playOnStart)
			iTweenStart ();
	}

	/// <summary>
	/// Launches all the recorded itweens on this script.
	/// </summary>
	public void iTweenStart ()
	{
		//Nullcheck
		if (itweenDatas.Count == 0)
			return;

		//Go through all the scripts, make the Hashtables, and launch the based ITWEEN !
		for (int i = 0; i < itweenDatas.Count; i++) {
			Hashtable itweenHash = new Hashtable ();

			for (int k = 0; k < itweenDatas [i].allArgs.Count; k++) {
				AddToHashTable (itweenHash, itweenDatas [i].allArgs [k]);
			}


			GameObject target = null;

			//If the current ITWEEN requires a target, store it in a game object and remove it from the hash.
			if (itweenDatas [i].iTweenType != BaseITweenType.TypeOfAnimation.cameraFadeFrom && itweenDatas [i].iTweenType != BaseITweenType.TypeOfAnimation.cameraFadeTo) {
				target = itweenDatas [i].allArgs [0].gameObjectValue;
				itweenHash.Remove (itweenDatas [0].allArgs [0].argName);
			}

			//Play the correct tween!
			#region Plays the corret ITWEEN. Gigantic Switch.

			switch (itweenDatas [i].iTweenType) {
			case BaseITweenType.TypeOfAnimation.audioFrom:
				iTween.AudioFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.audioTo:
				iTween.AudioTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.audioUpdate:
				iTween.AudioUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.cameraFadeFrom:
//				if (cameraFadeTex == null)
//					iTween.CameraFadeAdd ();
//				else
//					iTween.CameraFadeAdd (cameraFadeTex, cameraFadeDepth);
//
//				Debug.Log (itweenHash.Count);
//				iTween.CameraFadeFrom (itweenHash);
				Debug.LogError ("iTween has stopped supporting this feature. If you are using an older version if iTween, uncomment this section.");
				break;
			case BaseITweenType.TypeOfAnimation.cameraFadeTo:
//				if (cameraFadeTex == null)
//					iTween.CameraFadeAdd ();
//				else
//					iTween.CameraFadeAdd (cameraFadeTex, cameraFadeDepth);
//				
//				iTween.CameraFadeTo (itweenHash);
				Debug.LogError ("iTween has stopped supporting this feature. If you are using an older version if iTween, uncomment this section.");
				break;
			case BaseITweenType.TypeOfAnimation.colorFrom:
				iTween.ColorFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.colorTo:
				iTween.ColorTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.colorUpdate:
				iTween.ColorUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.fadeFrom:
				iTween.FadeFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.fadeTo:
				iTween.FadeTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.fadeUpdate:
				iTween.FadeUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.lookFrom:
				iTween.LookFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.lookTo:
				iTween.LookTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.lookUpdate:
				iTween.LookUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.moveAdd:
				iTween.MoveAdd (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.moveBy:
				iTween.MoveBy (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.moveFrom:
				iTween.MoveFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.moveTo:
				iTween.MoveTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.moveUpdate:
				iTween.MoveUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.punchPosition:
				iTween.PunchPosition (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.punchRotation:
				iTween.PunchRotation (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.punchScale:
				iTween.PunchScale (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.rotateAdd:
				iTween.RotateAdd (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.rotateBy:
				iTween.RotateBy (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.rotateFrom:
				iTween.RotateFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.rotateTo:
				iTween.RotateTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.rotateUpdate:
				iTween.RotateUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.scaleAdd:
				iTween.ScaleAdd (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.scaleBy:
				iTween.ScaleBy (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.scaleFrom:
				iTween.ScaleFrom (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.scaleTo:
				iTween.ScaleTo (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.scaleUpdate:
				iTween.ScaleUpdate (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.shakePosition:
				iTween.ShakePosition (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.shakeRotation:
				iTween.ShakeRotation (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.shakeScale:
				iTween.ShakeScale (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.stab:
				iTween.Stab (target, itweenHash);
				break;
			case BaseITweenType.TypeOfAnimation.valueTo:
				iTween.ValueTo (target, itweenHash);
				break;
			}

			#endregion
		}
	}

	#region Add To Hashtable Gigantic Switch

	void AddToHashTable (Hashtable currentTable, BaseITweenArg newArg)
	{
		switch (newArg.typeOfDisplay) {
		case DisplayType.Int:
			currentTable.Add (newArg.argName, newArg.intValue);
			break;
		case DisplayType.Float:
			currentTable.Add (newArg.argName, newArg.floatValue);
			break;					 
		case DisplayType.Double:	   
			currentTable.Add (newArg.argName, newArg.doubleValue);
			break;					 
		case DisplayType.String:	   
			currentTable.Add (newArg.argName, newArg.stringValue);
			break;					 
		case DisplayType.Bool:		 
			currentTable.Add (newArg.argName, newArg.boolValue);
			break;					 
		case DisplayType.Color:		
			currentTable.Add (newArg.argName, newArg.colorValue);
			break;					 
		case DisplayType.GameObject: 
			currentTable.Add (newArg.argName, newArg.gameObjectValue);
			break;					 
		case DisplayType.Object:	   
			currentTable.Add (newArg.argName, newArg.objectValue);
			break;					 
		case DisplayType.AudioSource:	  
			currentTable.Add (newArg.argName, newArg.audioSourceValue);
			break;					 
		case DisplayType.AudioClip:
			currentTable.Add (newArg.argName, newArg.audioClipValue);
			break;					 
		case DisplayType.Vector3:	  
			currentTable.Add (newArg.argName, newArg.vector3Value);
			break;					 
		case DisplayType.Vector3Array:	 
			currentTable.Add (newArg.argName, newArg.vector3ArrayValue);
			break;					 
		case DisplayType.Vector2:	  
			currentTable.Add (newArg.argName, newArg.vector2Value);
			break;					 
		case DisplayType.Transform:	
			currentTable.Add (newArg.argName, newArg.transformValue);
			break;					 
		case DisplayType.TransformArray:	   
			currentTable.Add (newArg.argName, newArg.transformArrayValue);
			break;					 
		case DisplayType.Rect:		 
			currentTable.Add (newArg.argName, newArg.rectValue);
			break;					 
		case DisplayType.EaseType:	 
			currentTable.Add (newArg.argName, newArg.easeTypeValue);
			break;					 
		case DisplayType.LoopType:	 
			currentTable.Add (newArg.argName, newArg.loopTypeValue);
			break;					 
		case DisplayType.NameColorValue:	   
			currentTable.Add (newArg.argName, newArg.namedValueColorValue);
			break;					 
		case DisplayType.Space:		
			currentTable.Add (newArg.argName, newArg.spaceValue);
			break;
		}
	}

	#endregion

	void OnDisable ()
	{
		if (stopTweensOnDisable)
			iTween.Stop (this.gameObject);
	}
}
