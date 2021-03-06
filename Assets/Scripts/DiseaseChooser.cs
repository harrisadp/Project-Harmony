﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class DiseaseChooser : MonoBehaviour {

	public DiseaseStruct diseaseStruct;
	public DiseaseInstance disease_data;
	public enum DiseaseID {Asthma, Bronchitis, COPD, AnovulatoryCycle};
	public DiseaseID SelectDisease;
	public int diseaseChosen;
	public Sprite[] sprites;
	public Sprite[] headSprites;
	public RuntimeAnimatorController[] animatorControllers;
	public Sprite maleGenderSymbol;
	public Sprite femaleGenderSymbol;
	public GameObject runOnStart;

	private History history;
	private Vitals vitals;
	private PhysicalExam physical;
	private LabValues labValues;
	private Text ageText, BMIText;
	private Image genderSymbol;
	private GameObject patient;
	private RPGTalk rpgTalk;

	// Use this for initialization
	void Awake () {
		diseaseStruct = RunOnStart.global_disease_list;
		history = FindObjectOfType<History> ();
		vitals = FindObjectOfType<Vitals> ();
		physical = FindObjectOfType<PhysicalExam> ();
		labValues = FindObjectOfType<LabValues> ();
		ageText = GameObject.Find ("Age Text").GetComponent<Text> ();
		BMIText = GameObject.Find ("BMI Text").GetComponent<Text> ();
		genderSymbol = GameObject.Find ("Sex Icon").GetComponent<Image> ();
		patient = GameObject.Find ("Patient");
		rpgTalk = FindObjectOfType<RPGTalk> ();
		ChooseDisease ();
	}

	public void ChooseDisease() {
		diseaseChosen = (int)(SelectDisease);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);
		SpriteRenderer patientSpriteRenderer = patient.GetComponent<SpriteRenderer> ();
		Animator patientAnimator = patient.GetComponent<Animator> ();
		Debug.Log ("Disease chosen by DiseaseChooser is " + disease_data.disease_name);
		Debug.Log ("BMI is " + disease_data.bmi);
		Debug.Log ("Race chosen by DiseaseChooser is " + disease_data.race);
		Debug.Log ("Patient is male: " + disease_data.male);
		Debug.Log ("Personality chosen by DiseaseChooser is " + disease_data.personality);
		patientSpriteRenderer.sprite = sprites [(int)(disease_data.personality)];
		patientAnimator.runtimeAnimatorController = animatorControllers [(int)(disease_data.personality)];
		rpgTalk.photos [1].photo = headSprites [(int)(disease_data.personality)];

		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the history object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string question in disease_data.questions) {
			disease_data.OverwriteHistory (history, question, disease_data.answers [Array.IndexOf(disease_data.questions, question), (int)(disease_data.personality)]);
		}
		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the vitals object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string vitalSign in disease_data.vitalStrings) {
			if (vitalSign == "T") {disease_data.OverwriteVitals (vitals, vitalSign, disease_data.temperature);}
			else if (vitalSign == "HR") {disease_data.OverwriteVitals (vitals, vitalSign, disease_data.heartRate);}
			else if (vitalSign == "SBP") {disease_data.OverwriteVitals (vitals, vitalSign, disease_data.systolicBP);}
			else if (vitalSign == "DBP") {disease_data.OverwriteVitals (vitals, vitalSign, disease_data.diastolicBP);}
			else if (vitalSign == "RR") {disease_data.OverwriteVitals (vitals, vitalSign, disease_data.respiratoryRate);}
			else if (vitalSign == "SpO2") {disease_data.OverwriteVitals (vitals, vitalSign, disease_data.spO2);}
		}
		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the physical object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string physicalManeuver in disease_data.physicalManeuvers) {
			disease_data.OverwritePhysical (physical, physicalManeuver, disease_data.physicalResults [Array.IndexOf(disease_data.physicalManeuvers, physicalManeuver)]);
		}
		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the lab object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string labStudy in disease_data.labComponents) {
			disease_data.OverwriteLabs (labValues, labStudy, disease_data.labResults [Array.IndexOf(disease_data.labComponents, labStudy)]);
		}
		foreach (string labStudy in disease_data.labStudiesBinary) {
			disease_data.OverwriteLabsBinary (labValues, labStudy, disease_data.labResultsBinary [Array.IndexOf(disease_data.labStudiesBinary, labStudy)]);
		}
		UpdateDisplays ();
	}

	public void UpdateDisplays () {
		ageText.text = disease_data.age.ToString ();
		if (disease_data.male) {genderSymbol.sprite = maleGenderSymbol;}
		else {genderSymbol.sprite = femaleGenderSymbol;}
		BMIText.text = disease_data.bmi.ToString ();
		vitals.UpdateDisplay ();
	}

	public void HardReset () {
		Debug.Log ("Hard reset");
		Destroy (FindObjectOfType<RunOnStart> ().gameObject);
		Instantiate (runOnStart);
		diseaseStruct = RunOnStart.global_disease_list;
	}

}
