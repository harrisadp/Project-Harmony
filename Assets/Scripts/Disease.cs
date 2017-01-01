using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

public Text tText;
public Text hrText;
public Text sbpText;
public Text dbpText;
public Text rrText;
public Text spO2Text;

private float temperature;
private int heartRate;
private int systolicBP;
private int diastolicBP;
private int respiratoryRate;
private float spO2;

	// Use this for initialization
	void Start () {
		temperature = Random.Range(36.5f, 37.9f);
		heartRate = Random.Range(60,80);
		systolicBP = Random.Range(115, 130);
		diastolicBP = Random.Range (75, 90);
		respiratoryRate = Random.Range (10, 14);
		spO2 = Random.Range (0.9f, 1.0f);
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

}
