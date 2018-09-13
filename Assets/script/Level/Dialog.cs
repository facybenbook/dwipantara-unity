using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

	public GameObject dialog;
	// Use this for initialization

	private void OnTriggerEnter2D(Collider2D col) {
		dialog.gameObject.SetActive (true);
		string Honai = "Honai";
		PlayerPrefs.SetString("Honai", Honai);
	}

	private void OnTriggerExit2D(Collider2D col) {
		dialog.gameObject.SetActive (false);
	}
}
