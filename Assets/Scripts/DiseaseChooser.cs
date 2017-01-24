using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class DiseaseChooser : MonoBehaviour {

	public enum DiseaseID {disease1, disease2, disease3};
	private DiseaseStruct diseaseStruct;
	private int diseaseChosen;
	private Person disease_data;

	// Use this for initialization
	void Start () {
		diseaseStruct = RunOnStart.global_disease_list;
		for (int disease_index = 0; disease_index < 3; disease_index++) {
			diseaseStruct.OutputData (disease_index);
		}
		diseaseChosen = (int)(DiseaseID)Random.Range (0, 3);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);
		int age = disease_data.age_gen ();
		Debug.Log (age);

		// since all data should exist with the disease_data you just pulled, you only need to call the methods for that data. Don't need to worry about passing any other information.
		// LOTS OF METHODS GO HERE

	}

}
