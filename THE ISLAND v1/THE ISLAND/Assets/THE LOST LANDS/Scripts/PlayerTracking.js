// Scripts for Tracking the player
static var playerPosition 	: Vector3;
static var playerInLight	: boolean = true;

//#pragma strict

function Start () {

}

function Update () 
{	
	// Keep track of the player's position in the level
	playerPosition = transform.position;
}

