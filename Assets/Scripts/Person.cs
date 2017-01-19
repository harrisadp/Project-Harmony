using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person {

	private enum Race {asian, black, hispanic, white};
	private enum Personality {personality1, personality2, personality3};

	private string disease_name;
	private int age_min;
	private int age_max;
	private float male_probability;
	private float asian_probability;
	private float black_probability;
	private float hispanic_probability;
	private float white_probability;
	private Personality personality;

	public Person (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		Debug.Log ("Disease constructor run");
		Debug.Log ("Disease name is " + diseaseName);
		this.disease_name = diseaseName;
		this.age_min = ageMin;
		this.age_max = ageMax;
		this.male_probability = maleProbability;
		this.asian_probability = asianProbability;
		this.black_probability = blackProbability;
		this.hispanic_probability = hispanicProbability;
		this.white_probability = whiteProbability;
		Debug.Log (age_min);
		Debug.Log (age_max);
		Debug.Log (male_probability);
		Debug.Log (asianProbability);
		Debug.Log (black_probability);
		Debug.Log (hispanic_probability);
		Debug.Log (white_probability);
	}

}
