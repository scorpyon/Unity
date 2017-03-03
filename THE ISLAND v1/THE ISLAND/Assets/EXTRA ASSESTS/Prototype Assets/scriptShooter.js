
// SHOOTER SCRIPT

// PUB VARS
var bullet 		: Rigidbody;
var power 		: float = 1500;
var moveSpeed 	: float = 5;


//#pragma strict

function Start () {
}

function Update () 
{
	// Store the movement as a variable.
	var h : float = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
	var v : float = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
	
	// Move the camera with the set directon keys
	transform.Translate(h, v, 0);
	
	// Fire the bullet - when the mouse button is released
	if(Input.GetButtonUp("Fire1"))
	{
		// Create the bullet to be fired
		// Create as a Rigidbody object, with the position and rotation of what this script is currently linked to - ie: the Camera. :-)
		var instance : Rigidbody = Instantiate(bullet, transform.position, transform.rotation);
		
		// Apply force to the bullet to fire it in the direction of the camera-facing direction
		// TransformDirection - converts a LOCAL direction into a WORLD Direction
		var fwd : Vector3 = transform.TransformDirection(Vector3.forward);		// We create a Vector3 variable which represents the forward direction of the the current camera angle
		// Add a force to our newly created object : instance
		// Multiply the direction of the force by how much power we previously set
		instance.AddForce(fwd * power);
	}
}

