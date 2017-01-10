using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

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
		dialogue.dialogue ["Intro"] = "Help! I'm dying!";
		dialogue.dialogue ["Response"] = "Don't worry! I'm on it!";
		vitals.vitals ["HR"] = Mathf.Round(Random.Range(120,150));
		history.history ["HPI"] = "I was just sitting on the couch when suddenly my chest started squeezing!";
		physical.physical ["CARD"] = "There is notable tachycardia.";
		labs.labValues ["WBC"] = Mathf.Round(10*(Random.Range (15.5f, 20.5f)))/10;
	}

}
