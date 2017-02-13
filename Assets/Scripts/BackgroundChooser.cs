using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChooser : MonoBehaviour {

	public Sprite[] backgrounds;
	public RuntimeAnimatorController[] animatorControllers;
	public AudioClip[] bgm;

	private int currentBackground;
	private GameObject background;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = backgrounds [0];
		if (animatorControllers [0] != null) {
			background.AddComponent<Animator> ().runtimeAnimatorController = animatorControllers [0];
		}
		currentBackground = 0;
		audioSource = GameObject.Find ("Music Manager").GetComponent<AudioSource> ();
		audioSource.clip = bgm [currentBackground];
		audioSource.Play ();
	}

	public void NewBackground () {
		if (currentBackground < backgrounds.Length - 1) {
			currentBackground += 1;
		} else {
			currentBackground = 0;
		}
		audioSource.clip = bgm [currentBackground];
		audioSource.Play ();
		background.GetComponent<SpriteRenderer> ().sprite = backgrounds [currentBackground];
		if (animatorControllers [currentBackground] != null && background.GetComponent<Animator> () == null) {
			background.AddComponent<Animator> ().runtimeAnimatorController = animatorControllers [currentBackground];
		} else if (animatorControllers [currentBackground] != null && background.GetComponent<Animator> () != null) {
			background.GetComponent<Animator> ().runtimeAnimatorController = animatorControllers [currentBackground];
		} else if (animatorControllers [currentBackground] == null && background.GetComponent<Animator> () != null) {
			Destroy (background.GetComponent<Animator> ());
		} else if (animatorControllers [currentBackground] == null && background.GetComponent<Animator> () == null) {
			return;
		}
	}

}
