// INVENTORY SCRIPTS

// VARIABLES
static var charge 	: int = 0;
var collectSound 	: AudioClip;

// HUD
var hudCharge 		: Texture2D[];
var chargeHudGUI	: GUITexture;

// Generator
var meterCharge 	: Texture2D[];
var meter			: Renderer;

//#pragma strict

function Start () 
{
	charge = 0;
}

function Update () 
{
}

function CellPickup() 
{
	// Turn the HUD on
	HUDon();
	AudioSource.PlayClipAtPoint(collectSound, transform.position);
	charge++;
	// UPDATE THE HUD 
	chargeHudGUI.texture = hudCharge[charge];
	// UPDATE THE GENERATOR GRAPHIC
	meter.material.mainTexture = meterCharge[charge];
}

function HUDon() 
{
	if(!chargeHudGUI.enabled)
	{
		chargeHudGUI.enabled = true;
	}
}

