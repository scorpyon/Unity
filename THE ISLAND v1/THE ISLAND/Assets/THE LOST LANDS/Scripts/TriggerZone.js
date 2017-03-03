// TRIGGER ZONE SCRIPTS

// VARIABLES
var lockedSound 	: AudioClip;

// Door Light
var doorLight 		: Light;

// Hint Text
var textHints		: GUIText;

//#pragma strict

function Start () {

}

function Update () 
{

}

function OnTriggerEnter (col : Collider)
{
	if(col.gameObject.tag == "Player")
	{
		if(Inventory.charge == 4)
		{
			transform.FindChild("door").SendMessage("DoorCheck");
			if(GameObject.Find("PowerGUI"))
			{
				Destroy(GameObject.Find("PowerGUI"));
				doorLight.color = Color.green;
			}
		}
		else if(Inventory.charge > 0 && Inventory.charge < 4)
		{
			textHints.SendMessage("ShowHint", "The door still needs more power. Maybe more power-cells will help...");
			transform.FindChild("door").audio.PlayOneShot(lockedSound);
		}
		else
		{
			transform.FindChild("door").audio.PlayOneShot(lockedSound);
			col.gameObject.SendMessage("HUDon");
			textHints.SendMessage("ShowHint", "Hmm. It's locked... Looks like that generator needs power.");
		}
	}
}

