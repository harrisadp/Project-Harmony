using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour {

	public Sprite patientSprite;
	private Demographics demographicsScript;
	private Dialogue dialogueScript;
	private Vitals vitalsScript;
	private History historyScript;
	private PhysicalExam physicalExamScript;
	private LabValues labsScript;
	private Disease disease;

	// Use this for initialization
	void Start () {
		demographicsScript = gameObject.AddComponent <Demographics> ();
		dialogueScript = gameObject.AddComponent <Dialogue> ();
		vitalsScript = gameObject.AddComponent <Vitals> ();
		historyScript = gameObject.AddComponent <History> ();
		physicalExamScript = gameObject.AddComponent <PhysicalExam> ();
		labsScript = gameObject.AddComponent <LabValues> ();
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
	}

}
