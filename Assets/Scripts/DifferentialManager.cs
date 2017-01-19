using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentialManager : MonoBehaviour {

	private MenuManager battleMenuManager;

	// Use this for initialization
	void Start () {
		battleMenuManager = FindObjectOfType<MenuManager> ();
		gameObject.SetActive (false);
	}

	public void Enable () {
		gameObject.SetActive (true);
		if (battleMenuManager.isFirstTurn) {
			GameObject.Find ("Diagnose Button").SetActive (false);
		} else {
			foreach (Transform child in transform) {child.gameObject.SetActive (true);}
		}
	}

	public void NextTurn () {
		gameObject.SetActive (false);
		battleMenuManager.NewTurn ();
	}

}
