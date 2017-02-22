using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour {

	public List<string> imagingStudies = new List <string>();

	public Sprite[] xrayChests;
	public Sprite[] xrayAbdomens;
	public Sprite[] xraySpines;
	public Sprite[] ctHeads;
	public Sprite[] ctChests;
	public Sprite[] ctAbdomens;
	public Sprite[] mriBrains;
	public Sprite[] ultrasoundAbdomens;
	public Sprite[] ultrasoundPelvis;
	public string[] ultrasoundPelvisCitations;

	void Awake () {
		foreach (string i in new string[]{"X-ray (chest)", "X-ray (abdomen)", "X-ray (spine)", "CT (head)", "CT (chest)", "CT (abdomen)", "MRI (brain)",
			"Ultrasound (abdomen)", "Ultrasound (pelvis)"}) {
			imagingStudies.Add (i);
		}
	}

}
