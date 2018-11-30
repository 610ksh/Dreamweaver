using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using HiziProjects;

[CustomEditor (typeof(iTweenAnimation))]
public class CustomEditor_iTweenAnimation : Editor
{
	//References
	iTweenAnimation script;
	BaseITweenType[] allITweenDatas;

	//Internal Variables
	BaseITweenType.TypeOfAnimation newType = BaseITweenType.TypeOfAnimation.audioFrom;
	int newArgIndex = 0;

	CustomEditor_iTweenAnimation ()
	{
		allITweenDatas = new BaseITweenType[System.Enum.GetNames (typeof(BaseITweenType.TypeOfAnimation)).Length];
	}

	//Init
	public void Init ()
	{
		//Fetch assets
		iTweenAssetFetcher assetFetcher = (iTweenAssetFetcher)Resources.Load ("ITweenAssetFetcher");


		for (int i = 0; i < allITweenDatas.Length; i++)
			allITweenDatas [i] = assetFetcher.allTypes [i];//iTweenAssetFetcher.instance.allTypes [i];
		

		//Debug.Log ("Init complete!");
	}

	public override void OnInspectorGUI ()
	{
		//Setup
		script = (iTweenAnimation)target;

		if (script.itweenDatas == null)
			script.itweenDatas = new List<BaseITweenTypeC> ();

//		//Debug
//		if (GUILayout.Button ("Debug Reload Assets")) {
//			Init ();
//			if (script != null && script.itweenDatas != null)
//				script.itweenDatas.Clear ();
//		}

		//HEADER -- ADD TYPE 
		EditorGUILayout.BeginHorizontal ();

		EditorGUILayout.LabelField ("Create New iTween", GUILayout.Width (120));

		newType = (BaseITweenType.TypeOfAnimation)EditorGUILayout.EnumPopup (newType);

		if (GUILayout.Button ("+", GUILayout.Width (30))) {
			if (allITweenDatas [0] == null)
				Init ();
			
			//Add the new iTween to the list of iTweens
			BaseITweenTypeC newITween = new BaseITweenTypeC (); //ScriptableObject.CreateInstance<BaseITweenType> ();

			newITween.iTweenName = allITweenDatas [(int)newType].iTweenName;
			newITween.iTweenType = allITweenDatas [(int)newType].iTweenType;
			newITween.allParams = allITweenDatas [(int)newType].allParams;
			newITween.basicParams = allITweenDatas [(int)newType].basicParams;
			newITween.isComplex = allITweenDatas [(int)newType].isComplex;

			script.itweenDatas.Add (newITween);

			//Add the basic args to the script
			for (int i = 0; i < script.itweenDatas [script.itweenDatas.Count - 1].basicParams.Length; i++)
				script.itweenDatas [script.itweenDatas.Count - 1].allArgs.Add (GetArg (script.itweenDatas [script.itweenDatas.Count - 1].basicParams [i]));
		}

		EditorGUILayout.EndHorizontal ();

		//If there's no tweens, don't bother trying to display them. Like, really. Our lord and savior iTween wouldn't want that.
		if (script.itweenDatas.Count < 1) {
			return;
		}
		
		//ITWEEN DISPLAY
		for (int i = 0; i < script.itweenDatas.Count; i++) {
			//Entry header
			EditorGUILayout.BeginHorizontal ();

			//Display name in bold and big
			GUIStyle headerStyle = new GUIStyle ();
			headerStyle.fontSize = 20;
			headerStyle.alignment = TextAnchor.MiddleLeft;
			EditorGUILayout.LabelField (script.itweenDatas [i].iTweenName, headerStyle);

			//Display full control
			GUILayout.FlexibleSpace ();
			EditorGUIUtility.labelWidth = 80;
			script.itweenDatas [i].isComplex = EditorGUILayout.Toggle ("Full Control", script.itweenDatas [i].isComplex);

			//Remove button
			if (GUILayout.Button (" X ")) {
				script.itweenDatas.RemoveAt (i);
				return;
			}

			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.Separator ();

			//Display all the arguments !
			if (!script.itweenDatas [i].isComplex) {
				if (script.itweenDatas [i].allArgs.Count < 1)
					continue;

				//Warn the user if it's forgetting about putting a target..
				if (script.itweenDatas [i].allArgs [0].typeOfArg == BaseITweenType.TypeOfArg.target && script.itweenDatas [i].allArgs [0].gameObjectValue == null) {
					EditorGUILayout.HelpBox ("A GameObject target is required.", MessageType.Warning);
				}

				for (int k = 0; k < script.itweenDatas [i].basicParams.Length; k++) {
					EditorGUILayout.BeginHorizontal ();
			
					//Display field name
					EditorGUILayout.LabelField (script.itweenDatas [i].allArgs [k].argDisplayName, GUILayout.Width (80));


					
					//Display the actual field
					DisplayField (script.itweenDatas [i].allArgs [k]);

					if (k == 0 && script.itweenDatas [i].allArgs [0].typeOfArg == BaseITweenType.TypeOfArg.target) {
						if (GUILayout.Button ("This GO")) {
							script.itweenDatas [i].allArgs [0].gameObjectValue = script.gameObject;
						}
					}

					EditorGUILayout.EndHorizontal ();
				}

				//If it's a camera fade tween, display additional options
				if (script.itweenDatas [i].iTweenType == BaseITweenType.TypeOfAnimation.cameraFadeFrom || script.itweenDatas [i].iTweenType == BaseITweenType.TypeOfAnimation.cameraFadeTo)
					DisplayCameraFadeOptions ();
				
			} else {
				//Display complex options
				for (int k = 0; k < script.itweenDatas [i].allArgs.Count; k++) {

					//Warn the user if it's forgetting about putting a target..
					if (script.itweenDatas [i].allArgs.Count > 0 && script.itweenDatas [i].allArgs [0].typeOfArg == BaseITweenType.TypeOfArg.target && script.itweenDatas [i].allArgs [0].gameObjectValue == null) {
						EditorGUILayout.HelpBox ("A GameObject target is required.", MessageType.Warning);
					}

					EditorGUILayout.BeginHorizontal ();

					//Display field name
					EditorGUILayout.LabelField (script.itweenDatas [i].allArgs [k].argDisplayName, GUILayout.Width (80));

					//Display the field choice
					string[] selectableChoices = new string[script.itweenDatas [i].allArgs [k].allowedDisplayTypes.Length];

					int currentIndex = 0;

					for (int l = 0; l < script.itweenDatas [i].allArgs [k].allowedDisplayTypes.Length; l++) {
						selectableChoices [l] = script.itweenDatas [i].allArgs [k].allowedDisplayTypes [l].ToString ();
						if (selectableChoices [l] == script.itweenDatas [i].allArgs [k].typeOfDisplay.ToString ())
							currentIndex = l;
					}

					currentIndex = EditorGUILayout.Popup (currentIndex, selectableChoices, GUILayout.Width (90));

					script.itweenDatas [i].allArgs [k].typeOfDisplay = (DisplayType)Enum.Parse (typeof(DisplayType), selectableChoices [currentIndex]);

					//If the current object has a complex item (ie path), use serializable objects
					if (script.itweenDatas [i].allArgs [k].typeOfArg == BaseITweenType.TypeOfArg.path) {
						//Find the correct argument item
						SerializedProperty tmpSP = serializedObject.FindProperty ("itweenDatas").GetArrayElementAtIndex (i).FindPropertyRelative ("allArgs").GetArrayElementAtIndex (k);

						GUILayout.Space (10);

						//Display the array field
						DisplayField (script.itweenDatas [i].allArgs [k], tmpSP);

						//Update the values
						serializedObject.ApplyModifiedProperties ();
					} else {						
						//Display the actual field
						DisplayField (script.itweenDatas [i].allArgs [k]);
					}

					//The first option (TARGET) cannot be removed. Display it normally.
					if (k != 0) {
						if (GUILayout.Button (" X ", GUILayout.Width (20))) {
							//Remove current item and leave method!
							script.itweenDatas [i].allArgs.RemoveAt (k);
							EditorGUILayout.EndHorizontal ();
							return;
						}
					} else if (k == 0 && script.itweenDatas [i].allArgs [0].typeOfArg == BaseITweenType.TypeOfArg.target) {
						if (GUILayout.Button ("This GO")) {
							script.itweenDatas [i].allArgs [0].gameObjectValue = script.gameObject;
						}
					}

					EditorGUILayout.EndHorizontal ();
				}

				//If it's a camera fade tween, display additional options
				if (script.itweenDatas [i].iTweenType == BaseITweenType.TypeOfAnimation.cameraFadeFrom || script.itweenDatas [i].iTweenType == BaseITweenType.TypeOfAnimation.cameraFadeTo)
					DisplayCameraFadeOptions ();
				
				//Add new item button
				GUILayout.Space (10);

				EditorGUILayout.BeginHorizontal ();

				//Display the field choice to add a new parameter
				if (script.itweenDatas [i].allArgs.Count < script.itweenDatas [i].allParams.Length) {
					
					List<string> selectableNewArgList = new List<string> ();

					for (int k = 0; k < script.itweenDatas [i].allParams.Length; k++) {
						bool check = true;
						try {
							script.itweenDatas [i].allArgs.Find (l => l.typeOfArg.ToString () == script.itweenDatas [i].allParams [k].ToString ()).ToString ();
						} catch {
							check = false;
						}
						if (!check)
							selectableNewArgList.Add (script.itweenDatas [i].allParams [k].ToString ());
					}

					newArgIndex = EditorGUILayout.Popup (newArgIndex, selectableNewArgList.ToArray ());

					//DO PRESS THE BUTTON !
					if (GUILayout.Button ("Add New Parameter")) {
						//Add new argument
						script.itweenDatas [i].allArgs.Add (GetArg ((BaseITweenType.TypeOfArg)Enum.Parse (typeof(BaseITweenType.TypeOfArg), selectableNewArgList [newArgIndex])));
						//Reset arg index
						newArgIndex = 0;
					}
				}

				EditorGUILayout.EndHorizontal ();
			}

			//FASHIOOOOONNN
			EditorGUILayout.LabelField ("", GUI.skin.horizontalSlider);
		}

		//Start Flags
		EditorGUILayout.BeginHorizontal ();
		script.playOnEnable = EditorGUILayout.ToggleLeft ("Play During OnEnable?", script.playOnEnable, GUILayout.Width (150));
		script.playOnStart = EditorGUILayout.ToggleLeft ("Play During Start?", script.playOnStart, GUILayout.Width (120));
		EditorGUILayout.EndHorizontal ();
		script.stopTweensOnDisable = EditorGUILayout.ToggleLeft ("Delete Tweens when GameObject is disabled?", script.stopTweensOnDisable);


		//It's not as bad as it sounds..
		EditorUtility.SetDirty (script);
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

		Type argType = Type.GetType (argName);

		return (BaseITweenArg)Activator.CreateInstance (argType);
	}

	/// <summary>
	/// Displays a field according to what the argument display type and value type.
	/// </summary>
	/// <param name="newType">New type.</param>
	/// <param name="currentArg">Current argument.</param>
	void DisplayField (BaseITweenArg currentArg, SerializedProperty arrayProperty = null)
	{
		DisplayType newType = currentArg.typeOfDisplay;


		switch (newType) {
		case DisplayType.Int:
			currentArg.intValue = EditorGUILayout.IntField (currentArg.intValue);
			break;
		case DisplayType.Float:
			currentArg.floatValue = EditorGUILayout.FloatField (currentArg.floatValue);
			break;
		case DisplayType.Double:
			currentArg.doubleValue = EditorGUILayout.DoubleField (currentArg.doubleValue);
			break;
		case DisplayType.String:
			currentArg.stringValue = EditorGUILayout.TextField (currentArg.stringValue);
			break;
		case DisplayType.Bool:
			currentArg.boolValue = EditorGUILayout.Toggle (currentArg.boolValue);
			break;
		case DisplayType.Color:
			currentArg.colorValue = EditorGUILayout.ColorField (currentArg.colorValue);
			break;
		case DisplayType.GameObject:
			currentArg.gameObjectValue = (GameObject)EditorGUILayout.ObjectField (currentArg.gameObjectValue, typeof(GameObject), true);
			break;
		case DisplayType.Object:
			currentArg.objectValue = (UnityEngine.Object)EditorGUILayout.ObjectField (currentArg.objectValue, typeof(UnityEngine.Object), false);
			break;
		case DisplayType.AudioSource:
			currentArg.audioSourceValue = (AudioSource)EditorGUILayout.ObjectField (currentArg.audioSourceValue, typeof(AudioSource), true);
			break;
		case DisplayType.AudioClip:
			currentArg.audioClipValue = (AudioClip)EditorGUILayout.ObjectField (currentArg.audioClipValue, typeof(AudioClip), false);
			break;
		case DisplayType.Vector3:
			currentArg.vector3Value = EditorGUILayout.Vector3Field ("", currentArg.vector3Value);
			break;
		case DisplayType.Vector3Array:
			EditorGUILayout.PropertyField (arrayProperty.FindPropertyRelative ("vector3ArrayValue"), true);
			break;
		case DisplayType.Vector2:
			currentArg.vector2Value = EditorGUILayout.Vector2Field ("", currentArg.vector2Value);
			break;
		case DisplayType.Transform:
			currentArg.transformValue = (Transform)EditorGUILayout.ObjectField (currentArg.transformValue, typeof(Transform), true);
			break;
		case DisplayType.TransformArray:
			EditorGUILayout.PropertyField (arrayProperty.FindPropertyRelative ("transformArrayValue"), true);
			break;
		case DisplayType.Rect:
			currentArg.rectValue = EditorGUILayout.RectField (currentArg.rectValue);
			break;
		case DisplayType.EaseType:
			currentArg.easeTypeValue = (iTween.EaseType)EditorGUILayout.EnumPopup (currentArg.easeTypeValue);
			break;
		case DisplayType.LoopType:
			currentArg.loopTypeValue = (iTween.LoopType)EditorGUILayout.EnumPopup (currentArg.loopTypeValue);
			break;
		case DisplayType.NameColorValue:
			currentArg.namedValueColorValue = (iTween.NamedValueColor)EditorGUILayout.EnumPopup (currentArg.namedValueColorValue);
			break;
		case DisplayType.Space:
			currentArg.spaceValue = (Space)EditorGUILayout.EnumPopup (currentArg.spaceValue);
			break;
		}
	}

	/// <summary>
	/// Displays the camera fade options.
	/// </summary>
	void DisplayCameraFadeOptions ()
	{
		EditorGUILayout.Separator ();

		//Set depth button
		EditorGUILayout.BeginHorizontal ();

		EditorGUIUtility.labelWidth = 120;

		script.cameraFadeDepth = EditorGUILayout.IntField ("Camera Fade Depth", script.cameraFadeDepth);

		script.cameraFadeTex = (Texture2D)EditorGUILayout.ObjectField ("Camera Fade Depth", script.cameraFadeTex, typeof(Texture2D), false);
	

		EditorGUILayout.EndHorizontal ();	

		if (GUILayout.Button ("Reset Camera Fade Settings")) {
			script.cameraFadeTex = null;
			script.cameraFadeDepth = 99999;
		}
	}
}
