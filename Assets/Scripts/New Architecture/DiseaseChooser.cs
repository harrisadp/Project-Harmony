using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class DiseaseChooser : MonoBehaviour {

	public enum DiseaseID {disease1, disease2, disease3};
	private DiseaseStruct diseaseStruct;
	private int diseaseChosen;
	private DiseaseInstance disease_data;
	private History history;

	// Use this for initialization
	void Start () {
		diseaseStruct = RunOnStart.global_disease_list;
		history = FindObjectOfType<History> ();
//		for (int disease_index = 0; disease_index < 3; disease_index++) {
//			diseaseStruct.OutputData (disease_index);
//		}
	}

	public void ChooseDisease() {
		diseaseChosen = (int)(DiseaseID)UnityEngine.Random.Range (0, 3);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);
		int age = disease_data.RandomAge (disease_data.age_min, disease_data.age_max);
		bool male = disease_data.RandomSex (disease_data.male_probability);
		DiseaseInstance.Race race = disease_data.RandomRace (disease_data.asian_probability, disease_data.black_probability, disease_data.hispanic_probability, disease_data.white_probability);
		DiseaseInstance.Personality personality = disease_data.RandomPersonality (age, male, race);
		Debug.Log ("Disease chosen by DiseaseChooser is " + disease_data.disease_name);
		Debug.Log ("Age chosen by Disease Chooser is: " + age);
		Debug.Log ("This patient is male: " + male);
		Debug.Log ("Race chosen by DiseaseChooser is " + race);
		Debug.Log ("Personality chosen by DiseaseChooser is " + personality);
		foreach (string question in disease_data.questions) {
			disease_data.OverwriteHistory (history, question, disease_data.answers [Array.IndexOf(disease_data.questions, question), (int)(personality)]);
		}
		Debug.Log (history.history ["Intro"]);
		Debug.Log (history.history ["When were you last completely well"]);
		Debug.Log (history.history ["When did the pain first start"]);
	}

}
