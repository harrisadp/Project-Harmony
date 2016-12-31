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

private float temperature;
private int heartRate;
private int systolicBP;
private int diastolicBP;
private int respiratoryRate;

	// Use this for initialization
	void Start () {
		temperature = Random.Range(36.5f, 37.9f);
		heartRate = Random.Range(60,80);
		systolicBP = Random.Range(115, 130);
		diastolicBP = Random.Range (75, 90);
		respiratoryRate = Random.Range (10, 14);
	}
	
	// Update is called once per frame
	void Update () {
		tText.text = temperature.ToString ("F1");
		hrText.text = heartRate.ToString ();
		sbpText.text = systolicBP.ToString ();
		dbpText.text = diastolicBP.ToString ();
		rrText.text = respiratoryRate.ToString ();
	}

}
