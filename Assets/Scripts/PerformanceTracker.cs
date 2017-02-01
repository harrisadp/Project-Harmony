using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PerformanceTracker : MonoBehaviour {

	private Canvas canvas;
	private Text scoreText;

	public int score = 0;
	public int energyValue = 0;
	public GameObject energyIcon;
	public List<string> questionsAsked = new List<string>();
	public List<string> physicalManeuversPerformed = new List<string>();
	public List<string> labsOrdered = new List<string>();
	public List<string> imagesOrdered = new List<string>();

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		canvas = FindObjectOfType<Canvas> ();
		if (canvas.transform.FindChild ("Score/Score")) {scoreText = canvas.transform.Find ("Score/Score").GetComponent<Text> ();}
		else if (canvas.transform.FindChild ("Score")) {scoreText = canvas.transform.Find ("Score").GetComponent<Text> ();}
		else {Debug.LogWarning ("No score text found!");}
		scoreText.text = score.ToString();
		questionsAsked.Clear();
		physicalManeuversPerformed.Clear();
		labsOrdered.Clear();
		imagesOrdered.Clear();
	}

	public void UpdateScore () {
		scoreText.text = score.ToString ();
	}

	public void AddEnergy () {
		if (GameObject.Find ("Energy Panel").transform.childCount < 5) {
			GameObject energy = Instantiate (energyIcon, GameObject.Find ("Energy Panel").transform);
			energy.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void RemoveEnergy (int numberToRemove) {
		int numberDestroyed = 0;
		if (GameObject.Find ("Energy Panel").transform.childCount > 0) {
			foreach (Transform child in GameObject.Find("Energy Panel").transform){
				if (numberDestroyed < numberToRemove) {
					GameObject.Destroy (child.gameObject);
					numberDestroyed += 1;
				}
			}
		}
	}

}
