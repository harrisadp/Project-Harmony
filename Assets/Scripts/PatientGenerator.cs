using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour {

	public Sprite patientSprite;
	private DefaultDemographics demographicsScript;
	private DefaultDialogue dialogueScript;
	private DefaultVitals vitalsScript;
	private DefaultHistory historyScript;
	private DefaultPhysicalExam physicalExamScript;
	private DefaultLabValues labsScript;
	private Disease disease;

	// Use this for initialization
	void Start () {
		demographicsScript = gameObject.AddComponent <DefaultDemographics> ();
		dialogueScript = gameObject.AddComponent <DefaultDialogue> ();
		vitalsScript = gameObject.AddComponent <DefaultVitals> ();
		historyScript = gameObject.AddComponent <DefaultHistory> ();
		physicalExamScript = gameObject.AddComponent <DefaultPhysicalExam> ();
		labsScript = gameObject.AddComponent <DefaultLabValues> ();
		disease = gameObject.AddComponent<Disease> ();
		gameObject.AddComponent<SpriteRenderer> ();
		GetComponent<SpriteRenderer> ().sprite = patientSprite;
		GetComponent<SpriteRenderer> ().flipX = true;
		transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
		Test ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Test () {
		Debug.Log ("Patient generator generated " + demographicsScript);
		Debug.Log ("Patient generator generated " + dialogueScript);
		Debug.Log ("Patient generator generated " + vitalsScript);
		Debug.Log ("Patient generator generated " + historyScript);
		Debug.Log ("Patient generator generated " + physicalExamScript);
		Debug.Log ("Patient generator generated " + labsScript);
		Debug.Log ("Patient generator generated " + disease.diseaseName);
	}

}
