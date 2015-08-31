using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {

	int max = 1000;
	int min = 1;
	int guess = 500;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame(){
		max++;
		print ("Welcome to Number Wizard!");
		print ("Pick a number in your head, but don't tell me what it is!");
		
		print ("The highest number you can pick is " + max);
		print ("The lowest number you can pick is " + min);
		
		print ("Is the number higher or lower than "+ guess + "?");
		print ("Arrow = Higher, Down Arrow = Lower, and Enter if this is your number!");
	}
	
	void NextGuess(){
		guess = (min + max) / 2;
		print("Higher or Lower than " + guess + "?");
		print ("Arrow = Higher, Down Arrow = Lower, and Enter if this is your number!");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			min = guess;
			NextGuess();
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			max = guess;
			NextGuess();
		}
		else if(Input.GetKeyDown(KeyCode.Return)){
			print ("I won!");
			guess = 500;
		}
	}
}
