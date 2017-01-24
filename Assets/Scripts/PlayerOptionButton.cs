using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptionButton : MonoBehaviour {

	public TextAsset textAsset;

	private DialogueManager dialogueManager;
	private MenuManager menuManager;
	private DiseaseChooser diseaseChooser;

	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		menuManager = FindObjectOfType<MenuManager> ();
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPushed () {		
		PlayDialogue ();
		PerformanceCheckingMethod ();
	}

	public void PlayDialogue () {
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains (this.name)) {
					dialogueManager.LineStart(lineNum);
					dialogueManager.LineBreak (lineNum+1);
					dialogueManager.NewTalk ();
					menuManager.Reset ();
					return;
				}
			}
		}
	}

	public void PerformanceCheckingMethod () {
		int questionNumber = 0;
		foreach (string question in diseaseChooser.disease_data.questions) {
			if (question == this.name) {
				questionNumber = Array.IndexOf (diseaseChooser.disease_data.questions, this.name);
			}	
		}
		if (diseaseChooser.disease_data.goodQuestions.Contains (questionNumber)) {
			Debug.Log ("Question number " + questionNumber + " is a good question.");
		} else {
			Debug.Log ("Question number " + questionNumber + " is a bad question.");
		}
	}

}
