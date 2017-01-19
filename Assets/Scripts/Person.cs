using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person {

	public enum Race {asian, black, hispanic, white};
	public enum Personality {personality1, personality2, personality3};

	private string disease_name;
	private int age;
	private bool male;
	private Race race;
	private Personality personality;

	public Person (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		Debug.Log ("Disease constructor run");
		Debug.Log ("Disease name is " + diseaseName);
		this.disease_name = diseaseName;
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
		Debug.Log (personality);
	}

}
