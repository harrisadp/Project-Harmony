using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	private DefaultVitals vitals;
	private DefaultHistory history;
	private DefaultPhysicalExam physical;
	private DefaultLabValues labs;

	// Use this for initialization
	void Start () {
		vitals = GetComponent<DefaultVitals> ();
		history = GetComponent<DefaultHistory> ();
		physical = GetComponent<DefaultPhysicalExam> ();
		labs = GetComponent<DefaultLabValues> ();
		vitals.vitals ["HR"] = Mathf.Round(Random.Range(120,150));
		history.history ["HPI"] = "I was just sitting on the couch when suddenly my chest started squeezing!";
		physical.physical ["CARD"] = "There is notable tachycardia.";
		labs.labValues ["WBC"] = Mathf.Round(10*(Random.Range (15.5f, 20.5f)))/10;
		Debug.Log ("Disease changed WBC value to " + labs.labValues ["WBC"]);
	}
	
	// Update is called once per frame
	void Update () {

	}
		
}
