using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

	public DiseaseList diseaseList;

	private enum Race {asian, black, hispanic, white};
	private enum Personality {personality1, personality2, personality3, personality4, personality5, personality6};
	private int age;
	private bool male;
	private Race race;
	private Personality personality;
	private History history;

	void Start (){
		history = FindObjectOfType <History> ();
	}

	public void GeneratePerson(){
		int randomDisease = Random.Range (0, 6);
		RandomAge (diseaseList.diseaseList [randomDisease].ageMin, diseaseList.diseaseList [randomDisease].ageMax);
		RandomSex (diseaseList.diseaseList [randomDisease].maleProbability);
		RandomRace (diseaseList.diseaseList [randomDisease].asianProbability, diseaseList.diseaseList [randomDisease].blackProbability, diseaseList.diseaseList [randomDisease].hispanicProbability, diseaseList.diseaseList [randomDisease].whiteProbability);
		RandomPersonality ();
		OverwriteHistory (randomDisease, (int)personality);
		Debug.Log (diseaseList.diseaseList [randomDisease].diseaseName);
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
		Debug.Log (personality);
		Debug.Log (history.history ["Intro"]);
	}

	int RandomAge(int ageMin, int ageMax){
		return age = Random.Range (ageMin, ageMax);
	}

	bool RandomSex (float maleProbability){
		float randomSex = Random.value;
		if (randomSex <= maleProbability) {
			return male = true;
		} else {
			return male = false;
		}
	}

	Race RandomRace (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability){
		float randomRace = Random.value;
		if (randomRace <= asianProbability) {
			return race = Race.asian;
		} else if (randomRace > asianProbability && randomRace <= (asianProbability + blackProbability)){
			return race = Race.black;
		} else if (randomRace > (asianProbability + blackProbability) && randomRace <= (asianProbability + blackProbability + hispanicProbability)) {
			return race = Race.hispanic;
		} else {
			return race = Race.white;
		}
	}

	Personality RandomPersonality (){
		if (age <= 20 && male) {
			return personality = Personality.personality1;
		} else if (age <= 20 && !male) {
			return personality = Personality.personality2;
		} else if (age > 20 && age <= 60 && male) {
			return personality = Personality.personality3;
		} else if (age > 20 && age <= 60 && !male) {
			return personality = Personality.personality4;
		} else if (age > 60 && male) {
			return personality = Personality.personality5;
		} else if (age > 60 && !male) {
			return personality = Personality.personality6;
		} else {
			return personality = Personality.personality1;
		}
	}

	void OverwriteHistory (int disease, int personality){
		if (personality == 0) {
			history.history ["HPI"] = diseaseList.diseaseList [disease].introPersonality1;
		} else if (personality == 1) {
			history.history ["HPI"] = diseaseList.diseaseList [disease].introPersonality2;
		} else if (personality == 2) {
			history.history ["HPI"] = diseaseList.diseaseList [disease].introPersonality3;
		} else if (personality == 3) {
			history.history ["HPI"] = diseaseList.diseaseList [disease].introPersonality4;
		} else if (personality == 4) {
			history.history ["HPI"] = diseaseList.diseaseList [disease].introPersonality5;
		} else if (personality == 5) {
			history.history ["HPI"] = diseaseList.diseaseList [disease].introPersonality6;
		}
	}

}
