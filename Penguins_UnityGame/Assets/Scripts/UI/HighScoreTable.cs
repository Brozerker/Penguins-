using UnityEngine;
using System.Collections;
using System.Linq;

public class HighScoreTable : MonoBehaviour {
    UILabel HSTableLabel;
    HighScores highScores;

	// Use this for initialization
	void Start () {
        highScores = GameObject.Find("Scores").GetComponent<HighScores>();
        HSTableLabel = GetComponent<UILabel>();

        if (highScores == null) {
            throw new MissingReferenceException("There are no scores");
        }
        if (HSTableLabel == null) {
            throw new MissingComponentException("Ain't no label");
        }

        var descendingScores = highScores.highscores.OrderByDescending(d => d).ToArray();

        for (int i = 0; i < highScores.highscores.Length; ++i) {
            HSTableLabel.text += i + ") " + highScores.highscores[i] + "\n";
        }
	}

    // Update is called once per frame
    void Update() {
	
	}
}
