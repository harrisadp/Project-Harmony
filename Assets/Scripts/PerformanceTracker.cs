using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceTracker : MonoBehaviour {

	public int score = 0;
	public Text scoreText;
	public int energyValue;
	public List<string> questionsAsked = new List<string>();
	public List<string> physicalManeuversPerformed = new List<string>();
	public List<string> labsOrdered = new List<string>();
	public List<string> imagesOrdered = new List<string>();

	private GUIBarScript guiBar;

	// Use this for initialization
	void Start () {
		scoreText.text = score.ToString();
		guiBar = FindObjectOfType<GUIBarScript> ();
		guiBar.Value = 0;
		guiBar.CurrentValue = 0;
		guiBar.ForceUpdate ();
	}

	public void UpdateScore () {
		scoreText.text = score.ToString ();
		guiBar.Value = (float)energyValue / 10;
	}

}
