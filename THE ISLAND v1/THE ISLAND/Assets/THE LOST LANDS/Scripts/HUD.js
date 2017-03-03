// GAME HUD SCRIPTS

// HUD VARS
static var hudTorchBatCharge 	: int = 4;
var hudTorchBat			: Texture2D[];
var hudTorchBatTexture	: GUITexture;
var torchTimerInterval	: int = 30;
var torchTimerAmount	: int = torchTimerInterval;

function Start () 
{
	// Start the Game Timer (Torch Battery Life
	InvokeRepeating ("TorchCountdown",0.0,1.0);	// Repeat countdown every second
}

function Update () 
{
    // UPDATE THE HUD 
	hudTorchBatTexture.texture = hudTorchBat[hudTorchBatCharge];
}

// Timer Countdown function
function TorchCountdown ()
{
	if (TorchLight.torchIsOn == true)
	{
		if(torchTimerAmount > 0)
		{
			torchTimerAmount -= 1;
		}
		else
		{
			// Reset Intervals
			torchTimerAmount = torchTimerInterval;
			
			// Stop if we get to 0
			if(hudTorchBatCharge > 0) 	// Subtract
			{
				hudTorchBatCharge -= 1;
			}
			else 
			{
				// Make sure it doesn't go below 0
				hudTorchBatCharge = 0;
				TorchLight.batteryDead = true;
			}
		}
	}
}

