using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	public Dictionary<string, string> dialogue = new Dictionary<string, string>();

	void Awake () {
		dialogue ["Intro"] = "I'm not feeling so great. Help me out, will ya?";
		dialogue ["Response"] = "I'll do my best!";
	}

}
