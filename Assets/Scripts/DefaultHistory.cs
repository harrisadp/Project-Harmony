using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultHistory : MonoBehaviour {

	public Dictionary<string, string> history = new Dictionary<string, string>();

	void Awake () {
		history ["HPI"] = "I feel fine. I don't even know why you're talking to me.";
		history ["PMH"] = "Nope. I've always been healthy.";
		history ["PSH"] = "Nope. Never had surgery.";
		history ["SH"] = "I've never smoked and I never drink alcohol.";
		history ["FH"] = "As far as I know, everyone in my family has been healthy.";
	}

}
