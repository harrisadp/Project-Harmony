using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour {

	public GameObject journalEntry;

	private PerformanceTracker performanceTracker;
	private DiseaseChooser diseaseChooser;
	private History history;
	private PhysicalExam physicalExam;
	private LabValues labValues;
	private GameObject scrollView;
	private bool journalOpen = false;

	// Use this for initialization
	void Start () {
		performanceTracker = FindObjectOfType<PerformanceTracker> ();
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		history = FindObjectOfType<History> ();
		physicalExam = FindObjectOfType<PhysicalExam> ();
		labValues = FindObjectOfType<LabValues> ();
		scrollView = gameObject.transform.parent.parent.gameObject;
	}

	public void ToggleJournal () {
		if (journalOpen == false) {
			OpenJournal ();
		} else if (journalOpen == true) {
			CloseJournal ();
		}
	}

	public void OpenJournal () {
		journalOpen = true;
		scrollView.SetActive (true);
		// Journal header
		GameObject title = Instantiate (journalEntry, this.transform);
		title.GetComponent<Text> ().text = "JOURNAL";
		title.transform.localScale = new Vector3 (1, 1, 1);
		title.GetComponent<Text> ().alignment = TextAnchor.UpperCenter;
		// History header
		GameObject historyHeader = Instantiate (journalEntry, this.transform);
		historyHeader.GetComponent<Text> ().text = "HISTORY";
		historyHeader.transform.localScale = new Vector3 (1, 1, 1);
		historyHeader.GetComponent<Text> ().fontStyle = FontStyle.BoldAndItalic;
		// History population
		foreach (string question in performanceTracker.questionsAsked) {
			GameObject questionText = Instantiate (journalEntry, this.transform);
			questionText.GetComponent<Text> ().text = question + "?";
			questionText.transform.localScale = new Vector3 (1, 1, 1);
			TextGenerator tgQuestions = questionText.GetComponent<Text> ().cachedTextGenerator;
			Canvas.ForceUpdateCanvases ();
			questionText.GetComponent<LayoutElement> ().minHeight = 30f * tgQuestions.lineCount;
			GameObject answerText = Instantiate (journalEntry, this.transform);
			answerText.GetComponent<Text> ().text = history.history [question];
			answerText.transform.localScale = new Vector3 (1, 1, 1);
			answerText.GetComponent<Text> ().color = Color.yellow;
			TextGenerator tgAnswers = answerText.GetComponent<Text> ().cachedTextGenerator;
			Canvas.ForceUpdateCanvases ();
			answerText.GetComponent<LayoutElement> ().minHeight = 30f * tgAnswers.lineCount;
			// Check if good question and change text color accordingly
			int questionNumber = 0;
			foreach (string questionFromList in diseaseChooser.disease_data.questions) {
				if (questionFromList == question) {
					questionNumber = Array.IndexOf (diseaseChooser.disease_data.questions, question);
				}
			}
			if (diseaseChooser.disease_data.goodQuestions.Contains (questionNumber)) {
				answerText.GetComponent<Text> ().color = Color.green;
			} else if (diseaseChooser.disease_data.badQuestions.Contains (questionNumber)) {
				answerText.GetComponent<Text> ().color = Color.red;
			}
		}
		// If no history
		if (performanceTracker.questionsAsked.Count == 0) {
			GameObject noHistory = Instantiate (journalEntry, this.transform);
			noHistory.GetComponent<Text> ().text = "No history obtained";
			noHistory.transform.localScale = new Vector3 (1, 1, 1);
		}
		// Physical header
		GameObject physicalHeader = Instantiate (journalEntry, this.transform);
		physicalHeader.GetComponent<Text> ().text = "PHYSICAL";
		physicalHeader.transform.localScale = new Vector3 (1, 1, 1);
		physicalHeader.GetComponent<Text> ().fontStyle = FontStyle.BoldAndItalic;
		// Physical population
		foreach (string physicalManeuver in performanceTracker.physicalManeuversPerformed) {
			GameObject physicalText = Instantiate (journalEntry, this.transform);
			physicalText.GetComponent<Text> ().text = physicalManeuver;
			physicalText.transform.localScale = new Vector3 (1, 1, 1);
			TextGenerator tgPhysicalManeuvers = physicalText.GetComponent<Text> ().cachedTextGenerator;
			Canvas.ForceUpdateCanvases ();
			physicalText.GetComponent<LayoutElement> ().minHeight = 30f * tgPhysicalManeuvers.lineCount;
			GameObject physicalResult = Instantiate (journalEntry, this.transform);
			physicalResult.GetComponent<Text> ().text = physicalExam.physical [physicalManeuver];
			physicalResult.transform.localScale = new Vector3 (1, 1, 1);
			physicalResult.GetComponent<Text> ().color = Color.yellow;
			TextGenerator tgPhysicalResults = physicalResult.GetComponent<Text> ().cachedTextGenerator;
			Canvas.ForceUpdateCanvases ();
			physicalResult.GetComponent<LayoutElement> ().minHeight = 30f * tgPhysicalResults.lineCount;
			// Check if good physical and change text color accordingly
			int physicalNumber = 0;
			foreach (string physicalFromList in diseaseChooser.disease_data.physicalManeuvers) {
				if (physicalFromList == physicalManeuver) {
					physicalNumber = Array.IndexOf (diseaseChooser.disease_data.physicalManeuvers, physicalManeuver);
				}
			}
			if (diseaseChooser.disease_data.goodPhysicalManeuvers.Contains (physicalNumber)) {
				physicalResult.GetComponent<Text> ().color = Color.green;
			} else if (diseaseChooser.disease_data.badPhysicalManeuvers.Contains (physicalNumber)) {
				physicalResult.GetComponent<Text> ().color = Color.red;
			}
		}
		// If no physical
		if (performanceTracker.physicalManeuversPerformed.Count == 0) {
			GameObject noPhysical = Instantiate (journalEntry, this.transform);
			noPhysical.GetComponent<Text> ().text = "No physical exam maneuvers performed";
			noPhysical.transform.localScale = new Vector3 (1, 1, 1);
		}

		// Labs header
		GameObject labsHeader = Instantiate (journalEntry, this.transform);
		labsHeader.GetComponent<Text> ().text = "LABS";
		labsHeader.transform.localScale = new Vector3 (1, 1, 1);
		labsHeader.GetComponent<Text> ().fontStyle = FontStyle.BoldAndItalic;
		// Labs population
		foreach (string labStudy in performanceTracker.labsOrdered) {
			GameObject labTest = Instantiate (journalEntry, this.transform);
			labTest.GetComponent<Text> ().text = labStudy;
			labTest.transform.localScale = new Vector3 (1, 1, 1);
			TextGenerator tgLabTest = labTest.GetComponent<Text> ().cachedTextGenerator;
			Canvas.ForceUpdateCanvases ();
			labTest.GetComponent<LayoutElement> ().minHeight = 30f * tgLabTest.lineCount;

			foreach (string labValueInStudy in labValues.labValuesInEachStudy[labStudy]) {
				GameObject labResult = Instantiate (journalEntry, this.transform);
				labResult.GetComponent<Text> ().text = labValueInStudy + ": " + labValues.labValues [labValueInStudy];
				labResult.transform.localScale = new Vector3 (1, 1, 1);
				labResult.GetComponent<Text> ().color = Color.yellow;
				TextGenerator tgLabResult = labResult.GetComponent<Text> ().cachedTextGenerator;
				Canvas.ForceUpdateCanvases ();
				labResult.GetComponent<LayoutElement> ().minHeight = 30f * tgLabResult.lineCount;
				// Check if good lab and change text color accordingly
				int labNumber = 0;
				foreach (string labFromList in diseaseChooser.disease_data.labStudies) {
					if (labFromList == labStudy) {
						labNumber = Array.IndexOf (diseaseChooser.disease_data.labStudies, labStudy);
					}
				}
				if (diseaseChooser.disease_data.goodLabs.Contains (labNumber)) {
					labResult.GetComponent<Text> ().color = Color.green;
				} else if (diseaseChooser.disease_data.badLabs.Contains (labNumber)) {
					labResult.GetComponent<Text> ().color = Color.red;
				}
			}
		}
		// If no labs
		if (performanceTracker.labsOrdered.Count == 0) {
			GameObject noLabs = Instantiate (journalEntry, this.transform);
			noLabs.GetComponent<Text> ().text = "No lab tests ordered";
			noLabs.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void CloseJournal () {
		journalOpen = false;
		foreach (Transform child in this.transform) {
			Destroy (child.gameObject);
		}
		scrollView.SetActive (false);
	}

}
