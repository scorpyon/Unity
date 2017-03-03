// Functions to control the audio for player footsteps etc

var playerOnSand 	: AudioClip;
var findPlayer 		: Transform;
var playerWalking	: boolean = false;


//#pragma strict

function Start () {

}

function Update () 
{
	if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
	{
		if(Input.GetKey("space"))
		{	
			audio.Stop();
			playerWalking = true;
			PlayerJumping ();
		}
		if(playerWalking == false)
		{
			audio.Stop();
			audio.PlayOneShot(playerOnSand, 0.5);
			audio.volume = 0.3;
			playerWalking = true;
			QueueSoundEnd (playerOnSand);
		}
	}
	else
	{
		audio.Stop();
		playerWalking = false;
	}
}

function QueueSoundEnd (aClip : AudioClip)
{
	yield WaitForSeconds(aClip.length - 0.5);
	if(playerWalking == true) { playerWalking = false; }
}

function PlayerJumping ()
{
	yield WaitForSeconds(0.4);
	if(playerWalking == true) { playerWalking = false; }
}
