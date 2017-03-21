using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public TextAsset textAsset;
	public GameObject rootMenu;
	public GameObject playerSelectionPanel;
	public GameObject imagePanel;
	public Text citation;
	public GameObject differentialPanel;
	public GameObject differentialDiagnosisItem;
	public GameObject diagnoseButton;
	public GameObject playerMenuButtonPrefab;
	public GameObject playerSelectionButtonPrefab;
	public GameObject backButtonPrefab;
	public GameObject journal;
	public GameObject journalButton;
	public Sprite imageToDisplay;
	public bool victory = false;
	public bool displayImage = false;
	public bool isFirstTurn = true;
	public int turnCount;
	public string currentMenu;

	private LevelManager levelManager;
	private DiseaseChooser diseaseChooser;
	private DialogueManager dialogueManager;
	private bool initializeDifferential = true;

	// Use this for initialization
	void Start () {
		// Identifiers
		levelManager = FindObjectOfType<LevelManager> ();
		diseaseChooser = FindObjectOfType<DiseaseChooser>();
		dialogueManager = FindObjectOfType<DialogueManager> ();

		// Actual initialization
		rootMenu.SetActive(false);
		playerSelectionPanel.SetActive (false);
		imagePanel.SetActive (false);
		differentialPanel.SetActive (false);
		journal.SetActive (false);
		journalButton.SetActive (false);
		turnCount = 1;
		currentMenu = "MainMenu";
		Debug.Log ("Turn count is " + turnCount);
	}

	public void Reset () {
		rootMenu.SetActive (false);
		playerSelectionPanel.SetActive (false);
		journalButton.SetActive (false);
	}

	public void NewTurn () {
		if (imagePanel.activeSelf) {imagePanel.SetActive (false);}
		if (displayImage) {DisplayImage ();}
		else if (isFirstTurn) {StartUp ();}
		else if (victory) {levelManager.LoadLevel ("03a_Victory");}
		else {
			turnCount++;
			Debug.Log ("Turn count is " + turnCount);
			Debug.Log ("Current menu is" + currentMenu);
			playerSelectionPanel.GetComponent<PlayerOptionsMenu>().SetMenu();
		}
	}

	public void MainMenu () {
		currentMenu = "MainMenu";
		rootMenu.SetActive (true);
		playerSelectionPanel.SetActive (false);
		imagePanel.SetActive (false);
		differentialPanel.SetActive (false);
		journalButton.SetActive (true);
	}

	public void StartUp() {
		isFirstTurn = false;
		rootMenu.SetActive (false);
		turnCount--;
		int lineNum = 0;
		using (StringReader reader = new StringReader (textAsset.text)) {
			string line;
			while ((line = reader.ReadLine ()) != null) {
				lineNum++;
				if (line.Contains ("First turn")) {
					dialogueManager.LineStart (lineNum + 1);
					dialogueManager.LineBreak (lineNum + 1);
					dialogueManager.NewTalk ();
				}
			}
		}
	}

	public void Differential () {
		rootMenu.SetActive (false);
		playerSelectionPanel.SetActive (false);
		differentialPanel.SetActive (true);
		GameObject differentialOptionsPanel = GameObject.Find ("Options Panel");
		int itemNumber = 0;
		if (initializeDifferential == true){
			foreach (Transform child in differentialOptionsPanel.transform) {
				GameObject item = Instantiate (differentialDiagnosisItem, child);
				item.transform.localScale = new Vector3 (1, 1, 1);
				item.GetComponentInChildren<Text> ().text = diseaseChooser.disease_data.differential [itemNumber];
				itemNumber += 1;
				initializeDifferential = false;
			}
		}
	}

	public void DisplayImage(){
		Image[] images = imagePanel.GetComponentsInChildren<Image>();
		foreach (Image image in images) {
			if (image.gameObject.name != "Image Panel" && image.gameObject.name != "Proceed After Imaging") {
				image.sprite = imageToDisplay;
			}
		}
		imagePanel.SetActive (true);
		displayImage = false;
	}

}
