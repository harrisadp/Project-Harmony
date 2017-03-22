using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOptionButton : MonoBehaviour {

	public TextAsset textAsset;

	private DialogueManager dialogueManager;
	private GameManager gameManager;
	private DiseaseChooser diseaseChooser;
	private PerformanceTracker performanceTracker;
	private History history;
	private PhysicalExam physical;
	private LabValues labValues;
	private Images images;
	private bool sufficientEnergy = false;

	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
		gameManager = FindObjectOfType<GameManager> ();
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		performanceTracker = FindObjectOfType<PerformanceTracker> ();
		history = FindObjectOfType<History> ();
		physical = FindObjectOfType<PhysicalExam> ();
		labValues = FindObjectOfType<LabValues> ();
		images = FindObjectOfType<Images> ();
	}

	public void ButtonPushed () {		
		if (diseaseChooser.disease_data.male == true && physical.femaleOnlyPhysical.Contains(this.name)){
			FemaleOnlyPhysical();
			return;
		}
		else if (diseaseChooser.disease_data.male == true && labValues.labsFemaleOnly.Contains(this.name)){
			FemaleOnlyLab();
			return;
		}
		else if (performanceTracker.questionsAsked.Contains (this.name)) {
			QuestionAlreadyAsked();
			return;
		}
		else if (performanceTracker.physicalManeuversPerformed.Contains (this.name)) {
			PhysicalManeuverAlreadyPerformed();
			return;
		}
		else if (performanceTracker.labsOrdered.Contains (this.name)) {
			LabAlreadyOrdered();
			return;
		}
		else if (performanceTracker.imagesOrdered.Contains (this.name)) {
			ImageAlreadyOrdered();
			return;
		}
		else if (history.history.ContainsKey (this.name)) {
			performanceTracker.questionsAsked.Add (this.name);
			CheckIfGoodQuestion ();
		}
		else if (physical.physical.ContainsKey (this.name)) {
			performanceTracker.physicalManeuversPerformed.Add (this.name);
			CheckIfGoodPhysical ();
		}
		else if (labValues.labStudies.Contains (this.name)) {
			CheckIfSufficientEnergy ();
			if (sufficientEnergy) {
				performanceTracker.energyValue -= 2;
				performanceTracker.RemoveEnergy (2);
				performanceTracker.labsOrdered.Add (this.name);
				CheckIfGoodLab ();
			} else {
				InsufficientEnergy ();
				return;
			}
		}
		else if (labValues.labValuesBinary.ContainsKey (this.name)) {
			CheckIfSufficientEnergy ();
			if (sufficientEnergy) {
				performanceTracker.energyValue -= 2;
				performanceTracker.RemoveEnergy (2);
				performanceTracker.labsOrdered.Add (this.name);
				CheckIfGoodLabBinary ();
			} else {
				InsufficientEnergy ();
				return;
			}
		}
		else if (images.imagingStudies.Contains (this.name)) {
			CheckIfSufficientEnergy ();
			if (sufficientEnergy) {
				performanceTracker.energyValue -= 3;
				performanceTracker.RemoveEnergy (3);
				performanceTracker.imagesOrdered.Add (this.name);
				CheckIfGoodImage ();
				performanceTracker.UpdateScore ();
				Imaging ();
			} else {
				InsufficientEnergy ();
				return;
			}
		}
		else {return;}
		PlayDialogue ();
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
					gameManager.Reset ();
					return;
				} else if (line.Contains (this.name) && physical.physical.ContainsKey (this.name)) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 2);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				} else if (line.Contains (this.name) && labValues.labStudies.Contains (this.name)) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 3);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				} else if (line.Contains (this.name) && labValues.labValuesBinary.ContainsKey (this.name)) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 3);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				} else if (line.Contains (this.name)) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 3);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				}
			}
		}
	}

	private void CheckIfSufficientEnergy (){
		if (labValues.labStudies.Contains (this.name) && performanceTracker.energyValue >= 2) {
			sufficientEnergy = true;
		} else if (labValues.labValuesBinary.ContainsKey (this.name) && performanceTracker.energyValue >= 2) {
			sufficientEnergy = true;
		} else if (images.imagingStudies.Contains (this.name) && performanceTracker.energyValue >= 3) {
			sufficientEnergy = true;
		} else {
			sufficientEnergy = false;
		}
	}

	private void InsufficientEnergy () {
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Insufficient energy")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
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
			performanceTracker.PositiveAnimation ();
			if (performanceTracker.energyValue < performanceTracker.maxEnergyValue) {
				performanceTracker.energyValue += 1;
				performanceTracker.AddEnergy();
			}
			performanceTracker.UpdateScore ();
		} else if (diseaseChooser.disease_data.badQuestions.Contains (questionNumber)){
			performanceTracker.score -= 100;
			performanceTracker.NegativeAnimation ();
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
			performanceTracker.PositiveAnimation ();
			if (performanceTracker.energyValue < performanceTracker.maxEnergyValue) {
				performanceTracker.energyValue += 1;
				performanceTracker.AddEnergy();
			}
			performanceTracker.UpdateScore ();
		} else if (diseaseChooser.disease_data.badPhysicalManeuvers.Contains (physicalNumber)){
			performanceTracker.score -= 100;
			performanceTracker.NegativeAnimation ();
			performanceTracker.UpdateScore ();
		}
	}

	private void CheckIfGoodLab () {
		int labNumber = 0;
		foreach (string labStudy in labValues.labStudies) {
			if (labStudy == this.name) {
				labNumber = labValues.labStudies.IndexOf (labStudy);
			}
		}
		if (diseaseChooser.disease_data.goodLabs.Contains (labNumber)) {
			performanceTracker.score += 100;
			performanceTracker.PositiveAnimation ();
			performanceTracker.UpdateScore ();
		} else if (diseaseChooser.disease_data.badLabs.Contains (labNumber)) {
			performanceTracker.score -= 100;
			performanceTracker.NegativeAnimation ();
			performanceTracker.UpdateScore ();
		} else {
			performanceTracker.UpdateScore ();
		}
	}

	private void CheckIfGoodLabBinary () {
		int labNumber = 0;
		foreach (string labStudy in labValues.labStudiesBinary) {
			if (labStudy == this.name) {
				labNumber = labValues.labStudiesBinary.IndexOf (labStudy);
			}
		}
		if (diseaseChooser.disease_data.goodLabs.Contains (labNumber)) {
			performanceTracker.score += 100;
			performanceTracker.PositiveAnimation ();
			performanceTracker.UpdateScore ();
		} else if (diseaseChooser.disease_data.badLabs.Contains (labNumber)) {
			performanceTracker.score -= 100;
			performanceTracker.NegativeAnimation ();
			performanceTracker.UpdateScore ();
		} else {
			performanceTracker.UpdateScore ();
		}
	}

	private void CheckIfGoodImage() {
		int imageNumber = 0;
		foreach (string image in images.imagingStudies) {
			if (image == this.name) {
				imageNumber = images.imagingStudies.IndexOf (image);
			}
		}
		if (diseaseChooser.disease_data.goodImages.Contains (imageNumber)) {
			performanceTracker.score += 100;
			performanceTracker.PositiveAnimation ();
			performanceTracker.UpdateScore ();
		} else if (diseaseChooser.disease_data.badImages.Contains (imageNumber)) {
			performanceTracker.score -= 100;
			performanceTracker.NegativeAnimation ();
			performanceTracker.UpdateScore ();
		} else {
			performanceTracker.UpdateScore ();
		}
	}

	private void Imaging () {
		int imageNumber = images.imagingStudies.IndexOf (this.name);
		gameManager.displayImage = true;
		if (imageNumber == 0) {
			gameManager.imageToDisplay = images.xrayChests[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 1) {
			gameManager.imageToDisplay = images.xrayAbdomens[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 2) {
			gameManager.imageToDisplay = images.xraySpines[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 3) {
			gameManager.imageToDisplay = images.ctHeads[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 4) {
			gameManager.imageToDisplay = images.ctChests[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 5) {
			gameManager.imageToDisplay = images.ctAbdomens[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 6) {
			gameManager.imageToDisplay = images.mriBrains[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 7) {
			gameManager.imageToDisplay = images.ultrasoundAbdomens[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 8) {
			gameManager.imageToDisplay = images.ultrasoundPelvis[diseaseChooser.disease_data.imagingStudies[0]];
			gameManager.citation.text = images.ultrasoundPelvisCitations[diseaseChooser.disease_data.imagingStudies[0]];
		}
	}

	private void FemaleOnlyPhysical () {
		gameManager.turnCount --;
		performanceTracker.inappropriateFemaleExams ++;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (performanceTracker.inappropriateFemaleExams < 3 && line.Contains ("Female only physical")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				} else if (performanceTracker.inappropriateFemaleExams >= 3 && line.Contains ("Female only physical repeated")) {
					performanceTracker.score -= 100;
					performanceTracker.NegativeAnimation ();
					performanceTracker.UpdateScore ();
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
				}
			}
		}
	}

	private void FemaleOnlyLab () {
		gameManager.turnCount --;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Female only lab")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				}
			}
		}
	}

	private void QuestionAlreadyAsked () {
		gameManager.turnCount --;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Question already asked")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				}
			}
		}
	}

	private void PhysicalManeuverAlreadyPerformed () {
		gameManager.turnCount --;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Physical exam maneuver already performed")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				}
			}
		}
	}

	private void LabAlreadyOrdered () {
		gameManager.turnCount --;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Lab already ordered")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				}
			}
		}
	}

	private void ImageAlreadyOrdered () {
		gameManager.turnCount --;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("Image already ordered")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
					gameManager.Reset ();
					return;
				}
			}
		}
	}
}
