using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class DiseaseChooser : MonoBehaviour {

	public enum DiseaseID {disease1, disease2, disease3};
	public DiseaseStruct diseaseStruct;
	public int diseaseChosen;
	public DiseaseInstance disease_data;
	private History history;
	private Text ageText, sexText;

	// Use this for initialization
	void Start () {
		diseaseStruct = RunOnStart.global_disease_list;
		history = FindObjectOfType<History> ();
		ageText = GameObject.Find ("Age Text").GetComponent<Text> ();
		sexText = GameObject.Find ("Sex Text").GetComponent<Text> ();
	}

	public void ChooseDisease() {
		diseaseChosen = (int)(DiseaseID)UnityEngine.Random.Range (0, 3);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);
		int age = disease_data.RandomAge (disease_data.age_min, disease_data.age_max);
		bool male = disease_data.RandomSex (disease_data.male_probability);
		DiseaseInstance.Race race = disease_data.RandomRace (disease_data.asian_probability, disease_data.black_probability, disease_data.hispanic_probability, disease_data.white_probability);
		DiseaseInstance.Personality personality = disease_data.RandomPersonality (age, male, race);
		Debug.Log ("Disease chosen by DiseaseChooser is " + disease_data.disease_name);
		ageText.text = age.ToString ();
		if (male) {
			sexText.text = "Male";
		} else {
			sexText.text = "Female";
		}
		Debug.Log ("Race chosen by DiseaseChooser is " + race);
		Debug.Log ("Personality chosen by DiseaseChooser is " + personality);
		foreach (string question in disease_data.questions) {
			disease_data.OverwriteHistory (history, question, disease_data.answers [Array.IndexOf(disease_data.questions, question), (int)(personality)]);
//			if (disease_data.goodQuestions.Contains (Array.IndexOf(disease_data.questions, question))){
//				Debug.Log ("Question #" + Array.IndexOf(disease_data.questions, question) + " is a good one");
//			} else {
//				Debug.Log ("Question #" + Array.IndexOf(disease_data.questions, question) + " is a bad one");
//			}
		}
	}

}
