// POWER CELL

//#pragma strict
var textHints		: GUIText;
var rotationSpeed : float = 100.0;

function Start () {

}

function Update () 
{
	transform.Rotate(Vector3(0,rotationSpeed * Time.deltaTime));
}

function OnTriggerEnter(col : Collider)
{
	if(col.gameObject.tag == "Player")
	{
		col.gameObject.SendMessage("CellPickup");
		Destroy(gameObject);
		textHints.SendMessage("ShowHint", "You found a Generator Power Cell.");
	}
}

