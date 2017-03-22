using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSwitch : MonoBehaviour {

	public Sprite[] icons;

	private AudioSource music;
	private bool musicOn = true;

	// Use this for initialization
	void Start () {
		music = GameObject.Find ("Music Manager").GetComponent<AudioSource> ();
		GetComponent<Image>().sprite = icons[1];
	}
	
	public void ToggleVolume () {
		if (musicOn == true){
			music.volume = 0;
			musicOn = false;
			GetComponent<Image>().sprite = icons[0];
		} else {
			music.volume = PlayerPrefsManager.GetMastervolume();
			musicOn = true;
			GetComponent<Image>().sprite = icons[1];
		}
	}

}
