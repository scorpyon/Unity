// Safe Light ZONE SCRIPTS

//#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter (col : Collider)
{
	// Ghosts cannot enter here
	if(col.gameObject.tag == "ghost")
	{
		print("Ghost has entered the trigger");
		// Set the ghost to head back to base
		NPCMoveBehaviour.npcReturnToBase = true;
		
	}
	// Player is safe from ghosts in this area
	else if (col.gameObject.tag == "Player")
	{
		PlayerTracking.playerInLight = true;
		print("Player is safe and in the light");
	}
}


function OnTriggerExit (col : Collider)
{
	if(col.gameObject.tag == "ghost")
	{
		print("Ghost has entered the trigger");
		// Set the ghost to head back to base
		NPCMoveBehaviour.npcReturnToBase = false;
	}
	// Player is safe from ghosts in this area
	else if (col.gameObject.tag == "Player")
	{
		PlayerTracking.playerInLight = false;
		print("Player has left the light");
	}
}
