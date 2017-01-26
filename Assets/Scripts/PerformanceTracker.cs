using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceTracker : MonoBehaviour {

	public int score = 0;

	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = score.ToString();
	}

	public void UpdateScore () {
		scoreText.text = score.ToString ();
	}

}
