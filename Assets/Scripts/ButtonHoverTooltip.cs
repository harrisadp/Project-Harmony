using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverTooltip : MonoBehaviour {

	public Font font;

	private GameObject thisButton;
	private GameObject tooltipObject;
	private string thisTooltip;
	private float hoverTime = 0f;
	private bool mouseOver = false;
	private bool tooltipVisible = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (mouseOver == true) {
			hoverTime += Time.deltaTime;
		}
		if (hoverTime >= 1f && tooltipVisible == false) {
			Tooltip ();
		}
	}

	public void Tooltip () {
		Debug.Log ("Mouse hovered");
		tooltipObject = new GameObject ("Tooltip");
		tooltipObject.transform.SetParent (thisButton.transform);
		tooltipObject.transform.localPosition = new Vector3 (0, 100f, 0);
		Text tooltipText = tooltipObject.AddComponent<Text> ();
		tooltipText.GetComponent<RectTransform> ().sizeDelta = new Vector2 (500f, 25f);
		tooltipText.text = thisTooltip;
		tooltipText.font = font;
		tooltipText.alignment = TextAnchor.MiddleCenter;
		tooltipVisible = true;
	}

	public void SetGameObject (GameObject button) {
		thisButton = button;
	}

	public void MouseOver (string tooltip) {
		mouseOver = true;
		thisTooltip = tooltip;
	}

	public void MouseOff () {
		mouseOver = false;
		hoverTime = 0f;
		tooltipVisible = false;
		Destroy (tooltipObject);
	}

}
