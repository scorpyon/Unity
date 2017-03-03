#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter (col : Collider)
{
	//Make sure torch is on and it has battery power
	if(TorchLight.torchIsOn == true && TorchLight.batteryDead == false)
	{
		print("Torch Burn successful, looking for ghost...");
		if(col.gameObject.tag == "ghost")
		{
			print("Ghost has been zapped!");
			// Set the ghost to head back to base
			NPCMoveBehaviour.npcFleeing = true;
			
		}
	}
	else
	{
		print("Torch is not on or battery dead!");
	}
}
