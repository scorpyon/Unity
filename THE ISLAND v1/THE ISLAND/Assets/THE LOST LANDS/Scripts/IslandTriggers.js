// ISLAND TRIGGER ZONE SCRIPTS

//#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter (col : Collider)
{
	if(col.gameObject.tag == "ghost")
	{
		print("Ghost has entered the trigger");
		// Set the ghost to head back to base
		NPCMoveBehaviour.npcReturnToBase = true;
		
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
}




