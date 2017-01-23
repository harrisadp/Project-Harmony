using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTracker : MonoBehaviour {

	public DiseaseList diseaseList;
	public int diseaseChosen;
	public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckIfGoodQuestion (string question) {
		if (diseaseList.diseaseList [diseaseChosen].goodQuestions.Contains (question)) {
			Debug.Log ("This is a good question");
			score += 100;
			Debug.Log (score);
		} else if (diseaseList.diseaseList [diseaseChosen].badQuestions.Contains (question)) {
			Debug.Log ("This is a stupid question");
			score -= 100;
			Debug.Log (score);
		} else {
			Debug.Log ("This is a neutral question");
			Debug.Log (score);
		}
	}

}
