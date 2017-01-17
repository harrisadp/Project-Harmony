using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseChooser : MonoBehaviour {

	public enum Disease {disease1, disease2, disease3};
	public Disease diseaseChosen;

	// Use this for initialization
	void Start () {
		diseaseChosen = (Disease)Random.Range (0, 3);

	}

}
