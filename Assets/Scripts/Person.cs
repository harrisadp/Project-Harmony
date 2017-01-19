using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

	public enum Race {asian, black, hispanic, white};
	public enum Personality {personality1, personality2, personality3};

	public string disease_name;
	public int age;
	public bool male;
	public Race race;
	public Personality personality;

	public Person (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		Debug.Log ("Disease constructor run");
		this.disease_name = diseaseName;
		Debug.Log (disease_name);
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
		Debug.Log (personality);
	}

}
