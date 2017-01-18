using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	private enum DiseaseList {disease1, disease2, disease3};
	private enum Race {asian, black, hispanic, white};
	private enum Personality {personality1, personality2, personality3};

	private Disease () {
		Debug.Log ("Disease constructor running");
		int age = AgeGenerator (20,60);
		bool male = SexGenerator (0.5f);
		Race race = RaceGenerator (0.1f, 0.1f, 0.3f, 0.5f);
		Personality personality = PersonalityGenerator (age, male, race);
		Debug.Log ("Personality chosen is: " + personality);
	}

	private int AgeGenerator (int minAge, int maxAge){
		int age = Random.Range (minAge, maxAge);
		return age;
	}

	private bool SexGenerator (float maleProbability){
		bool male;
		float randomSex = Random.value;
		if (randomSex <= maleProbability) {male = true;}
		else {male = false;}
		return male;
	}

	private Race RaceGenerator (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		Race race;
		float blackThreshold = asianProbability + blackProbability;
		float hispanicThreshold = asianProbability + blackProbability + hispanicProbability;
		float randomRace = Random.value;
		if (randomRace <= asianProbability) {race = Race.asian;}
		else if (randomRace > asianProbability && randomRace <= blackThreshold) {race = Race.black;}
		else if (randomRace > blackThreshold && randomRace <= hispanicThreshold) {race = Race.hispanic;}
		else {race = Race.white;}
		return race;
	}

	private Personality PersonalityGenerator (int age, bool male, Race race) {
		Personality personality = Personality.personality1;
		if (age <= 20 && age > 59 && male == true && race == Race.white) {
			personality = Personality.personality1;
		}
		return personality;
	}

//	Where do the diseases go?!

}
