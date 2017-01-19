using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	public DiseaseList diseaseList;

	private int age;

	public void Test(){
		RandomAge (diseaseList.diseaseList [0].ageMin, diseaseList.diseaseList [0].ageMax);
		Debug.Log (diseaseList.diseaseList [0].diseaseName);
		Debug.Log (age);
	}

	int RandomAge(int ageMin, int ageMax){
		return age = Random.Range (ageMin, ageMax);
	}

}
