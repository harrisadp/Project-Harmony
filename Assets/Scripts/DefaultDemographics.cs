using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDemographics : MonoBehaviour {

	public int age;
	public bool male;
	public enum Race {white, black, asian, hispanic};
	public Race patientRace;

	void Awake () {
		age = Random.Range (18, 85);
		male = true;
		patientRace = (Race)Random.Range (0, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
