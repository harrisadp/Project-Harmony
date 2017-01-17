using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	public string diseaseName;
//	public Sprite white;
//	public Sprite black;
//	public Sprite asian;
//	public Sprite hispanic;

	public Sprite xray;
	public Sprite ct;
	public Sprite mri;
	public Sprite us;
	public Sprite pet;

	private DefaultDialogue dialogue;
	private DefaultDemographics demographics;
	private DefaultVitals vitals;
	private DefaultHistory history;
	private DefaultPhysicalExam physical;
	private DefaultLabValues labs;

	void Start () {
		dialogue = GetComponent<DefaultDialogue> ();
		demographics = GetComponent<DefaultDemographics> ();
		vitals = GetComponent<DefaultVitals> ();
		history = GetComponent<DefaultHistory> ();
		physical = GetComponent<DefaultPhysicalExam> ();
		labs = GetComponent<DefaultLabValues> ();
		Test ();
	}

	void Test (){
		diseaseName = "Pneumonia";
		Debug.Log (diseaseName);
		Debug.Log (dialogue.dialogue["Intro"]);
		Debug.Log (demographics.patientRace);
		Debug.Log (vitals.vitals["HR"]);
		Debug.Log (history.history["HPI"]);
		Debug.Log (physical.physical["CARD"]);
		Debug.Log (labs.labValues["WBC"]);
//		if (demographics.patientRace == DefaultDemographics.Race.asian) {
//			GetComponent<SpriteRenderer> ().sprite = asian;
//		} else if (demographics.patientRace == DefaultDemographics.Race.black) {
//			GetComponent<SpriteRenderer> ().sprite = black;
//		} else if (demographics.patientRace == DefaultDemographics.Race.hispanic) {
//			GetComponent<SpriteRenderer> ().sprite = hispanic;
//		} else if (demographics.patientRace == DefaultDemographics.Race.white) {
//			GetComponent<SpriteRenderer> ().sprite = white;
	}

}
