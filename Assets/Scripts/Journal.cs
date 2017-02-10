using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour {

	public GameObject scrollView;
	public GameObject journalEntry;
	public GameObject journalEntryImage;
	public PerformanceTracker performanceTracker;

	private DiseaseChooser diseaseChooser;
	private History history;
	private PhysicalExam physicalExam;
	private LabValues labValues;
	private bool journalOpen = false;

	// Use this for initialization
	void Start () {
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		history = FindObjectOfType<History> ();
		physicalExam = FindObjectOfType<PhysicalExam> ();
		labValues = FindObjectOfType<LabValues> ();
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
		foreach (Transform child in this.transform) {Destroy (child.gameObject);}
		// Journal header
		GameObject title = Instantiate (journalEntry, this.transform);
		title.GetComponent<Text> ().text = "JOURNAL";
		title.transform.localScale = new Vector3 (1, 1, 1);
		title.GetComponent<Text> ().alignment = TextAnchor.UpperCenter;
		JournalHistory ();
		JournalPhysical ();
		JournalLabs ();
		JournalImaging ();
	}

	public void CloseJournal () {
		journalOpen = false;
		foreach (Transform child in this.transform) {
			Destroy (child.gameObject);
		}
		scrollView.SetActive (false);
	}

	private void JournalHistory () {
		// History header
		GameObject historyHeader = Instantiate (journalEntry, this.transform);
		historyHeader.GetComponent<Text> ().text = "History";
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
			if (diseaseChooser.disease_data.goodQuestions.Contains (Array.IndexOf (diseaseChooser.disease_data.questions, question))) {
				answerText.GetComponent<Text> ().color = Color.green;
			} else if (diseaseChooser.disease_data.badQuestions.Contains (Array.IndexOf (diseaseChooser.disease_data.questions, question))) {
				answerText.GetComponent<Text> ().color = Color.red;
			}
		}
		// If no history
		if (performanceTracker.questionsAsked.Count == 0) {
			GameObject noHistory = Instantiate (journalEntry, this.transform);
			noHistory.GetComponent<Text> ().text = "No history obtained";
			noHistory.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	private void JournalPhysical () {
		// Physical header
		GameObject physicalHeader = Instantiate (journalEntry, this.transform);
		physicalHeader.GetComponent<Text> ().text = "Physical";
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
			// Check if good physical exam maneuver and change text color accordingly
			if (diseaseChooser.disease_data.goodPhysicalManeuvers.Contains (Array.IndexOf (diseaseChooser.disease_data.physicalManeuvers, physicalManeuver))) {
				physicalResult.GetComponent<Text> ().color = Color.green;
			} else if (diseaseChooser.disease_data.badPhysicalManeuvers.Contains (Array.IndexOf (diseaseChooser.disease_data.physicalManeuvers, physicalManeuver))) {
				physicalResult.GetComponent<Text> ().color = Color.red;
			}
		}
		// If no physical
		if (performanceTracker.physicalManeuversPerformed.Count == 0) {
			GameObject noPhysical = Instantiate (journalEntry, this.transform);
			noPhysical.GetComponent<Text> ().text = "No physical exam maneuvers performed";
			noPhysical.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	void JournalLabs () {
		// Labs header
		GameObject labsHeader = Instantiate (journalEntry, this.transform);
		labsHeader.GetComponent<Text> ().text = "Labs";
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
			foreach (string labValueInStudy in labValues.labValuesInEachStudy [labStudy]) {
				GameObject labResult = Instantiate (journalEntry, this.transform);
				labResult.GetComponent<Text> ().text = labValueInStudy + ": " + labValues.labValues [labValueInStudy];
				labResult.transform.localScale = new Vector3 (1, 1, 1);
				labResult.GetComponent<Text> ().color = Color.yellow;
				// Check if good lab and change text color accordingly
				if (diseaseChooser.disease_data.goodLabs.Contains (Array.IndexOf (diseaseChooser.disease_data.labStudies, labStudy))) {
					labResult.GetComponent<Text> ().color = Color.green;
				} else if (diseaseChooser.disease_data.badLabs.Contains (Array.IndexOf (diseaseChooser.disease_data.labStudies, labStudy))) {
					labResult.GetComponent<Text> ().color = Color.red;
				}
				TextGenerator tgLabResult = labResult.GetComponent<Text> ().cachedTextGenerator;
				Canvas.ForceUpdateCanvases ();
				labResult.GetComponent<LayoutElement> ().minHeight = 30f * tgLabResult.lineCount;
			}
		}
		// If no labs
		if (performanceTracker.labsOrdered.Count == 0) {
			GameObject noLabs = Instantiate (journalEntry, this.transform);
			noLabs.GetComponent<Text> ().text = "No lab tests ordered";
			noLabs.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	private void JournalImaging () {
		// Imaging header
		GameObject labsHeader = Instantiate (journalEntry, this.transform);
		labsHeader.GetComponent<Text> ().text = "Imaging";
		labsHeader.transform.localScale = new Vector3 (1, 1, 1);
		labsHeader.GetComponent<Text> ().fontStyle = FontStyle.BoldAndItalic;
		// Imaging population
		foreach (string image in performanceTracker.imagesOrdered) {
			GameObject imageText = Instantiate (journalEntry, this.transform);
			imageText.GetComponent<Text> ().text = image;
			imageText.transform.localScale = new Vector3 (1, 1, 1);
			TextGenerator tgImages = imageText.GetComponent<Text> ().cachedTextGenerator;
			Canvas.ForceUpdateCanvases ();
			imageText.GetComponent<LayoutElement> ().minHeight = 30f * tgImages.lineCount;
			GameObject imageButton = Instantiate (journalEntryImage, this.transform);
			imageButton.name = image;
			imageButton.transform.localScale = new Vector3 (1, 1, 1);
		}
		// If no imaging
		if (performanceTracker.imagesOrdered.Count == 0) {
			GameObject noImages = Instantiate (journalEntry, this.transform);
			noImages.GetComponent<Text> ().text = "No imaging studies ordered";
			noImages.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

}
