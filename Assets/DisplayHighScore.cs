using UnityEngine;
using System.Collections;

public class DisplayHighScore : MonoBehaviour {

	// Use this for initialization
	
	

	void OnGUI()
	{
	 if (GUI.Button(new Rect(10, 10, 150, 100), "Retry"))
		{
            Application.LoadLevel("main");
		}
		GUI.Box(new Rect(20,20,400,500),
						"1 highscore er " + PlayerPrefs.GetInt("highScoreNr" + 1) +  "\r\n"  +
						"2 highscore er " + PlayerPrefs.GetInt("highScoreNr2") +  "\r\n"  +
						"3 highscore er " + PlayerPrefs.GetInt("highScoreNr3") +  "\r\n"  +
						"4 highscore er " + PlayerPrefs.GetInt("highScoreNr4") +  "\r\n"  +
						"5 highscore er " + PlayerPrefs.GetInt("highScoreNr5") +  "\r\n"  +
						"6 highscore er " + PlayerPrefs.GetInt("highScoreNr6") +  "\r\n"  +
						"7 highscore er " + PlayerPrefs.GetInt("highScoreNr7") +  "\r\n" +
						"8 highscore er " + PlayerPrefs.GetInt("highScoreNr8") +  "\r\n" +
						"9 highscore er " + PlayerPrefs.GetInt("highScoreNr9") +  "\r\n" +
						"10 highscore er " + PlayerPrefs.GetInt("highScoreNr10") +  "\r\n" 
				);
	
		
	}
}
