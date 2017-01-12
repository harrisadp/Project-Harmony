using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagnoseButton : MonoBehaviour {

	public GameObject topDiagnosis;

	private Disease disease;
	private DialogueManager dialogueManager;
	private BattleMenuManager battleMenuManager;

	// Use this for initialization
	void Start () {
		disease = FindObjectOfType<Disease> ();
		dialogueManager = FindObjectOfType<DialogueManager> ();
		battleMenuManager = FindObjectOfType<BattleMenuManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckDiagnosis (){
		if (topDiagnosis.transform.childCount <= 0) {
			dialogueManager.LineStart (88);
			dialogueManager.LineBreak (88);
			dialogueManager.NewTalk ();
		} else if (disease.diseaseName != topDiagnosis.GetComponentInChildren<Text> ().text) {
			dialogueManager.LineStart (85);
			dialogueManager.LineBreak (85);
			dialogueManager.NewTalk ();
		} else if (disease.diseaseName == topDiagnosis.GetComponentInChildren<Text> ().text) {
			dialogueManager.LineStart (82);
			dialogueManager.LineBreak (82);
			battleMenuManager.victory = true;
			dialogueManager.NewTalk ();
		}
	}

}
