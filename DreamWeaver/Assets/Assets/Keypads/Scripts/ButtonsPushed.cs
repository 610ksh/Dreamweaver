
// This script is attached to all keypad buttons and handles how they act when they are pushed

using UnityEngine;
using System.Collections;

public class ButtonsPushed : MonoBehaviour {
	
	//Audio GameObjects
	
	public GameObject buttonPressedSound; //To obtain and play the button pressed sound
	
	
	//Game objects
	
	
	public GameObject proximityTrigger;  //To access proximityTriggerScript
	public GameObject mainKeypad; //To access the main key pad object
	public GameObject codeHandler; //To access code handler script
	
	//Game Object variables
	
	
	private KeyCode useKey; //Used to access the use key
	private bool inProximity;  //obtaining the inProximity variable from the ProximityTrigger script
	private bool keypadButtonsAnimate; //We obtain this from the MainSettings Script (tells us whether we want to aniamte buttons or not)
	private bool keypadIsEnabled;  //
	
	//Other variables
	
	public int buttonPressed;  //So we can tell what button we pressed
	private bool buttonsAreEnabled; //Used to enable disable buttons
	private bool mouseIsOver = false;  //set to true when mouse is over button
	private string animationName;  //String for the animation
	
	
	
	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// Getting values from other scripts
		
		
		inProximity = proximityTrigger.GetComponent<ProximityTrigger>().inProximity; //Getting the inProximity variable
		useKey = mainKeypad.GetComponent<MainSettings>().useKey; //Getting the usekey
		
		buttonsAreEnabled = codeHandler.GetComponent<CodeHandler>().buttonsAreEnabled; //Getting the buttons are enabled variable
		keypadButtonsAnimate = mainKeypad.GetComponent<MainSettings>().keypadButtonsAnimate; //Getting the animate variable (tells us whether we want to aniamte buttons or not)
		keypadIsEnabled = mainKeypad.GetComponent<MainSettings>().keypadIsEnabled; //Getting keypad is enabled variable
		
	
		
		//Pressing the buttons
		
		
		if (Input.GetKeyDown(useKey) && mouseIsOver == true && inProximity == true && buttonsAreEnabled == true && keypadIsEnabled == true)
		{
			
			//Checking the button input
			
			if (gameObject.name == "Button00") //If it is button 0 
			{
				
				
				
				//Depending on the number of inputs, assign one with the number
				
				
				
				OnButtonPressed (); //Execute on button pressed method
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 0; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 0; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 0; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 0; break;
					}
					
			} else if (gameObject.name == "Button01") //If it is button 1 
			{
				
				
				
				
				//Depending on the number of inputs, assign one with the number
				
			
				OnButtonPressed (); //Execute on button pressed method
				
				//Depending on the number of inputs, assign one with the number
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 1; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 1; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 1; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 1; break;
					}
				
			} else if (gameObject.name == "Button02") //If it is button 2
			{
				
				
				OnButtonPressed (); //Execute on button pressed method
				
				//Depending on the number of inputs, assign one with the number
				
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 2; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 2; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 2; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 2; break;
					}
				
			} else if (gameObject.name == "Button03") //If it is button 3
			{
				
					
				
				OnButtonPressed (); //Execute on button pressed method
				
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 3; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 3; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 3; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 3; break;
					}
				
				
				//Depending on the number of inputs, assign one with the number
				
				
				
			}else if (gameObject.name == "Button04") //If it is button 4 
			{
				OnButtonPressed (); //Execute on button pressed method
				//Depending on the number of inputs, assign one with the number
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 4; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 4; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 4; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 4; break;
					}
					
			
				
				
				
				
				
				
			} else if (gameObject.name == "Button05") //If it is button 5 
			{
				
				//Depending on the number of inputs, assign one with the number
				OnButtonPressed (); //Execute on button pressed method
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 5; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 5; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 5; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 5; break;
					}
				
				
				
				
				
				
				
				
			}else if (gameObject.name == "Button06") //If it is button 6 
			{
				
				
				OnButtonPressed (); //Execute on button pressed method
				//Depending on the number of inputs, assign one with the number
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 6; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 6; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 6; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 6; break;
					}
				
			}else if (gameObject.name == "Button07") //If it is button 7 
			{
				
				
				OnButtonPressed (); //Execute on button pressed method
				//Depending on the number of inputs, assign one with the number
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 7; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 7; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 7; break;
						case 4: codeHandler.GetComponent <CodeHandler>(). inputtedNumber04 = 7; break;
					}
				
			}else if (gameObject.name == "Button08") //If it is button 8
			{
				
				
				OnButtonPressed (); //Execute on button pressed method
				//Depending on the number of inputs, assign one with the number
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 8; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 8; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 8; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 8; break;
					}
				
			}else if (gameObject.name == "Button09") //If it is button 9 
			{
				
				
				OnButtonPressed (); //Execute on button pressed method
				//Depending on the number of inputs, assign one with the number
				switch (codeHandler.GetComponent<CodeHandler>().numberOfInputs)
					{
						case 1:  codeHandler.GetComponent <CodeHandler>().inputtedNumber01 = 9; break;
						case 2:  codeHandler.GetComponent <CodeHandler>().inputtedNumber02 = 9; break;
						case 3:  codeHandler.GetComponent <CodeHandler>().inputtedNumber03 = 9; break;
						case 4:  codeHandler.GetComponent <CodeHandler>().inputtedNumber04 = 9; break;
					}
				
				
			}else if (gameObject.name == "ButtonClear") //If it is clear button
			{
				ClearButtonPressed();  //The clear button has its own method
				
			} else
			{
				// If the game object doesn't have a name that is any of the above
				
				Debug.LogError("You have renamed one or more button objects, please do not rename any children within the keypad");
				
			}
			
			
			
			
			
		}
		
		
		
		
		
	
	}
	
	void OnMouseOver ()  //When mouse is over button
	{
		
		mouseIsOver = true;  //The mouse is now over
		
		
		
	}
	
	void OnMouseExit() //When the mouse exits the button
	{
		mouseIsOver = false; //the mouse is now not over
		
	}
		
	
	
	
	
	void OnButtonPressed ()  //When a button is pressed
	{
		
		codeHandler.GetComponent<CodeHandler>().numberOfInputs++; //Increment the number of inputs
		
		buttonPressedSound.GetComponent<AudioSource>().Play();  //Play the button pressed sound
		
		
		
		if (keypadButtonsAnimate == true) // If the animate variable is true
		{
			gameObject.GetComponent<Animation>().Play();  //Play default animation
			
		}
		
		
	
		
	}
	
	void ClearButtonPressed () //When the clear button is pressed
	{
		codeHandler.GetComponent<CodeHandler>().numberOfInputs = 0; // Reset the number of inputs to 0
		buttonPressedSound.GetComponent<AudioSource>().Play(); // Play button pressed sound
		
		if (keypadButtonsAnimate == true) // If the animate variable is true
		{
			gameObject.GetComponent<Animation>().Play();  //Play default animation
			
		}
	}
	
	
	
	
}
