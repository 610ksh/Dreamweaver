
// This script is used to process numbers inputted through the keypad buttons

using UnityEngine;
using System.Collections;

public class CodeHandler : MonoBehaviour {
	
	// Audio
	
	public GameObject accessGrantedSound;
	public GameObject accessDeniedSound;
	
	private bool soundHasPlayed = false; 
	
	
	
	
	//Game Objects
	
	public GameObject mainKeypad; // We're using the mainKeypad object to access the MainSettings script
	
	public GameObject button01; //To access one of the keypad buttons
	
	
	// Game Objects Display Elements
	
	public GameObject asterisk01;
	public GameObject asterisk02;
	public GameObject asterisk03;
	public GameObject asterisk04;
	public GameObject accessDenied;
	public GameObject accessGranted;
	
	
	// Some variables required
	
	
	private bool codeIsCorrect; //Tells us if the code is correct
	
	public int numberOfInputs = 0; //This keeps track of the number of inputs
	
	public bool buttonsAreEnabled = true; //So we can disable the buttons
	
	
	
	
	
	
	
	
	
	
	
	//Keypad Timer
	
	
	[HideInInspector] public bool finalTimerEnabled = false;
	[HideInInspector] public float finalTimer = 4f; 
	
	
	
	
	
	
	// These variables are used to identify the inputted numbers
	
	[HideInInspector] public int inputtedNumber01;
	[HideInInspector] public int inputtedNumber02;
	[HideInInspector] public int inputtedNumber03;
	[HideInInspector] public int inputtedNumber04;
	
	// These variables grab the correct code numbers from the MainSettings script
	
	[HideInInspector] public int firstNumber;
    [HideInInspector] public int secondNumber;
	[HideInInspector] public int thirdNumber;
	[HideInInspector] public int fourthNumber;
	
	
	
	

	// Use this for initialization
	void Start () {
		
		buttonsAreEnabled = true;
		
		
		//Display elements
		
		
		// We need to disable all these display elements when the game begins
		
		asterisk01.GetComponent<Renderer>().enabled = false;
		asterisk02.GetComponent<Renderer>().enabled = false;
		asterisk03.GetComponent<Renderer>().enabled = false;
		asterisk04.GetComponent<Renderer>().enabled = false;
		accessDenied.GetComponent<Renderer>().enabled = false;
		accessGranted.GetComponent<Renderer>().enabled = false;
		
		
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		// We are using these pieces of code to obtain the correct code numbers from MainSettings
		
		firstNumber = mainKeypad.GetComponent<MainSettings>().firstNumber;
		secondNumber = mainKeypad.GetComponent<MainSettings>().secondNumber;
		thirdNumber = mainKeypad.GetComponent<MainSettings>().thirdNumber;
		fourthNumber = mainKeypad.GetComponent<MainSettings>().fourthNumber;
		
		
		
		
		
		 
		
		//Timer section
		
		
		if (finalTimerEnabled == true) //If the timer is enabled
		{
			finalTimer -= Time.deltaTime;  //Start countdown of timer
			buttonsAreEnabled = false; //Disables buttons
			
			
		} 
		
		if (finalTimer < 3) //Once the timer is below a value of 3
		{
			CheckInputtedCode();  // The code is then checked
			
			numberOfInputs = 0; //Resets the number of inputs
			
			//We need to be able to tell what sound we can play
			
			if (codeIsCorrect == true)   // If the code is correct
			{
				
				if (soundHasPlayed == false) //If the sound has played boolean is equal to false
				{
					accessGrantedSound.GetComponent<AudioSource>().Play(); //The audio source will play
					soundHasPlayed = true;  // soundHasPlayed is equal to true meaning that the sound won't play again 
				}
				
				
				
				
				
			} else // or else if the code isn't correct
			{
				
				if (soundHasPlayed == false)
				{
					accessDeniedSound.GetComponent<AudioSource>().Play(); //The audio source will play
					soundHasPlayed = true; // soundHasPlayed is equal to true meaning that the sound won't play again 
				}
				
			}
			
		}
		
		if (finalTimer < 2) //Once the timer is below 2
		{
			if (codeIsCorrect == true) // and if the code is correct
			{
				mainKeypad.GetComponent<MainSettings>().OnAccessGranted();  //Show access granted message
				
				
			
				
			}
			else
			{
				mainKeypad.GetComponent<MainSettings>().OnAccessDenied();  //Show access denied message
				
				
				
				
				
				
				
			}
			
		}
		
		
		if (finalTimer < 1)  // Once the timer is below zero
		{
			
			finalTimerEnabled = false;  //Stop and reset the timer
			finalTimer = 4f;
			accessGranted.GetComponent<Renderer>().enabled = false; //Disable access denied and granted messages
			accessDenied.GetComponent<Renderer>().enabled = false;
			buttonsAreEnabled = true; //Re-enable the buttons
			
			soundHasPlayed = false; 
			
		}
		
		// Enabling/Disabling asterisks on keypad display
		
		switch (numberOfInputs)
		{
			case 0: 

		asterisk01.GetComponent<Renderer>().enabled = false;
		asterisk02.GetComponent<Renderer>().enabled = false;
		asterisk03.GetComponent<Renderer>().enabled = false;
		asterisk04.GetComponent<Renderer>().enabled = false;


			break;
			case 1: asterisk01.GetComponent<Renderer>().enabled = true;  break;
			case 2: asterisk02.GetComponent<Renderer>().enabled = true;  break;
			case 3: asterisk03.GetComponent<Renderer>().enabled = true;  break;
			case 4: asterisk04.GetComponent<Renderer>().enabled = true; finalTimerEnabled = true;   break;
			
			
			
			
			
		}
		
		
		
		
		
		
		
		
		
		
	
	}
	
	
	// This method checks the code
	
	void CheckInputtedCode ()
	{
		
		// if all the inputted numbers are equal to the correct code numbers
		
		if (firstNumber == inputtedNumber01 && secondNumber == inputtedNumber02 && thirdNumber == inputtedNumber03 && fourthNumber == inputtedNumber04)
		{
			codeIsCorrect = true;  // The code is now correct
			accessGranted.GetComponent<Renderer>().enabled = true;
			
			
		} else  // or else 
		{
			codeIsCorrect = false;   //The code is now incorrect
			
			accessDenied.GetComponent<Renderer>().enabled = true;
		}
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
}
