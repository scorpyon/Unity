// TORCH LIGHT SCRIPTS

// VARIABLES
//var torch 				: Light;
var cameraStartRot 		: Quaternion;
var mainCamera			: Transform;
var playerTransform		: Transform;
var smooth = 0.001;
var torchSpotAngle 		: float = 40.0;
var torchRange	 		: float = 80.0;
var torchIntensity 		: float = 1.6;
static var torchIsOn 	: boolean = false;
static var batteryDead  : boolean = false;
var textHints			: GUIText;
var torchButtonClick 	: AudioClip;
//#pragma strict


function Start () 
{
	Screen.showCursor = false;
	
}

function Update () 
{
	// Allow toggle on/off
	if(Input.GetKeyDown("f"))
	{
		if(!light.enabled && batteryDead == false) 
		{ 	
			torchIsOn = true;
			light.enabled = true; 
			playTorchButtonClip(torchButtonClick);
		}
		else if(batteryDead == true)
		{
			textHints.SendMessage("ShowHint", "Your torch battery is dead!");
			playTorchButtonClip(torchButtonClick);
		}
		else 
		{ 
			torchIsOn = false;
			light.enabled = false; 
			playTorchButtonClip(torchButtonClick);
		}
	}

	// Keep the torch with the player
//	transform.position = mainCamera.position;
	transform.position = playerTransform.position;
	transform.position.y += 0.5;
	
	// Set the torch direction based on the camera direction
	transform.rotation = mainCamera.rotation;
	
    
    // Update Battery strength / light strength
    torchSpotAngle = HUD.hudTorchBatCharge * 10;
    light.spotAngle = Mathf.Lerp(light.spotAngle, torchSpotAngle, Time.deltaTime * 0.1);
    torchTorchRange = HUD.hudTorchBatCharge * 20;
    light.range = Mathf.Lerp(light.range, torchTorchRange, Time.deltaTime * 0.1);
    //torchIntensity = HUD.hudTorchBatCharge * 0.4;
    //light.intensity = Mathf.Lerp(light.intensity, torchIntensity, Time.deltaTime * 1);
}

function playTorchButtonClip(torchButtonSound : AudioClip)
{
	audio.PlayOneShot(torchButtonSound);
}


