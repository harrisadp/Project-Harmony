﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	private AudioClip oldMusic;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
	
	void Start (){
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMastervolume();
	}

	void OnEnable() {
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
         
	void OnDisable() {
		//Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
         
	void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode) {
		int level = SceneManager.GetActiveScene ().buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic && thisLevelMusic != oldMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
			oldMusic = thisLevelMusic;
		}
		if (level == 7) {
			audioSource.volume = 0;
		} else {
			audioSource.volume = PlayerPrefsManager.GetMastervolume ();
		}
	}
	
	public void ChangeVolume (float volume){
		audioSource.volume = volume;
	}

}
