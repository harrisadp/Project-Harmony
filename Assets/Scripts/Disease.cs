using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	private DefaultLabValues labs;

	// Use this for initialization
	void Start () {
		labs = GetComponent<DefaultLabValues> ();
		labs.labValues ["WBC"] = UnityEngine.Random.Range (15.0f, 25.0f);
		Debug.Log ("New WBC value is: " + labs.labValues ["WBC"]);
	}
	
	// Update is called once per frame
	void Update () {

	}
		
}
