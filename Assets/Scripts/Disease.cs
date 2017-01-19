using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Disease doesn't need to be a MonoBehaviour. Let DiseaseChooser be the behaviour. Any use of the disease script should be
//initiated by DiseaseChooser, not by the Unity Engine

//you will likely need to add a Namespace to provide visibility to the DiseaseChooser script
public class Disease {

	//DiseaseChooser should include disease not the other way around
	//private DiseaseChooser diseaseChooser;
	private enum Race {asian, black, hispanic, white};
	private enum Personality {personality1, personality2, personality3};

	//New copies of these variables are created each time you call the constructor
	private string disease_name;
	private int age_min;
	private int age_max;
	private float sex_probability;
	private float[] race_probability;
	private Personality individual;

	//Start function shouldn't be necessary if disease class acts as an object.
	//All initialization should occur in the constructor.

	//I believe Start functions are hooks for the Unity Engine
/*	void Start () {
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		new Disease (diseaseChooser.diseaseChosen.ToString());
	}
*/
	//Return type of a constructor is the class that the constructor is for.
	//Common practice to only set essential values in the constructor
	public Disease (string diseaseName, int age_min, int age_max, float sex_probability, float[] race_probability) {
		Debug.Log ("Disease constructor run");
		Debug.Log ("Disease name is " + diseaseName);

		//'this' refers to the object being operated on
		this.disease_name = diseaseName;
		this.age_min = age_min;
		this.age_max = age_max;
		this.sex_probability = sex_probability;
		this.race_probability = race_probability;
		/*
		int age = AgeGenerator(20,60);
		bool male = SexGenerator (0.5f);
		Race race = RaceGenerator (0.1f, 0.1f, 0.3f, 0.5f);
		Personality personality = PersonalityGenerator (age, male, race);
		*/
	}

	//Make the generators public
	//Also, have them use class internals
	public int AgeGenerator (){
		int age = Random.Range (min_age, max_age);
		return age;
	}

	public bool SexGenerator (){
		bool male;
		float randomSex = Random.value;
		if (randomSex <= sex_probability) {male = true;}
		else {male = false;}
		return male;
	}

	//Not quite there yet with race
	public Race RaceGenerator () {
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

	//This would probably assign a personality to the "individual" class variable in the same way that DiseaseChooser assigned a value to disease_data
	public Personality PersonalityGenerator (int age, bool male, Race race) {
		Personality personality = Personality.personality1;
		if (age <= 20 && age > 59 && male == true && race == Race.white) {
			personality = Personality.personality1;
		}
		return personality;
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
