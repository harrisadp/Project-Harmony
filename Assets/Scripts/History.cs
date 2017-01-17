using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour {

	public Dictionary<string, string> history = new Dictionary<string, string>();

	void Awake () {
		history ["HPI"] = "[HPI]";
		history ["PMH"] = "[PMH]";
		history ["PSH"] = "[PSH]";
		history ["SH"] = "[SH]";
		history ["FH"] = "[FH]";
	}

}
