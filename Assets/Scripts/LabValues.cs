﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabValues : MonoBehaviour {

	public Dictionary<string, float> labValues = new Dictionary<string, float>();

	void Awake () {
		labValues ["WBC"] = Mathf.Round(10*(Random.Range (3.5f, 10.5f)))/10;
		labValues ["HGB"] = Mathf.Round(10*(Random.Range (13.5f, 15.5f)))/10;
		labValues ["PLT"] = Mathf.Round(Random.Range (150f, 450f));
		labValues ["Na"] = Mathf.Round(Random.Range (133f, 143f));
		labValues ["K"] = Mathf.Round(10*(Random.Range (3.5f, 5.1f)))/10;
		labValues ["Cl"] = Mathf.Round(Random.Range (98f, 107f));
		labValues ["HCO3"] = Mathf.Round(Random.Range (22f, 30f));
		labValues ["BUN"] = Mathf.Round(Random.Range (7f, 20f));
		labValues ["Cr"] = Mathf.Round(100*(Random.Range (0.6f, 1.2f)))/100;
		labValues ["Glu"] = Mathf.Round(Random.Range (70f, 100f));
		labValues ["AST"] = Mathf.Round(Random.Range (8f, 48f));
		labValues ["ALT"] = Mathf.Round(Random.Range (7f, 55f));
		labValues ["AlkPhos"] = Mathf.Round(Random.Range (88f, 126f));
		labValues ["Ca"] = Mathf.Round(10*(Random.Range (8.4f, 10.2f)))/10;
		labValues ["TotalProt"] = Mathf.Round(10*(Random.Range (6.0f, 10.0f)))/10;
		labValues ["Albumin"] = Mathf.Round(10*(Random.Range (3.5f, 5.5f)))/10;
		labValues ["TotalBili"] = Mathf.Round(10*(Random.Range (0.0f, 1.4f)))/10;
		labValues ["PT"] = Mathf.Round(10*(Random.Range (11.1f, 13.1f)))/10;
		labValues ["PTT"] = Mathf.Round(10*(Random.Range (22.1f, 35.1f)))/10;
		labValues ["INR"] = Mathf.Round(10*(Random.Range (0.8f, 1.2f)))/10;
		labValues ["Amylase"] = Mathf.Round(Random.Range (23f, 85f));
		labValues ["Lipase"] = Mathf.Round(Random.Range (0f, 160f));
		labValues ["Lactate"] = Mathf.Round(10*(Random.Range (0.5f, 1.0f)))/10;
		labValues ["Troponin I"] = Mathf.Round(100*(Random.Range (0.00f, 0.00f)))/100;
		labValues ["CK"] = Mathf.Round(Random.Range (50f, 200f));
		labValues ["CRP"] = Mathf.Round(10*(Random.Range (0.0f, 1.0f)))/10;
		labValues ["Cortisol (random)"] = Mathf.Round(Random.Range (0f, 20f));
		labValues ["TSH"] = Mathf.Round(10*(Random.Range (0.5f, 6.0f)))/10;
		labValues ["T3"] = Mathf.Round(Random.Range (80f, 180f));
		labValues ["T4"] = Mathf.Round(10*(Random.Range (4.6f, 12.0f)))/10;
		labValues ["pH"] = Mathf.Round(100*(Random.Range (7.35f, 7.45f)))/100;
		labValues ["paCO2"] = Mathf.Round(Random.Range (35f, 45f));
		labValues ["paO2"] = Mathf.Round(Random.Range (80f, 100f));
		labValues ["upH"] = Mathf.Round(10*(Random.Range (4.5f, 8.0f)))/10;
		labValues ["uSpGrav"] = Mathf.Round(1000*(Random.Range (1.005f, 1.025f)))/1000;
		labValues ["uGluc"] = Mathf.Round(Random.Range (0f, 130f));
	}

}
