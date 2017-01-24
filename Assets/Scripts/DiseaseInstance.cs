using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseInstance{

	// Disease ID
	public string disease_name;

	// Demographics
	public int age_min;
	public int age_max;
	public float male_probability;
	public float asian_probability;
	public float black_probability;
	public float hispanic_probability;
	public float white_probability;
	public enum Race {asian, black, hispanic, white};
	public enum Personality {personalityA, personalityB};

	// Questions
	public string[] questions = new string[3] {"Intro", "When were you last completely well", "When did the pain first start"};

	// Answers
	public string[,] answers = new string[3,2];

	// Physical Exam Maneuvers
	public string[] physicalExamManeuvers = new string[3] {"HEENT", "Card", "Resp"};

	// Lab Keys
	public string[] labKeys = new string[3] {"WBC", "HGB", "PLT"};

	// Performance Tracking
	public List<int> goodQuestions = new List<int>();

	public DiseaseInstance (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability, string introA, string introB, string question1A, string question1B, string question2A, string question2B, int[] goodQuestionIDs) {
		Debug.Log ("Instance of disease " + diseaseName + " created.");
		this.disease_name = diseaseName;
		this.age_min = ageMin;
		this.age_max = ageMax;
		this.male_probability = maleProbability;
		this.asian_probability = asianProbability;
		this.black_probability = blackProbability;
		this.hispanic_probability = hispanicProbability;
		this.white_probability = whiteProbability;
		this.answers [0, 0] = introA;
		this.answers [0, 1] = introB;
		this.answers [1, 0] = question1A;
		this.answers [1, 1] = question1B;
		this.answers [2, 0] = question2A;
		this.answers [2, 1] = question2B;
		foreach (int i in goodQuestionIDs) {
			goodQuestions.Add (i);
		}
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
			return Personality.personalityA;
		} else {
			return Personality.personalityB;
		}
	}

	public void OverwriteHistory (History history, string historyKey, string historyValue){
		history.history [historyKey] = historyValue;
	}

}
