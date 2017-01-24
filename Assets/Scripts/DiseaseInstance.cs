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
	public string[] questions = new string[16] {"Intro", "When were you last completely well", "When did the pain first start", "How would you describe your pain", "Where is the pain located", "Does the pain move anywhere", "How did the pain first start", "How severe is your pain", "Have you ever had a similar pain in the past", "Does anything make the pain better or worse", "What has been the impact of this problem on your life", "Who else have you seen about this problem", "What treatments have been recommended for this problem", "What medications, including non-prescription medication, have you used for this problem", "Have you had any tests related to this problem", "Is there anything else bothering you"};

	// Answers
	public string[,] answers = new string[16,2];

	// Performance Tracking
	public List<int> goodQuestions = new List<int>();

	public DiseaseInstance (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability, string introA, string introB, string question1A, string question1B, string question2A, string question2B, string question3A, string question3B, string question4A, string question4B, string question5A, string question5B, string question6A, string question6B, string question7A, string question7B, string question8A, string question8B, string question9A, string question9B, string question10A, string question10B, string question11A, string question11B, string question12A, string question12B, string question13A, string question13B, string question14A, string question14B, string question15A, string question15B, int[] goodQuestionIDs) {
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
		this.answers [3, 0] = question3A;
		this.answers [3, 1] = question3B;
		this.answers [4, 0] = question4A;
		this.answers [4, 1] = question4B;
		this.answers [5, 0] = question5A;
		this.answers [5, 1] = question5B;
		this.answers [6, 0] = question6A;
		this.answers [6, 1] = question6B;
		this.answers [7, 0] = question7A;
		this.answers [7, 1] = question7B;
		this.answers [8, 0] = question8A;
		this.answers [8, 1] = question8B;
		this.answers [9, 0] = question9A;
		this.answers [9, 1] = question9B;
		this.answers [10, 0] = question10A;
		this.answers [10, 1] = question10B;
		this.answers [11, 0] = question11A;
		this.answers [11, 1] = question11B;
		this.answers [12, 0] = question12A;
		this.answers [12, 1] = question12B;
		this.answers [13, 0] = question13A;
		this.answers [13, 1] = question13B;
		this.answers [14, 0] = question14A;
		this.answers [14, 1] = question14B;
		this.answers [15, 0] = question15A;
		this.answers [15, 1] = question15B;
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
