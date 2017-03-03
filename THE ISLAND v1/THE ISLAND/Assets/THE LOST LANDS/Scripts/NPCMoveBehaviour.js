#pragma strict
 
/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
@script RequireComponent(CharacterController)
 
var speed:float = 6;
var directionChangeInterval:float = 10;
var maxHeadingChange:float = 30;

var heading: float=0;
var targetRotation: Vector3 ;

static var playerInSight 	: boolean = false;
static var npcFleeing		: boolean = false;
static var npcReturnToBase	: boolean = false;
var startingPosition : Vector3;
var maxRange : float = 150;
var playerHuntRange : float = 80;
static var npcHuntSpeed = 4;
static var npcSpawnPoint : Vector3;
static var npcSpawnPoint2 : Vector3;
static var npcSpawnPoint3 : Vector3;

function Start ()
{

}

function Awake ()
{
	// Remember starting position
	startingPosition = transform.position;
	npcSpawnPoint = Vector3(400,45,390);
	npcSpawnPoint2 = Vector3(340,50,100);
	npcSpawnPoint3 = Vector3(280,40,240);
	
    // Set random initial rotation
	//transform.eulerAngles = Vector3(0, Random.Range(0,360), 0);  // look in a random direction at start of frame.

    //StartCoroutine
    InvokeRepeating("NPCWander", 0, directionChangeInterval);
//	NewHeadingRoutine ();
}

function Update (){
	var controller : CharacterController = GetComponent(CharacterController);
	
	targetRotation = Vector3(0,heading,0);
   	transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * 0.5);
  	
  	if(npcReturnToBase == true || npcFleeing == true)
  	{
  		transform.eulerAngles = Vector3(0, heading, 0);
  	}
    
    var forward = transform.TransformDirection(Vector3.forward);
    controller.SimpleMove(forward * npcHuntSpeed);
    
    // Check if the player is within range (to hunt)
    var dist = GetDistance(transform.position, PlayerTracking.playerPosition);
	
	// If within range of player, hunt player
    if (dist <= playerHuntRange) { playerInSight = true; }
    else { playerInSight = false; }
    
    
}

/// <summary>
/// Repeatedly calculates a new direction to move towards.
/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
/// </summary>

//while (true)
function NPCWander()
{
	NewHeadingRoutine();
	//yield WaitForSeconds(directionChangeInterval);
}

function NPCFlee()
{
	npcFleeing = false;
	CancelInvoke("NPCFlee");
}


/// <summary>
/// Calculates a new direction to move towards.
/// </summary>
function NewHeadingRoutine (){
    var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
    var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
    
    // If no player in sight and not fleeing, find a random direction
        
    if (playerInSight == false && npcFleeing == false && npcReturnToBase == false)
    {
    	npcHuntSpeed = 4;
		heading = Random.Range(floor, ceil);
		
		// Make sure NPC doesn't stray from his area
		// Get the Distance from the base
		var dist = GetDistance(transform.position, startingPosition);
		
		//If the distance exceeds limits, or NPC has hit a boundary, go back
		if(dist >= maxRange) 
		{
			// New heading to go back 
			heading = GetDirection(transform.position,startingPosition,transform.eulerAngles.y);
			
		}
		
		//print("Distance = " + dist);
		//print("Heading = " + heading);
		
		targetRotation = new Vector3(0, heading, 0);
	}
    else if (npcFleeing == true)
    {
    	print("NPC running away!");
    	npcHuntSpeed = 15;
    	Invoke("NPCFlee", 5);
    	// New heading to go back 
    	var fleePoint : Vector3;
    	//if(GetDistance(PlayerTracking.playerPosition,fleePoint) < 100) { fleePoint = npcSpawnPoint2; }
		var randomPoint = Random.Range(0,2);
		switch (randomPoint)
		{
			case 0 :
				fleePoint = npcSpawnPoint;
				if(GetDistance(PlayerTracking.playerPosition,fleePoint) < 80) { fleePoint = npcSpawnPoint2; }
			case 1 :
				fleePoint = npcSpawnPoint2;
				if(GetDistance(PlayerTracking.playerPosition,fleePoint) < 80) { fleePoint = npcSpawnPoint3; }
			case 2 :
				fleePoint = npcSpawnPoint3;
				if(GetDistance(PlayerTracking.playerPosition,fleePoint) < 80) { fleePoint = npcSpawnPoint; }
		}
		// Make sure they don't flee to where you are!
		
		heading = GetDirection(transform.position,fleePoint,transform.eulerAngles.y);
		
    }    
    else if (npcReturnToBase == true)
    {
    	//print("NPC RETURNING TO BASE!");
    	// New heading to go back 
    	npcHuntSpeed = 8;
		heading = GetDirection(transform.position,startingPosition,transform.eulerAngles.y);
    }
    // If the player has been spotted and he is not safe in the light
    else if (playerInSight == true)
    {
    	if(PlayerTracking.playerInLight == false)
    	{	
    		//Player is fair game! Go get him!
	    	npcHuntSpeed = 6.5;
	    	//print("Player has been found - hunting..");
	    	heading = GetDirection(transform.position,PlayerTracking.playerPosition,transform.eulerAngles.y);
	    }
	    else
	    {
    		//Player is hiding like a wuss! :-)
	    	npcHuntSpeed = 4;
	    	print("Player is safe once more.");
	    	heading = GetDirection(transform.position,startingPosition,transform.eulerAngles.y);
	    }
    }
}
	

// THIS FUNCTION RETURNS THE ANGLE BETWEEN 2 VECTOR3 POINTS
// But only returns the flat (x,z) degree angle
function GetDirection(coord1 : Vector3,coord2 : Vector3,originalRotation : float) : float
{
	var xDiff 	: float = coord2.x - coord1.x;
	var zDiff 	: float = coord2.z - coord1.z;
	var angle 	: float = 0.0;
	var quad 	: int = 1;
	
	if(xDiff == 0 && zDiff == 0) { return 0; }
	if(xDiff >= 0) 
	{
		if (zDiff >= 0) { quad = 1; }
		else { quad = 2; }
	}
	else
	{
		if (zDiff < 0) { quad = 3; }
		else { quad = 4; }
	}	
	
	// Normalise values
	if (xDiff < 0) { xDiff = xDiff * -1; }
	if (zDiff < 0) { zDiff = zDiff * -1; }
	
	//Get the angle (within 90 degrees)
	angle = Mathf.Atan2(xDiff,zDiff) * Mathf.Rad2Deg;
		
	// Add the quadrant values
	if(quad == 1) { angle = angle + 0; }
	else if(quad == 2) { angle = angle + 90; }
	else if(quad == 3) { angle = angle + 180; }
	else if(quad == 4) { angle = angle + 270; }
	
	//print("World Angle = " + angle);
	
	// Make sure there are no negative angles
	if (angle < 0) { angle += 360; }
	
	return angle;
	
	/*
	// Make sure to remove the original rotation value / Adjust for player facing
	if (originalRotation >= angle) { angle = originalRotation - angle; }
	else { angle = angle - originalRotation; }
	
	print("Turn Angle = " + angle);
	
	return angle;
	*/
}

function GetDistance(coord1 : Vector3,coord2 : Vector3)
{
	var xDiff : float = coord2.x - coord1.x;
	var zDiff : float = coord2.z - coord1.z;
	var distance : float = 0.0;
	distance = Mathf.Sqrt((xDiff * xDiff) + (zDiff * zDiff));
	
	return distance;
}
