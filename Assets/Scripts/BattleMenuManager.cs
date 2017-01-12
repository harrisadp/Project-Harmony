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

	// History
	public GameObject hpi;
	public GameObject pmh;
	public GameObject psh;
	public GameObject sh;
	public GameObject fh;
	public GameObject backHistory;

	// Physical
	public GameObject heent;
	public GameObject card;
	public GameObject pulm;
	public GameObject abd;
	public GameObject neuro;
	public GameObject msk;
	public GameObject skin;
	public GameObject backPhysical;

	// Labs
	public GameObject blood;
	public GameObject urine;
	public GameObject csf;
	public GameObject backLabs;

	// Blood
	public GameObject cbc;
	public GameObject bmp;
	public GameObject lft;
	public GameObject coags;
	public GameObject backBlood;

	// Imaging
	public GameObject xray;
	public GameObject ct;
	public GameObject mri;
	public GameObject us;
	public GameObject pet;
	public GameObject backImaging;

	public GameObject ddx;
	public DifferentialManager differentialManager;

	private bool isFirstTurn = true;
	private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		dialogueManager = FindObjectOfType<DialogueManager> ();
	}

	public void Reset () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
	}

	public void NewTurn () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}

		if (isFirstTurn) {
			FirstTurn ();
		} else {
			history.SetActive (true);
			physical.SetActive (true);
			labs.SetActive (true);
			imaging.SetActive (true);
			ddx.SetActive (true);
		}

	}

	public void FirstTurn() {
		isFirstTurn = false;
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		differentialManager.Enable ();
		dialogueManager.LineStart (91);
		dialogueManager.LineBreak (91);
		dialogueManager.NewTalk ();
	}

	public void History () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		hpi.SetActive (true);
		pmh.SetActive (true);
		psh.SetActive (true);
		sh.SetActive (true);
		fh.SetActive (true);
		backHistory.SetActive (true);
	}

	public void Physical () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		heent.SetActive (true);
		card.SetActive (true);
		pulm.SetActive (true);
		abd.SetActive (true);
		neuro.SetActive (true);
		msk.SetActive (true);
		skin.SetActive (true);
		backPhysical.SetActive (true);
	}

	public void Labs () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		blood.SetActive (true);
		urine.SetActive (true);
		csf.SetActive (true);
		backLabs.SetActive (true);
	}

	public void Blood () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		cbc.SetActive (true);
		bmp.SetActive (true);
		lft.SetActive (true);
		coags.SetActive (true);
		backBlood.SetActive (true);
	}

	public void Imaging () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		xray.SetActive (true);
		ct.SetActive (true);
		mri.SetActive (true);
		us.SetActive (true);
		pet.SetActive (true);
		backImaging.SetActive (true);
	}

}
