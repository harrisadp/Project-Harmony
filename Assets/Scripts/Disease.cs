using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	public string diseaseName;
	private DefaultDialogue dialogue;
	private DefaultVitals vitals;
	private DefaultHistory history;
	private DefaultPhysicalExam physical;
	private DefaultLabValues labs;

	void Awake () {
		dialogue = GetComponent<DefaultDialogue> ();
		vitals = GetComponent<DefaultVitals> ();
		history = GetComponent<DefaultHistory> ();
		physical = GetComponent<DefaultPhysicalExam> ();
		labs = GetComponent<DefaultLabValues> ();
		vitals.vitals ["HR"] = Mathf.Round(Random.Range(120,150));
		physical.physical ["CARD"] = "There is notable tachycardia.";
		labs.labValues ["WBC"] = Mathf.Round(10*(Random.Range (15.5f, 20.5f)))/10;
	}

}
