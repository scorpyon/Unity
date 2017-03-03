 // TEXT HINT SCRIPTS

// VARIABLES
private var timer		: float = 0.0;
private var messageOnScreen : boolean = false;

var fadeDuration = 2.0;

//#pragma strict

function Start () 
{
    yield Fade (0.0, 1.0, fadeDuration);
    yield Fade (1.0, 0.0, fadeDuration);
    //Destroy(gameObject);
    guiText.enabled = true; 
    Fade(0,1,2);
}

function Update () 
{
//	if(guiText.enabled)
	if (messageOnScreen == true)
	{
		timer += Time.deltaTime;
		
		if (timer >= 4)
		{
			Fade(1,0,2);
			//guiText.enabled = false;
			timer = 0.0;
			messageOnScreen = false;
		}
	}
}

function ShowHint(message : String)
{	
// Clear previous messages
	if (messageOnScreen == true)
	{
		guiText.text = "";
		guiText.material.color.a = 0;
	}
	
	messageOnScreen = true;
	guiText.text = message;
	//if(!guiText.enabled) { guiText.enabled = true; }
	Fade(0,1,2);
	
}

function Fade (startLevel, endLevel, time) 
{
    var speed = 1.0/time;
    
    for (t = 0.0; t < 1.0; t += Time.deltaTime*speed) {
        guiText.material.color.a = Mathf.Lerp(startLevel, endLevel, t);
        yield;
    }
}
