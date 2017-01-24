﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class RunOnStart : MonoBehaviour {

	public static DiseaseStruct global_disease_list;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		global_disease_list = new DiseaseStruct (3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
