using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	private AudioClip oldMusic;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMastervolume();
		MusicManager[] musicManagers = FindObjectsOfType<MusicManager> ();
		if (musicManagers.Length > 1) {
			Destroy (this.gameObject);
		}
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
	}
	
	public void ChangeVolume (float volume){
		audioSource.volume = volume;
	}

}
