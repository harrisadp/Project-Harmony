using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class DiseaseChooser : MonoBehaviour {

	//Name collision. I don't know how c# would handle enum and class of same name
	//Try DiseaseId for enum name
	public enum DiseaseId {disease1, disease2, disease3};
	private DiseaseId diseaseChosen;
	private Disease disease_data;

	// Use this for initialization
	void Start () {
		//I would pass the identifier you received into some larger struct that handles the actual data.
		diseaseChosen = (DiseaseId)Random.Range (0, 3);
		disease_data = BigBadDiseaseStruct.GetDiseaseFromList(diseaseChosen); //Using the class name of BigBadDiseaseStruct, but should actually be the name of the variable the constructor was assigned to

		//since all data should exist with the disease_data you just pulled, you only need to call the methods for that data. Don't need to worry about passing any other information.
		int age = disease_data.AgeGenerator ();
		bool male = disease_data.SexGenerator ();
		int race = disease_data.RaceGenerator ();
		disease_data.PersonalityGenerator (age, male, race);
		disease_data.OverwriteHistory ();

	}

}
