using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

public Text tText, hrText, sbpText, dbpText, rrText, spO2Text, labResults1, labResults2, labResults3;

private float temperature, spO2;
private int heartRate, systolicBP, diastolicBP, respiratoryRate;

private float wbc, hgb, plt;

	// Use this for initialization
	void Start () {
		temperature = Random.Range(36.5f, 37.9f);
		heartRate = Random.Range(60,80);
		systolicBP = Random.Range(115, 130);
		diastolicBP = Random.Range (75, 90);
		respiratoryRate = Random.Range (10, 14);
		spO2 = Random.Range (0.9f, 1.0f);
		wbc = Random.Range (3.5f, 10.5f);
		hgb = Random.Range (12.0f, 17.5f);
		plt = Random.Range (150f, 450f);
	}
	
	// Update is called once per frame
	void Update () {
		tText.text = temperature.ToString ("F1");
		hrText.text = heartRate.ToString ();
		sbpText.text = systolicBP.ToString ();
		dbpText.text = diastolicBP.ToString ();
		rrText.text = respiratoryRate.ToString ();
		spO2Text.text = spO2.ToString("P0");
	}

	public void CBC () {
		Debug.Log ("Button clicked");
		labResults1.text = wbc.ToString("F1");
		labResults2.text = hgb.ToString("F1");
		labResults3.text = plt.ToString("F0");
	}

}
