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
	private PerformanceTracker performanceTracker;

	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		menuManager = FindObjectOfType<MenuManager> ();
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		performanceTracker = FindObjectOfType<PerformanceTracker> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPushed () {		
		PlayDialogue ();
		CheckIfGoodQuestion ();
	}

	private void PlayDialogue () {
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

	private void CheckIfGoodQuestion () {
		int questionNumber = 0;
		foreach (string question in diseaseChooser.disease_data.questions) {
			if (question == this.name) {
				questionNumber = Array.IndexOf (diseaseChooser.disease_data.questions, this.name);
			}	
		}
		if (diseaseChooser.disease_data.goodQuestions.Contains (questionNumber)) {
			performanceTracker.score += 100;
			if (performanceTracker.energyValue < 10) {
				performanceTracker.energyValue += 2;
			}
			performanceTracker.UpdateScore ();
		} else {
			performanceTracker.score -= 100;
			if (performanceTracker.energyValue > 0) {
				performanceTracker.energyValue -= 2;
			}
			performanceTracker.UpdateScore ();
		}
	}

}
