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
		diseaseStruct = FindObjectOfType<DiseaseStruct> ();
		diseaseChosen = (int)(DiseaseID)Random.Range (0, 3);
		disease_data = diseaseStruct.GetDiseaseFromList(diseaseChosen);

		// since all data should exist with the disease_data you just pulled, you only need to call the methods for that data. Don't need to worry about passing any other information.
		// LOTS OF METHODS GO HERE

	}

}
