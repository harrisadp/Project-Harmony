using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChooser : MonoBehaviour {

	public Sprite[] backgrounds;

	private int currentBackground;
	private GameObject background;

	// Use this for initialization
	void Start () {
		background = GameObject.Find ("Background");
		background.GetComponent<SpriteRenderer> ().sprite = backgrounds [0];
		currentBackground = 0;
	}

	public void NewBackground () {
		if (currentBackground < backgrounds.Length - 1) {
			currentBackground += 1;
		} else {
			currentBackground = 0;
		}
		background.GetComponent<SpriteRenderer> ().sprite = backgrounds [currentBackground];
	}

}
