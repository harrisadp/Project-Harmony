using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DiagnoseButton : MonoBehaviour {

	public TextAsset textAsset;

	private DiseaseChooser diseaseChooser;
	private GameObject topDiagnosis;
	private DialogueManager dialogueManager;
	private MenuManager menuManager;

	void Start () {
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		topDiagnosis = GameObject.Find ("Top Diagnosis");
		dialogueManager = FindObjectOfType<DialogueManager> ();
		menuManager = FindObjectOfType<MenuManager> ();
	}

	public void CheckDiagnosis () {
		if (topDiagnosis.transform.childCount > 0) {
			if (topDiagnosis.GetComponentInChildren<Text> ().text == diseaseChooser.disease_data.disease_name) {
				DiagnosisCorrect ();
			} else {
				DiagnosisIncorrect ();
			}
		} else {
			NoDiagnosis ();
		}

	}

	private void DiagnosisCorrect () {
		menuManager.victory = true;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Correct diagnosis")) {
					dialogueManager.LineStart (lineNum +1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
				}
			}
		}
	}

	private void DiagnosisIncorrect () {
		menuManager.backToDifferential = true;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Incorrect diagnosis")) {
					dialogueManager.LineStart (lineNum +1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
				}
			}
		}
	}

	private void NoDiagnosis () {
		menuManager.backToDifferential = true;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("No top diagnosis")) {
					dialogueManager.LineStart (lineNum +1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
				}
			}
		}
	}

}
