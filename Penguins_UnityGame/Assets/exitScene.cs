using UnityEngine;
using System.Collections;

public class exitScene : MonoBehaviour {

	// Use this for initialization
	void Start() {
        StartCoroutine(MyCoroutine());
	}

    IEnumerator MyCoroutine() {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
