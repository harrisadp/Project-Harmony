using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

	private RPGTalk rpgTalk;

	// Use this for initialization
	void Start () {
		rpgTalk = FindObjectOfType<RPGTalk> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LineStart (int lineStart) {
		rpgTalk.lineToStart = lineStart;
	}

	public void LineBreak (int lineBreak) {
		rpgTalk.lineToBreak = lineBreak;
	}

	public void NewTalk () {
		rpgTalk.NewTalk ();
	}

}
