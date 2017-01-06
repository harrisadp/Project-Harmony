using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLabValues : MonoBehaviour {

	public Dictionary<string, float> labValues = new Dictionary<string, float>();

	void Awake () {
		labValues ["WBC"] = Random.Range (3.5f, 10.5f);
		labValues ["HGB"] = Random.Range (13.5f, 15.5f);
		labValues ["PLT"] = Random.Range (150f, 450f);
		labValues ["Na"] = Random.Range (133f, 143f);
		labValues ["K"] = Random.Range (3.5f, 5.1f);
		labValues ["Cl"] = Random.Range (98f, 107f);
		labValues ["HCO3"] = Random.Range (22f, 30f);
		labValues ["BUN"] = Random.Range (7f, 20f);
		labValues ["Cr"] = Random.Range (0.6f, 1.2f);
		labValues ["Glu"] = Random.Range (70f, 100f);
		labValues ["AST"] = Random.Range (8f, 48f);
		labValues ["ALT"] = Random.Range (7f, 55f);
		Debug.Log ("Default lab value set to: " + labValues["WBC"]);
		Debug.Log ("Default lab value set to: " + labValues["Cl"]);
		Debug.Log ("Default lab value set to: " + labValues["ALT"]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
