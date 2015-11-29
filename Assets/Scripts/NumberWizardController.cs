using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizardController : MonoBehaviour {
	
	int min = 0;
	int max = 1000;
	int guess = -1;
	int max_guesses = 10;
	
	string guessTextFormat = "Is your number higher or lower then {0:#}?";
	string titleTextFormat = "{0:#} guesses left...";
	
	public Text guessText;
	public Text title;
	
	// Use this for initialization
	void Start () {		
		guess = (int) Random.Range(min + 1, max + 1);		
	}
	
	// Update is called once per frame
	void Update () {
		guessText.text = string.Format(guessTextFormat, guess);
		title.text = string.Format(titleTextFormat, max_guesses);
	}
	
	public void GuessLower(){
		max = guess;
		NextGuess();
	}
	
	public void GuessHigher(){
		min = guess;
		NextGuess();
	}
	
	public void GuessRight(){
		Application.LoadLevel("Lose");
	}	
	
	public void NextGuess(){		
		if(max_guesses == 1)
			Application.LoadLevel("Win");
		else {
			guess = (int) Random.Range(min + 1, max + 1);
			max_guesses--;
		}
	}
}
