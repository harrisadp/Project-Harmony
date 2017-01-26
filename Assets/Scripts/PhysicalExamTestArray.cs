using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalExamTestArray : MonoBehaviour {

	public string[][][][] physicalExam = new string[10][][][];

	// Use this for initialization
	void Start () {
		physicalExam [0] = new string[2][][];
		foreach (string i in physicalExam[0][0][0]) {
			Debug.Log (i);
		}
	}

}
