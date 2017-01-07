using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuManager : MonoBehaviour {

	// Main menu
	public GameObject history;
	public GameObject physical;
	public GameObject labs;
	public GameObject imaging;

	// Labs
	public GameObject blood;
	public GameObject urine;
	public GameObject csf;

	// Blood
	public GameObject cbc;
	public GameObject bmp;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
	}

	public void Reset () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
	}

	public void Initialize () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
		
		history.SetActive (true);
		physical.SetActive (true);
		labs.SetActive (true);
		imaging.SetActive (true);
	}

	public void Labs () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}

		blood.SetActive (true);
		urine.SetActive (true);
		csf.SetActive (true);
	}

	public void Blood () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}

		cbc.SetActive (true);
		bmp.SetActive (true);
	}

}
