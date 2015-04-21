using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public void changeScene(string whichScene) {
        Application.LoadLevel(whichScene);
	}

    public void exitGame() {
        Application.LoadLevel("Exit");
    }

    IEnumerator returnToMainMenu() {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("MainMenu");
    }
}
