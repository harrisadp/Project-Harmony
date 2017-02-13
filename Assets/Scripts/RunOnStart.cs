﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class RunOnStart : MonoBehaviour {

	public static DiseaseStruct global_disease_list;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		global_disease_list = new DiseaseStruct (4);
		Debug.Log ("New DiseaseStruct created");
		RunOnStart[] runOnStarts = FindObjectsOfType<RunOnStart> ();
		foreach (RunOnStart i in runOnStarts) {
			if (i.gameObject != this.gameObject) {
				Destroy (i.gameObject);
			}
		}
	}

}
