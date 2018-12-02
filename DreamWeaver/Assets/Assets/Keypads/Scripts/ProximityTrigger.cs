
// This script handles the enabling and disabling of keypad buttons and the crosshair image


using UnityEngine;
using System.Collections;

public class ProximityTrigger : MonoBehaviour {
	
	public bool inProximity = false; //Tells us whether or not we're in proximity
	
	private Texture2D crosshairImage;   // For the crosshair image
	
	private bool crosshairEnabled;  // Hides the crosshair
	
	private bool keypadIsEnabled; //This is used so we can tell whether or not the keypad is enabled to display the crosshair or not
	
	
	//Game Objects
	
	private GameObject player;  //To access the player object
	public GameObject mainKeypad;  // We're using the mainKeypad object to access the MainSettings script
	
	
	
	

	// Use this for initialization
	void Start () {
		
		inProximity = false;  
		
		
		
		player = mainKeypad.GetComponent<MainSettings>().FPSController; //Accessing FPS Controller object
		crosshairImage = mainKeypad.GetComponent<MainSettings>().crosshairImage; //Getting the crosshair image
		crosshairEnabled = mainKeypad.GetComponent<MainSettings>().enableCrosshair;  //Checks whether or not the crosshair is enabled or not
		keypadIsEnabled = mainKeypad.GetComponent<MainSettings>().keypadIsEnabled; //gGetting the keypad is enabled variable
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		
	
		
		
	
	}
	
	void OnTriggerEnter (Collider other) 
	{
		
		if (other.name == player.name)  //If the player collides with the trigger
		{
			
			inProximity = true;    // The player is now in proximity
			
		}
		
		
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.name == player.name) //If the player exits the trigger
		{
			
			inProximity = false;  // The player is now out of proximity
			
		}
		
		
		
		
	}
	
	
	
	
	
	
	void OnGUI()
	{
	 
	if (inProximity == true && crosshairEnabled == true && keypadIsEnabled == true)  //If the player is in proximity and the crosshair is enabled
		{
	 
			float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
			float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
			GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.height, crosshairImage.width), crosshairImage);
	 
		} 
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
