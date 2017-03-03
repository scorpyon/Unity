
var textHints			: GUIText;

//#pragma strict

function Start () 
{
	Invoke("Hint1",3);
	Invoke("Hint2",23);
	Invoke("Hint3",43);
	Invoke("Hint4",63);
}

function Update () {

}

function Hint1 (){
	textHints.SendMessage("ShowHint", "Use W,A,S,D to move.");
}
function Hint2 (){
	textHints.SendMessage("ShowHint", "Press F to use your Flashlight.");
}
function Hint3 (){
	textHints.SendMessage("ShowHint", "Your torch has a limited battery. Use it wisely...");
}
function Hint4 (){
	textHints.SendMessage("ShowHint", "Evil spirits hate the light. Use light to ward them off...");
}

