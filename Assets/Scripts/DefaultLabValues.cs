using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLabValues : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
