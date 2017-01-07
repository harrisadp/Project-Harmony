using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultVitals : MonoBehaviour {

	public Dictionary<string, float> vitals = new Dictionary<string, float>();

	void Awake () {
		vitals ["T"] = Mathf.Round(10*(Random.Range (36.5f, 37.3f)))/10;
		vitals ["HR"] = Mathf.Round(Random.Range (60f, 100f));
		vitals ["SBP"] = Mathf.Round(Random.Range (110f, 130f));
		vitals ["DBP"] = Mathf.Round(Random.Range (70f, 90f));
		vitals ["RR"] = Mathf.Round(Random.Range (10f, 14f));
		vitals ["SpO2"] = Mathf.Round(10*(Random.Range (90.0f, 100.0f)))/10;

		Debug.Log (vitals ["T"]);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
