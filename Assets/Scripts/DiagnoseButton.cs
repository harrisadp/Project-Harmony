using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagnoseButton : MonoBehaviour {

	public GameObject topDiagnosis;

	private Disease disease;
	private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
		disease = FindObjectOfType<Disease> ();
		dialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckDiagnosis (){
		if (topDiagnosis.transform.childCount <= 0) {
			Debug.Log ("There is no diagnosis in the top slot!");
			dialogueManager.LineStart (88);
			dialogueManager.LineBreak (88);
			dialogueManager.NewTalk ();
		} else if (disease.diseaseName != topDiagnosis.GetComponentInChildren<Text> ().text) {
			Debug.Log ("Top diagnosis is incorrect. Try again!");
			dialogueManager.LineStart (85);
			dialogueManager.LineBreak (85);
			dialogueManager.NewTalk ();
		} else if (disease.diseaseName == topDiagnosis.GetComponentInChildren<Text> ().text) {
			Debug.Log ("Top diagnosis is correct!");
			dialogueManager.LineStart (82);
			dialogueManager.LineBreak (82);
			dialogueManager.NewTalk ();
		}
	}

}
