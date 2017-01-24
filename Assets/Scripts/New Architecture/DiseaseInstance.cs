using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseInstance {

	public string disease_name;
	public int age_min;
	public int age_max;
	public float male_probability;
	public float asian_probability;
	public float black_probability;
	public float hispanic_probability;
	public float white_probability;
	public enum Race {asian, black, hispanic, white};
	public enum Personality {personality1, personality2, personality3};

	public DiseaseInstance (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		Debug.Log ("Instance of disease " + diseaseName + " created.");
		this.disease_name = diseaseName;
		this.age_min = ageMin;
		this.age_max = ageMax;
		this.male_probability = maleProbability;
		this.asian_probability = asianProbability;
		this.black_probability = blackProbability;
		this.hispanic_probability = hispanicProbability;
		this.white_probability = whiteProbability;
	}

	public int RandomAge (int ageMin, int ageMax) {
		return Random.Range (ageMin, ageMax);
	}

	public bool RandomSex (float maleProbability){
		float randomSex = Random.value;
		if (maleProbability <= randomSex) {
			return true;
		} else {
			return false;
		}
	}

	public Race RandomRace (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability){
		float randomRace = Random.value;
		if (randomRace <= asianProbability) {
			return Race.asian;
		} else if (randomRace > asianProbability && randomRace <= (asianProbability + blackProbability)){
			return Race.black;
		} else if (randomRace > (asianProbability + blackProbability) && randomRace <= (asianProbability + blackProbability + hispanicProbability)) {
			return Race.hispanic;
		} else {
			return Race.white;
		}
	}

	public Personality RandomPersonality (int age, bool male, Race race){
		if (age <= 50) {
			return Personality.personality1;
		} else {
			return Personality.personality2;
		}
	}

}
