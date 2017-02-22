﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PerformanceTracker : MonoBehaviour {

	public int score = 0;
	public int energyValue = 0;
	public int maxEnergyValue = 10;
	public GameObject energyIcon;
	public AudioClip goodSound;
	public AudioClip badSound;
	public List<string> questionsAsked = new List<string>();
	public List<string> physicalManeuversPerformed = new List<string>();
	public List<string> labsOrdered = new List<string>();
	public List<string> imagesOrdered = new List<string>();
	public int inappropriateFemaleExams = 0;

	private Canvas canvas;
	private Text scoreText;
	private Animator emdeeAnimator;
	private Animator energyAnimator;
	private AudioSource audioSource;
	private GameObject energyTag;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		PerformanceTracker[] performanceTrackers = FindObjectsOfType<PerformanceTracker> ();
		if (performanceTrackers.Length > 1) {
			Destroy (this.gameObject);
		}
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		canvas = FindObjectOfType<Canvas> ();
		if (canvas.transform.FindChild ("Score/Score")) {
			scoreText = canvas.transform.Find ("Score/Score").GetComponent<Text> ();
			scoreText.text = score.ToString();
		}
		else if (canvas.transform.FindChild ("Score")) {
			scoreText = canvas.transform.Find ("Score").GetComponent<Text> ();
			scoreText.text = score.ToString ();
		}
		else {
			Debug.Log ("No score text found!");
		}
		if (GameObject.Find ("Sound Effects") != null) {
			audioSource = GameObject.Find ("Sound Effects").GetComponent<AudioSource> ();
			audioSource.volume = 0.25f;
		}
		if (GameObject.Find ("Emdee") != null) {
			emdeeAnimator = GameObject.Find ("Emdee").GetComponent<Animator> ();
		}
		questionsAsked.Clear();
		physicalManeuversPerformed.Clear();
		labsOrdered.Clear();
		imagesOrdered.Clear();
		if (scene.name == "02c_QuickPlay") {
			score = 0;
			energyValue = 0;
		}
		UpdateScore ();
	}

	public void UpdateScore () {
		scoreText.text = score.ToString ();
	}

	public void AddEnergy () {
		if (GameObject.Find ("Energy Panel").transform.childCount < maxEnergyValue + 1) {
			GameObject energy = Instantiate (energyIcon, GameObject.Find ("Energy Panel").transform);
			energy.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void RemoveEnergy (int numberToRemove) {
		int numberDestroyed = 0;
		if (GameObject.Find ("Energy Panel").transform.childCount > 1) {
			foreach (Transform child in GameObject.Find("Energy Panel").transform){
				if (numberDestroyed < numberToRemove && child.gameObject.name != "Energy Tag") {
					Destroy (child.gameObject);
					numberDestroyed += 1;
				}
			}
		}
	}

	public void PositiveAnimation () {
		emdeeAnimator.SetTrigger ("Positive Reaction");
		audioSource.clip = goodSound;
		audioSource.Play ();
	}

	public void NegativeAnimation () {
		emdeeAnimator.SetTrigger ("Negative Reaction");
		audioSource.clip = badSound;
		audioSource.Play ();
	}

}
