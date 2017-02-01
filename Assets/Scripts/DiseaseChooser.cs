﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;
using AssemblyCSharp;

public class DiseaseChooser : MonoBehaviour {

	public DiseaseStruct diseaseStruct;
	public DiseaseInstance disease_data;
	public enum DiseaseID {disease1, disease2, disease3};
	public int diseaseChosen;
	public Sprite[] sprites;
	public AnimatorController[] animatorControllers;

	private History history;
	private PhysicalExam physical;
	private LabValues labValues;
	private Text ageText, sexText;
	private GameObject patient;

	// Use this for initialization
	void Awake () {
		diseaseStruct = RunOnStart.global_disease_list;
		history = FindObjectOfType<History> ();
		physical = FindObjectOfType<PhysicalExam> ();
		labValues = FindObjectOfType<LabValues> ();
		ageText = GameObject.Find ("Age Text").GetComponent<Text> ();
		sexText = GameObject.Find ("Sex Text").GetComponent<Text> ();
		patient = GameObject.Find ("Patient");
		ChooseDisease ();
	}

	public void ChooseDisease() {
		diseaseChosen = (int)(DiseaseID)UnityEngine.Random.Range (0, 3);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);
		Debug.Log ("Disease chosen by DiseaseChooser is " + disease_data.disease_name);
		Debug.Log ("Race chosen by DiseaseChooser is " + disease_data.race);
		Debug.Log ("Personality chosen by DiseaseChooser is " + disease_data.personality);
		SpriteRenderer[] patientSpriteRenderers = patient.GetComponentsInChildren<SpriteRenderer> ();
		Animator[] patientAnimators = patient.GetComponentsInChildren<Animator> ();
		foreach (SpriteRenderer spriteRenderer in patientSpriteRenderers) {
			if (disease_data.personality == DiseaseInstance.Personality.personalityA) {
				spriteRenderer.sprite = sprites [1];
			} else if (disease_data.personality == DiseaseInstance.Personality.personalityB) {
				spriteRenderer.sprite = sprites [0];
			}
		}
		foreach (Animator animatorController in patientAnimators) {
			if (disease_data.personality == DiseaseInstance.Personality.personalityA) {
				animatorController.runtimeAnimatorController = animatorControllers [1];
			} else if (disease_data.personality == DiseaseInstance.Personality.personalityB) {
				animatorController.runtimeAnimatorController = animatorControllers [0];
			}
		}
		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the history object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string question in disease_data.questions) {
			disease_data.OverwriteHistory (history, question, disease_data.answers [Array.IndexOf(disease_data.questions, question), (int)(disease_data.personality)]);
		}
		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the history object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string physicalManeuver in disease_data.physicalManeuvers) {
			disease_data.OverwritePhysical (physical, physicalManeuver, disease_data.physicalResults [Array.IndexOf(disease_data.physicalManeuvers, physicalManeuver)]);
		}
		// The following is part of this DiseaseChooser class and not the DiseaseInstance class because I can't reference the history object without using MonoBehaviour (at least with my limited knowledge)
		foreach (string labStudy in disease_data.labStudies) {
			disease_data.OverwriteLabs (labValues, labStudy, disease_data.labResults [Array.IndexOf(disease_data.labStudies, labStudy)]);
		}
		UpdateDisplays ();
	}

	public void UpdateDisplays () {
		ageText.text = disease_data.age.ToString ();
		if (disease_data.male) {sexText.text = "Male";}
		else {sexText.text = "Female";}
	}

}