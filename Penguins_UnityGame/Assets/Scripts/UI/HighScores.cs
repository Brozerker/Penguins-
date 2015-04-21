using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScores : MonoBehaviour {
    public int score;
    public int[] highscores;

	// Use this for initialization
	void Start () {
	    //highscores = PlayerPrefs
	}
	
	// Update is called once per frame
	private void updateScore() {
        var newScores = new List<int>(highscores);
        newScores.Add(score);
        highscores = newScores.ToArray();
	}
}
