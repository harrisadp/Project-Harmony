using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disease : MonoBehaviour {

	private DiseaseChooser diseaseChooser;
	private enum Race {asian, black, hispanic, white};
	private enum Personality {personality1, personality2, personality3};

	void Start () {
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		new Disease (diseaseChooser.diseaseChosen.ToString());
	}

	public Disease (string diseaseName) {
		Debug.Log ("Disease constructor run");
		Debug.Log ("Disease name is " + diseaseName);
		PersonGenerator (20, 50, 0.5f, 0.1f, 0.1f, 0.3f, 0.5f);
	}

	private void PersonGenerator (int minAge, int maxAge, float maleProb, float asianProb, float blackProb, float hispanicProb, float whiteProb) {
		int age = Random.Range (minAge, maxAge);
		bool male;
		Race race;
		float blackThreshold = asianProb + blackProb;
		float hispanicThreshold = asianProb + blackProb + hispanicProb;
		float randomSex = Random.value;
		float randomRace = Random.value;
		// Sex determination
		if (randomSex <= maleProb) {
			male = true;
		} else {
			male = false;
		}
		// Race determination
		if (randomRace <= asianProb) {
			race = Race.asian;
		} else if (randomRace > asianProb && randomRace <= blackThreshold) {
			race = Race.black;
		} else if (randomRace > blackThreshold && randomRace <= hispanicThreshold) {
			race = Race.hispanic;
		} else {
			race = Race.white;
		}
		// Debug
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
	}

//	private void PersonalityChooser () {
//	
//	}

//	Where do the diseases go?!

}
