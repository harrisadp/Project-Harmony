﻿using System;
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
	private History history;
	private PhysicalExam physical;
	private LabValues labValues;

	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		menuManager = FindObjectOfType<MenuManager> ();
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		performanceTracker = FindObjectOfType<PerformanceTracker> ();
		history = FindObjectOfType<History> ();
		physical = FindObjectOfType<PhysicalExam> ();
		labValues = FindObjectOfType<LabValues> ();
	}

	public void ButtonPushed () {		
		PlayDialogue ();
		if (history.history.ContainsKey (this.name)) {
			CheckIfGoodQuestion ();
		} else if (physical.physical.ContainsKey (this.name)) {
			CheckIfGoodPhysical ();
		} else {
			return;
		}
	}

	private void PlayDialogue () {
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains (this.name) && history.history.ContainsKey (this.name)) {
					dialogueManager.LineStart (lineNum);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					menuManager.Reset ();
					return;
				} else if (line.Contains (this.name) && physical.physical.ContainsKey (this.name)) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 3);
					dialogueManager.NewTalk ();
					menuManager.Reset ();
					return;
				} else if (line.Contains (this.name) && labValues.labStudies.Contains (this.name)) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 5);
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
			performanceTracker.UpdateScore ();
		}
	}

	private void CheckIfGoodPhysical () {
		int physicalNumber = 0;
		foreach (string physicalManeuver in diseaseChooser.disease_data.physicalManeuvers) {
			if (physicalManeuver == this.name) {
				physicalNumber = Array.IndexOf (diseaseChooser.disease_data.physicalManeuvers, this.name);
			}
		}
		if (diseaseChooser.disease_data.goodPhysicalManeuvers.Contains (physicalNumber)) {
			performanceTracker.score += 100;
			if (performanceTracker.energyValue < 10) {
				performanceTracker.energyValue += 2;
			}
			performanceTracker.UpdateScore ();
		} else {
			performanceTracker.score -= 100;
			performanceTracker.UpdateScore ();
		}
	}

}
