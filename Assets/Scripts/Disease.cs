using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	public enum DiseaseList {disease1, disease2, disease3};
	public enum Race {asian, black, hispanic, white};
	public enum Personality {personality1, personality2, personality3};

	public int age;
	public bool male;
	public Race race;

	// Use this for initialization
	void Start () {
		Disease disease1 = new Disease (1, true, Race.asian);
		Disease disease2 = new Disease (2, false, Race.black);
		Disease disease3 = new Disease (3, true, Race.hispanic);
		Disease disease4 = new Disease (4, false, Race.white);
	}

	public Disease (int randomAge, bool randomSex, Race randomRace) {
		Debug.Log ("Disease constructor running");
		age = randomAge;
		male = randomSex;
		race = randomRace;
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
	}

//	private int AgeGenerator (int minAge, int maxAge){
//		int age = Random.Range (minAge, maxAge);
//		return age;
//	}
//
//	private bool SexGenerator (float maleProbability){
//		bool male;
//		float randomSex = Random.value;
//		if (randomSex <= maleProbability) {male = true;}
//		else {male = false;}
//		return male;
//	}
//
//	private Race RaceGenerator (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
//		Race race;
//		float blackThreshold = asianProbability + blackProbability;
//		float hispanicThreshold = asianProbability + blackProbability + hispanicProbability;
//		float randomRace = Random.value;
//		if (randomRace <= asianProbability) {race = Race.asian;}
//		else if (randomRace > asianProbability && randomRace <= blackThreshold) {race = Race.black;}
//		else if (randomRace > blackThreshold && randomRace <= hispanicThreshold) {race = Race.hispanic;}
//		else {race = Race.white;}
//		return race;
//	}
//
//	private Personality PersonalityGenerator (int age, bool male, Race race) {
//		Personality personality = Personality.personality1;
//		if (age <= 20 && age > 59 && male == true && race == Race.white) {
//			personality = Personality.personality1;
//		}
//		return personality;
//	}
//
//	Where do the diseases go?!

}
