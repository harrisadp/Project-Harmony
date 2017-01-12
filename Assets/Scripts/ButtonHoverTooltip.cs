using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverTooltip : MonoBehaviour {

	public Font font;

	private GameObject thisButton;
	private GameObject tooltipObject;
	private GameObject tooltipPanel;
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
		tooltipPanel = new GameObject ("Tooltip Panel");
		tooltipPanel.transform.SetParent (thisButton.transform);
		Image tooltipPanelImage = tooltipPanel.AddComponent<Image> ();
		Color tooltipPanelImageColor = tooltipPanelImage.color = Color.gray;
		tooltipPanelImageColor.a = 0.8f;
		tooltipPanelImage.color = tooltipPanelImageColor;
		tooltipPanel.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1);
		tooltipPanel.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1);
		tooltipPanel.GetComponent<RectTransform> ().pivot = new Vector2 (0, 1);
		tooltipPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (300f, 250f);
		tooltipPanel.transform.localPosition = new Vector3 (-700f, 0, 0);

		tooltipObject = new GameObject ("Tooltip");
		tooltipObject.transform.SetParent (thisButton.transform);
		tooltipObject.transform.localPosition = new Vector3 (-675f, -25f, 0);
		Text tooltipText = tooltipObject.AddComponent<Text> ();
		tooltipObject.GetComponent<RectTransform> ().anchorMin = new Vector2 (0, 1);
		tooltipObject.GetComponent<RectTransform> ().anchorMax = new Vector2 (0, 1);
		tooltipObject.GetComponent<RectTransform> ().pivot = new Vector2 (0, 1);
		tooltipObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (275f, 225f);
		tooltipText.text = thisTooltip;
		tooltipText.font = font;
		tooltipText.fontSize = 18;
		tooltipText.alignment = TextAnchor.UpperLeft;
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
		Destroy (tooltipPanel);
		Destroy (tooltipObject);
	}

}
