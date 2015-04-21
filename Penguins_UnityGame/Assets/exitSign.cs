using UnityEngine;
using System.Collections;

public class exitSign : MonoBehaviour {
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Something entered");
        if (other.name == "Player") {
            //(GameObject.FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < 1) {
            Application.LoadLevel("Exit");
            Debug.Log("It was me");
        }
	}

    void OnTriggerExit(Collider other) {
        Debug.Log("Something exited");
        if (other.name == "Player") {
            //(GameObject.FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < 1) {
            Application.LoadLevel("Exit");
            Debug.Log("It was me");
        }
    }

    void OnTriggerStay(Collider other) {
        Debug.Log("Something stayed");
        if (other.name == "Player") {
            //(GameObject.FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < 1) {
            Application.LoadLevel("Exit");
            Debug.Log("It was me");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
