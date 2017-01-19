using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	public DiseaseList diseaseList;

	private enum Race {asian, black, hispanic, white};
	private int age;
	private bool male;
	private Race race;

	public void Test(){
		int randomDisease = Random.Range (0, 6);
		RandomAge (diseaseList.diseaseList [randomDisease].ageMin, diseaseList.diseaseList [randomDisease].ageMax);
		RandomSex (diseaseList.diseaseList [randomDisease].maleProbability);
		RandomRace (diseaseList.diseaseList [randomDisease].asianProbability, diseaseList.diseaseList [randomDisease].blackProbability, diseaseList.diseaseList [randomDisease].hispanicProbability, diseaseList.diseaseList [randomDisease].whiteProbability);
		Debug.Log (diseaseList.diseaseList [randomDisease].diseaseName);
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
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

}
