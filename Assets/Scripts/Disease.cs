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
		Debug.Log ("Disease changed WBC value to " + labs.labValues ["WBC"]);
	}
	
	// Update is called once per frame
	void Update () {

	}
		
}
