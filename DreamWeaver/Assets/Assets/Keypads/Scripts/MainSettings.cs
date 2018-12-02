
// Contains all the main settings for the keypad

using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class MainSettings : MonoBehaviour {
	

	[Header("Main Options")]
	
	public bool keypadIsEnabled = true;   //Checks whether or not the keypad is enabled
	public bool keypadButtonsAnimate = true; //Checks whether or not the keypad buttons can animate

	[Header("Correct Code (In Order)")]	  //These variables are where the user input their correct code
	
	[Range (0,9)]public int firstNumber = 0;
	[Range (0,9)]public int secondNumber = 0;
	[Range (0,9)]public int thirdNumber = 0;
	[Range (0,9)]public int fourthNumber = 0;
	
	[Header("Crosshair")]
	
	public Texture2D crosshairImage;       //The crosshair image
	public bool enableCrosshair = true;  //This allows the user to specify whether or not they want a crosshair
	
	
	[Header("Input")]
	
	public KeyCode useKey = KeyCode.E;  //This is the usekey that the user will use to interact with buttons
	
	[Header("Required Gameobjects")]
	
	public GameObject FPSController;  //This is used to access the FPS controller
	
	
	
	
	
	
	[Header("Output")]
	

	public UnityEvent onAccessGranted;
	
	public UnityEvent onAccessDenied;
	
	
	public void OnAccessGranted()   //Access Granted trigger event
	{
     
     onAccessGranted.Invoke();
	 
	}
	
	public void OnAccessDenied()  //Access Denied trigger event
	{
     
     onAccessDenied.Invoke();
	 
	}
	
	
	
	
	

	
	
	
	// Use this for initialization
	void Start () {
		
		
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (FPSController == null)  //If there is no object in the FPS controller slot 
		{
			// Display Error
			
			Debug.LogError("The FPS Controller is missing from the FPS Controller slot in the keypad inspector");
			
		}
		
		
		
		
		
	
	}
}
