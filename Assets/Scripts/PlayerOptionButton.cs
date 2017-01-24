using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOptionButton : MonoBehaviour {

	public TextAsset textAsset;

	private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPushed () {
		string buttonName = gameObject.name;
		Debug.Log (buttonName);
		StringReader reader = new StringReader (textAsset.text);
		string line = reader.ReadLine ();
		if (line.Contains (buttonName)) {
			Debug.Log ("I found them. Repeat, I found them.");
		}
	}

}
