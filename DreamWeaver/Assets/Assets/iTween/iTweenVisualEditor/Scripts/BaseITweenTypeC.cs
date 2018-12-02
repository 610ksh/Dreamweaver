using UnityEngine;
using System.Collections.Generic;
using HiziProjects;

[System.Serializable]
public class BaseITweenTypeC
{
	//Name of the iTween animation
	public string iTweenName;

	public BaseITweenType.TypeOfAnimation iTweenType;

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
					if (basicParams [0] == BaseITweenType.TypeOfArg.target)
						allArgs.Add (GetArg (allParams [0]));
				}
			}
		}
	}

	//Arg storage
	public List<BaseITweenArg> allArgs;

	//Basic Parameters
	public BaseITweenType.TypeOfArg[] basicParams;

	//All Parameters
	public BaseITweenType.TypeOfArg[] allParams;

	public BaseITweenTypeC ()
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