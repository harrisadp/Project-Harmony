using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentialManager : MonoBehaviour {

	private BattleMenuManager battleMenuManager;

	// Use this for initialization
	void Start () {
		battleMenuManager = FindObjectOfType<BattleMenuManager> ();
		gameObject.SetActive (false);
	}

	public void Enable () {
		gameObject.SetActive (true);
	}

	public void NextTurn () {
		gameObject.SetActive (false);
		battleMenuManager.Initialize ();
	}

}
