using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseChooser : MonoBehaviour {

	public enum DiseaseID {disease1, disease2, disease3, disease4, disease5};
	public DiseaseStruct diseaseStruct;
	public int diseaseChosen;
	public Person disease_data;

	public void ChooseDisease () {
		diseaseStruct = FindObjectOfType<DiseaseStruct> ();
		Debug.Log (diseaseStruct);
		diseaseChosen = (int)(DiseaseID)Random.Range (0, 5);
		Debug.Log (diseaseChosen);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);
		Debug.Log (disease_data);

		// since all data should exist with the disease_data you just pulled, you only need to call the methods for that data. Don't need to worry about passing any other information.
		// LOTS OF METHODS GO HERE

	}

}
