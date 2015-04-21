using UnityEngine;
using System.Collections;

public class ComingSoonScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(returnToMainMenu());
	}

    IEnumerator returnToMainMenu() {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("MainMenu");
    }
}
