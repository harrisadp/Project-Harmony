using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitals : MonoBehaviour {

	public Dictionary<string, float> vitals = new Dictionary<string, float>();

	private Text tText, hrText, sbpText, dbpText, rrText, spo2Text;

	void Awake () {
		vitals ["T"] = Mathf.Round(10*(Random.Range (36.5f, 37.3f)))/10;
		vitals ["HR"] = Mathf.Round(Random.Range (60f, 100f));
		vitals ["SBP"] = Mathf.Round(Random.Range (110f, 130f));
		vitals ["DBP"] = vitals ["SBP"] -40f + Mathf.Round(Random.Range (-5f, 5f));
		vitals ["RR"] = Mathf.Round(Random.Range (10f, 14f));
		vitals ["SpO2"] = Mathf.Round(10*(Random.Range (95.0f, 100.0f)))/10;
	}

	// Use this for initialization
	void Start () {
		tText = GameObject.Find ("T Text").GetComponent<Text>();
		hrText = GameObject.Find ("HR Text").GetComponent<Text>();
		sbpText = GameObject.Find ("SBP Text").GetComponent<Text>();
		dbpText = GameObject.Find ("DBP Text").GetComponent<Text>();
		rrText = GameObject.Find ("RR Text").GetComponent<Text>();
		spo2Text = GameObject.Find ("SpO2 Text").GetComponent<Text>();
		tText.text = vitals ["T"].ToString ();
		hrText.text = vitals ["HR"].ToString ();
		sbpText.text = vitals ["SBP"].ToString ();
		dbpText.text = vitals ["DBP"].ToString ();
		rrText.text = vitals ["RR"].ToString ();
		spo2Text.text = vitals ["SpO2"].ToString () + "%";
	}

	// Update is called once per frame
	void Update () {
		
	}
}
