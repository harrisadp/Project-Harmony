using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demographics : MonoBehaviour {

	public int age;
	public bool male;
	public enum Race {white, black, asian, hispanic};
	public Race patientRace;

	private Text ageText, sexText;

	void Awake () {
		age = Random.Range (18, 85);
		male = true;
		patientRace = (Race)Random.Range (0, 4);
	}

	// Use this for initialization
	void Start () {
		ageText = GameObject.Find ("Age Text").GetComponent<Text>();
		sexText = GameObject.Find ("Sex Text").GetComponent<Text>();
		ageText.text = age.ToString ();
		if (male) {
			sexText.text = "Male".ToString ();
		} else {
			sexText.text = "Female".ToString ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

}
