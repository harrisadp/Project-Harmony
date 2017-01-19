using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseStruct : ScriptableObject {
		
	public Person[] disease_list;

	public DiseaseStruct (int size) {
		disease_list = new Person[size];
		disease_list[0] = new Person("Asthma", 5, 10, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
		disease_list[1] = new Person("Bronchitis", 20, 50, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
		disease_list[2] = new Person("COPD", 60, 90, 0.7f, 0.25f, 0.25f, 0.25f, 0.25f);
		disease_list[3] = new Person("Myocardial Infarction", 60, 90, 0.9f, 0.1f, 0.4f, 0.3f, 0.2f);
		disease_list[4] = new Person("Pneumonia", 20, 90, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
	}

	public Person GetDiseaseFromList(int index) {
		Debug.Log (disease_list [index]);
		new DiseaseStruct (index);
		return disease_list [index];
	}
}
