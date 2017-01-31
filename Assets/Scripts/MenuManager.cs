using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Main Menu
	private GameObject history;
	private GameObject physical;
	private GameObject labs;
	private GameObject imaging;
	private GameObject ddx;

	// Proceed from viewing imaging
	private GameObject proceedAfterImaging;

	// Other random things
	public DifferentialManager differentialManager;
	public TextAsset textAsset;
	public GameObject playerMenuPanel;
	public GameObject imagePanel;
	public GameObject playerMenuButtonPrefab;
	public GameObject playerSelectionButtonPrefab;
	public GameObject backButtonPrefab;
	public Sprite imageToDisplay;
	public bool victory = false;
	public bool displayImage = false;
	public bool isFirstTurn = true;

	private DialogueManager dialogueManager;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		// Main Menu
		history = GameObject.Find ("History");
		physical = GameObject.Find ("Physical");
		labs = GameObject.Find ("Labs");
		imaging = GameObject.Find ("Imaging");
		ddx = GameObject.Find ("DDX");

		// Other identifiers
		dialogueManager = FindObjectOfType<DialogueManager> ();
		levelManager = FindObjectOfType<LevelManager> ();
		proceedAfterImaging = GameObject.Find ("Proceed After Imaging");

		// Actual initialization
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		foreach (Transform child in playerMenuPanel.transform){
			Destroy (child.gameObject);
		}
		playerMenuPanel.SetActive (false);
		imagePanel.SetActive (false);
	}

	public void Reset () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		foreach (Transform child in playerMenuPanel.transform){
			Destroy (child.gameObject);
		}
		playerMenuPanel.SetActive (false);
	}

	public void NewTurn () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		foreach (Transform child in playerMenuPanel.transform){Destroy (child.gameObject);}
		playerMenuPanel.SetActive (false);
		// Hides image, if there is one
		if (imagePanel.activeSelf) {imagePanel.SetActive (false);}

		if (isFirstTurn) {
			FirstTurn ();
		} else if (victory) {
			levelManager.LoadLevel ("01a_Start");
		} else if (displayImage) {
			DisplayImage ();
		} else {
			history.SetActive (true);
			physical.SetActive (true);
			labs.SetActive (true);
			imaging.SetActive (true);
			ddx.SetActive (true);
			}
		}

	public void MainMenu () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		history.SetActive (true);
		physical.SetActive (true);
		labs.SetActive (true);
		imaging.SetActive (true);
		ddx.SetActive (true);
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		playerMenuPanel.SetActive (false);
	}

	public void FirstTurn() {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		differentialManager.Enable ();
		isFirstTurn = false;
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

	public void DisplayImage(){
		Image[] images = imagePanel.GetComponentsInChildren<Image>();
		foreach (Image image in images) {
			if (image.gameObject.name != "Image Panel") {
				image.sprite = imageToDisplay;
			}
		}
		imagePanel.SetActive (true);
		proceedAfterImaging.SetActive (true);
		displayImage = false;
	}

	// Boring menu navigation below

	public void History () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		playerMenuPanel.SetActive (true);
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] {"History of Present Illness", "Past Medical History", "Family History", "Social History", "Review of Systems"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "History of Present Illness") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { HPIPage1 (); } );
			} else if (menuOption.name == "Past Medical History") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PMH (); } );
			} else if (menuOption.name == "Social History") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { SHPage1 (); } );
			} else if (menuOption.name == "Family History") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { FH (); } );
			} else if (menuOption.name == "Review of Systems") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSPage1 (); } );
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { MainMenu (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void HPIPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"When were you last completely well", "When did the pain first start", "How would you describe your pain",
												"Where is the pain located", "Does the pain move anywhere", "How did the pain first start", "How severe is your pain",
												"Have you ever had a similar pain in the past", "Does anything make the pain better or worse",
												"What has been the impact of this problem on your life"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { HPIPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { History (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void HPIPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"Who else have you seen about this problem", "What treatments have been recommended for this problem",
												"What medications, including non-prescription medications, have you used for this problem",
												"Have you had any tests related to this problem", "Is there anything else bothering you"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "What treatments have been recommended for this problem") {
				menuOption.GetComponentInChildren<Text>().text = "What treatments have been recommended?";
			}
			if (menuOption.name == "What medications, including non-prescription medications, have you used for this problem") {
				menuOption.GetComponentInChildren<Text>().text = "What medications have you used for this problem?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { HPIPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PMH () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[7] 	{"What medical conditions have you been diagnosed with", "Have you ever had any operations",
												"What diseases have you had as a child", "What prescription medications do you take",
												"Do you take any over-the-counter medications", "Are you allergic to any medications",
												"Are you adherent with your medications"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "What medical conditions have you been diagnosed with") {
				menuOption.GetComponentInChildren<Text>().text = "What medical conditions do you have?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { History (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void FH () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[9] 	{"Were you adopted", "Tell me about your parents health",
												"Did anyone in your family, including grandparents, die at a young age", "What was the cause of death",
												"Do any members of your family have blood clotting problems", "Is there any history of cancer in your family",
												"Do any members of your family have heart problems", "Is there any history of autoimmune disorders in your family",
												"Are there any other chronic medical conditions that run in your family"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Tell me about your parents health") {
				menuOption.GetComponentInChildren<Text>().text = "Tell me about your parents' health.";
			}
			if (menuOption.name == "Did anyone in your family, including grandparents, die at a young age") {
				menuOption.GetComponentInChildren<Text>().text = "Did anyone in your family die at a young age?";
			}
			if (menuOption.name == "Do any members of your family have blood clotting problems") {
				menuOption.GetComponentInChildren<Text>().text = "Do any members of your family have clotting problems?";
			}
			if (menuOption.name == "Is there any history of autoimmune disorders in your family") {
				menuOption.GetComponentInChildren<Text>().text = "Any history of autoimmune disorders in your family?";
			}
			if (menuOption.name == "Are there any other chronic medical conditions that run in your family") {
				menuOption.GetComponentInChildren<Text>().text = "Any other chronic conditions run in your family?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { History (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void SHPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"Describe your lifestyle and where you are living", "Are you currently employed", "What is your marital status",
												"Is your preferred sexual partner of the opposite sex or the same sex", "Who lives at home with you",
												"Do you drink any alcohol", "How much do you drink in a week", "Have you ever thought about cutting down",
												"Do you smoke", "How many years have you smoked"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Describe your lifestyle and where you are living") {
				menuOption.GetComponentInChildren<Text>().text = "Describe your lifestyle and where you are living.";
			}
			if (menuOption.name == "Is your preferred sexual partner of the opposite sex or the same sex") {
				menuOption.GetComponentInChildren<Text>().text = "Is your preferred partner the opposite or same sex?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { SHPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { History (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}
		

	public void SHPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[8] 	{"How many packs per day have you smoked", "Have you ever thought about quitting",
												"Do you do any illicit or recreational drugs", "Which drugs do you use and how frequently do you use them",
												"Have you ever tried to quit using drugs or have been in a detoxification program", "Where were you born",
												"What is your financial situation", "How active are you"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Which drugs do you use and how frequently do you use them") {
				menuOption.GetComponentInChildren<Text>().text = "Which drugs do you use and how frequently?";
			}
			if (menuOption.name == "Have you ever tried to quit using drugs or have been in a detoxification program") {
				menuOption.GetComponentInChildren<Text>().text = "Have you ever tried to quit using drugs?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { SHPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"General", "Musculoskeletal", "Psychiatric", "Respiratory", "Cardiovascular", "Gastrointestinal",
												"Neurologic", "Hematologic", "Endocrine", "Genitourinary"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "General") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSGeneral (); } );
			} else if (menuOption.name == "Musculoskeletal") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSMSK (); } );
			} else if (menuOption.name == "Psychiatric") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSPsych (); } );
			} else if (menuOption.name == "Respiratory") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSRespPage1 (); } );
			} else if (menuOption.name == "Cardiovascular") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSCardPage1 (); } );
			} else if (menuOption.name == "Gastrointestinal") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSGIPage1 (); } );
			} else if (menuOption.name == "Neurologic") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSNeuroPage1 (); } );
			} else if (menuOption.name == "Hematologic") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSHeme (); } );
			} else if (menuOption.name == "Endocrine") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSEndo (); } );
			} else if (menuOption.name == "Genitourinary") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSGU (); } );
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { History (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"Oropharynx", "Nose and Sinus", "Ears", "Eyes", "Head", "Dermatologic"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Oropharynx") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSOropharynx (); } );
			} else if (menuOption.name == "Nose and Sinus") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSNoseSinus (); } );
			} else if (menuOption.name == "Ears") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSEars (); } );
			} else if (menuOption.name == "Eyes") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSEyes (); } );
			} else if (menuOption.name == "Head") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSHead (); } );
			} else if (menuOption.name == "Dermatologic") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { ROSDerm (); } );
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSGeneral () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"How are your energy levels", "Have you noticed any significant weight gain",
												"Have you noticed any significant weight loss", "Do you have any difficulty sleeping",
												"Have you experienced any fevers or chills", "Have you experienced any drenching night sweats"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSMSK () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"Do you have any pains, stiffness, or swelling in your joints", "Do you have backaches",
												"Do you have pains in your legs", "Do you have pains or cramps in your muscles"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Do you have any pains, stiffness, or swelling in your joints") {
				menuOption.GetComponentInChildren<Text>().text = "Do you have pains, stiffness, or swelling in your joints?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSPsych () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[3] 	{"Do you feel nervous", "Do you feel anxious", "Do you feel depressed"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSRespPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"Do you ever feel short of breath on exertion", "Has your breathing changed over the past month",
												"Do you suffer from a cough", "Is your cough productive", "What color is the sputum",
												"Have you traveled anywhere outside of the country recently", "Did you travel by airplane for long distances",
												"Have you been in contact with any individuals who are sick",
												"Do you work in or frequently visit a healthcare facility", "Have you ever lived in a shelter or prison"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you traveled anywhere outside of the country recently") {
				menuOption.GetComponentInChildren<Text>().text = "Have you traveled outside the country recently?";
			}
			if (menuOption.name == "Have you been in contact with any individuals who are sick") {
				menuOption.GetComponentInChildren<Text>().text = "Have you been in contact with sick people?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSRespPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSRespPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[3] 	{"Have you ever worked in a shipyard",
												"Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis",
												"Have you ever had a tuberculosis skin test"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis") {
				menuOption.GetComponentInChildren<Text>().text = "Have you ever been exposed to tuberculosis?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSRespPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSCardPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"Have you ever experienced chest pain on exertion before", "Do you experience palpitations",
			"Have you ever had a heart attack", "Have you noticed any swelling in your ankles", "Have you noticed any change in waist circumference",
			"Do you ever wake up in the middle of the night gasping for air", "Do you experience any difficulty with your breathing when you lie flat",
			"How many pillows do you sleep with at night", "Have you ever fainted", "Have you experienced any pain in your legs while walking"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you ever experienced chest pain on exertion before") {
				menuOption.GetComponentInChildren<Text>().text = "Have you ever experienced chest pain on exertion?";
			}
			if (menuOption.name == "Do you ever wake up in the middle of the night gasping for air") {
				menuOption.GetComponentInChildren<Text>().text = "Do you ever wake up in the night gasping for air?";
			}
			if (menuOption.name == "Do you experience any difficulty with your breathing when you lie flat") {
				menuOption.GetComponentInChildren<Text>().text = "Do you experience difficulty breathing when lying flat?";
			}
			if (menuOption.name == "Have you experienced any pain in your legs while walking") {
				menuOption.GetComponentInChildren<Text>().text = "Have you experienced pain in your legs while walking?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSCardPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSCardPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"Do your legs feel cold", "Is there any history in your family of sudden cardiac death",
			"Have you recently had a cold or flu", "Have you ever been told you have a heart murmur", "Did you ever have rheumatic heart disease as a child"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Is there any history in your family of sudden cardiac death") {
				menuOption.GetComponentInChildren<Text>().text = "Any history in your family of sudden cardiac death?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSCardPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSGIPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"How is your appetite", "Does food ever get stuck in your throat", "Do you ever experience pain while swallowing",
												"Do you have difficulty swallowing solids, or liquids, or both", "Do you suffer from heartburn",
												"Have you ever felt that you get full really quickly during meals", "Have you experienced any nausea or vomiting",
												"Have you experienced any abdominal bloating", "Have you had any diarrhea", "Have you had any constipation"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Do you have difficulty swallowing solids, or liquids, or both") {
				menuOption.GetComponentInChildren<Text>().text = "Difficulty with swallowing solids, or liquids, or both?";
			}
			if (menuOption.name == "Have you ever felt that you get full really quickly during meals") {
				menuOption.GetComponentInChildren<Text>().text = "Have you felt that you get full quickly during meals?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSGIPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSGIPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"Have you ever had any blood in your stool", "Have you ever had any black, tarry stools",
												"Do you experience any pain while passing bowel movements", "Do you ever have any pale, fatty stools",
												"Have you taken any antibiotics recently", "Are your stools foul-smelling", "Have you ever vomited blood",
												"Was it bright red blood", "Did it look like coffee grounds", "Have you ever had a colonoscopy"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Do you experience any pain while passing bowel movements") {
				menuOption.GetComponentInChildren<Text>().text = "Do you ever experience pain with bowel movements?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSGIPage3 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSGIPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSGIPage3 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"Have you ever had a gastroscopy", "Have you had any recent travel outside of the country",
												"Have you noticed any yellowing of the eyes or skin", "Have you experienced any easy bruising or bleeding",
												"Have you noticed any enlargement of your breast tissue", "Have you noticed any muscle wasting"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you had any recent travel outside of the country") {
				menuOption.GetComponentInChildren<Text>().text = "Have you had any recent travel outside the country?";
			}
			if (menuOption.name == "Have you noticed any enlargement of your breast tissue") {
				menuOption.GetComponentInChildren<Text>().text = "Have you noticed enlargement of your breast tissue?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSGIPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSNeuroPage1 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"Have you ever had a stroke", "Was it due to a blood clot or a bleed", "Do you have any residual symptoms",
												"Have you ever had a seizure", "Have you experienced double-vision", "Have you experienced blurred vision",
												"Have you or others noticed any asymmetry in your face", "Have you experienced any slurring of your speech",
												"Have you experienced any numbness or tingling in your body",
												"Have you experienced any weakness on one side of your body"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you or others noticed any asymmetry in your face") {
				menuOption.GetComponentInChildren<Text>().text = "Have you noticed any asymmetry in your face?";
			}
			if (menuOption.name == "Have you experienced any numbness or tingling in your body") {
				menuOption.GetComponentInChildren<Text>().text = "Have you experienced any numbness or tingling?";
			}
			if (menuOption.name == "Have you experienced any weakness on one side of your body") {
				menuOption.GetComponentInChildren<Text>().text = "Have you had weakness on one side of your body?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSNeuroPage2 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSNeuroPage2 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"Have you ever lost control of your bowels or bladder", "Do you use any walking aids",
			"Do you have difficulty buttoning your shirts", "Have you noticed a tremor", "Have you had any problems with balance or coordination",
			"Have you noticed any changes in your voice", "Do you find that you choke or cough when you eat or drink",
			"Have you noticed any changes with your memory", "Have you ever left the tap or the stove on in your house", "Do you drive a car"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you had any problems with balance or coordination") {
				menuOption.GetComponentInChildren<Text>().text = "Have you had problems with balance or coordination?";
			}
			if (menuOption.name == "Do you find that you choke or cough when you eat or drink") {
				menuOption.GetComponentInChildren<Text>().text = "Do you choke or cough when you eat or drink?";
			}
			if (menuOption.name == "Have you ever left the tap or the stove on in your house") {
				menuOption.GetComponentInChildren<Text>().text = "Have you ever left the tap or stove on in your house?";
			}
		}
		GameObject nextButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		nextButton.GetComponentInChildren<Text> ().text = "Next";
		nextButton.GetComponent<Button>().onClick.AddListener (() => { ROSNeuroPage3 (); } );
		nextButton.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSNeuroPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSNeuroPage3 () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"Do you suffer from any headache", "Is it the worst headache you've ever had",
												"Have you had any associated nausea or vomiting", "Have you experienced any scalp tenderness or pain in your jaw"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you experienced any scalp tenderness or pain in your jaw") {
				menuOption.GetComponentInChildren<Text>().text = "Have you experienced scalp tenderness or jaw pain?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSNeuroPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSHeme () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"How difficult is it to stop bleeding when you have a small cut", "Do you have anemia",
												"Have you ever had a blood transfusion", "Did you experience any problems with the blood transfusion",
												"Do you bruise easily"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "How difficult is it to stop bleeding when you have a small cut") {
				menuOption.GetComponentInChildren<Text>().text = "Do you bleed easily?";
			}
			if (menuOption.name == "Did you experience any problems with the blood transfusion") {
				menuOption.GetComponentInChildren<Text>().text = "Did you have problems with the transfusion?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSEndo () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[7] 	{"How well do you tolerate the heat", "How well do you tolerate the cold", "Do you urinate frequently",
												"Are you excessively hungry", "Are you excessively thirsty", "Do you sweat excessively",
												"Have you noticed any changes to your skin or hair"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "How difficult is it to stop bleeding when you have a small cut") {
				menuOption.GetComponentInChildren<Text>().text = "Do you bleed easily?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSGU () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[9] 	{"Do you have any pain on urination", "Have you experienced an increased frequency in urinating",
												"How often do you urinate at night", "Do you often feel the urge to urinate",
												"Do you find it difficult to begin urinating", "Have you ever had blood in your urine", "Is your urine foamy",
												"Have you been experiencing any flank pain", "Have you noticed any skin changes to your external genitalia"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you experienced an increased frequency in urinating") {
				menuOption.GetComponentInChildren<Text>().text = "Have you had an increased frequency in urinating?";
			}
			if (menuOption.name == "Have you noticed any skin changes to your external genitalia") {
				menuOption.GetComponentInChildren<Text>().text = "Any skin changes to your external genitalia?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage1 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSOropharynx () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"Have you experienced any change in your voice", "Do you get frequent sore throats",
												"Do you have any problems with your teeth or gums", "Do you have any bleeding in your mouth"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSNoseSinus () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"How often do you have nosebleeds", "Do you have any discharge from your nose",
												"Do you have difficulty breathing through your nose", "Have you had a recent cold or infection in your sinuses"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you had a recent cold or infection in your sinuses") {
				menuOption.GetComponentInChildren<Text>().text = "Any recent colds or infections in your sinuses?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSEars () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"Do you have problems hearing", "Have you experienced a ringing in your ears", "Do you have earaches",
												"Have you had an infection or discharge from your ears"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Have you had an infection or discharge from your ears") {
				menuOption.GetComponentInChildren<Text>().text = "Have you had any discharge from your ears?";
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSEyes () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"Do you wear glasses or contact lenses", "When was your last eye examination",
												"Have you had any recent changes to your vision", "Do you have excessive tearing in your eyes",
												"Have you had any pain or redness in your eyes"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSHead () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[2] 	{"Have you had any injury to your head", "Have you had a stiff neck"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void ROSDerm () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"Do you have any lumps on your skin", "Do you have any rashes on your skin",
												"Do you have any itching, or dry skin", "Have you noticed any changes to your fingernails",
												"Have you noticed any changes to your hair growth"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponentInChildren<Text> ().text = i + "?";
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { ROSPage2 (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalMain () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		playerMenuPanel.SetActive (true);
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[7] 	{"General Exam", "Head, Eyes, Ears, Nose, and Throat Exam", "Pulmonary Exam", "Cardiovascular Exam",
												"Abdominal Exam", "Neurologic Exam", "Musculoskeletal Exam"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "General Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalGeneral (); } );
			} else if (menuOption.name == "Head, Eyes, Ears, Nose, and Throat Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalHEENT (); } );
			} else if (menuOption.name == "Pulmonary Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalPulmonary (); } );
			} else if (menuOption.name == "Cardiovascular Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalCardiovascular (); } );
			} else if (menuOption.name == "Abdominal Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalAbdominal (); } );
			} else if (menuOption.name == "Neurologic Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalNeurologic (); } );
			} else if (menuOption.name == "Musculoskeletal Exam") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalMSK (); } );
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { MainMenu (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalGeneral () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[2] 	{"General appearance", "Glasgow Coma Scale"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalHEENT () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"JVP", "Thyroid gland", "Carotids", "Lymph node palpation", "Oph - General inspection", "Fundoscopy",
			"Slit lamp exam", "Ears - General examination", "Otoscopic examination", "Oro - General inspection"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("JVP")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("JVP", "Jugular Venous Pressure");
			} else if (menuOption.name.Contains ("Oph - G")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Oph - G", "Eyes - g");
			} else if (menuOption.name.Contains ("Fundoscopy")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Fundoscopy", "Fundoscopic examination");
			} else if (menuOption.name.Contains ("Oro - G")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Oro - G", "Oropharynx - g");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalPulmonary () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[7] 	{"Pulm - Inspection", "Pulm - Palpation", "Pulm - Percussion", "Pulm - Auscultation", "Tactile fremitus",
												"Whispered pectoriloquy", "Egophony"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Pulm - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Pulm - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCardiovascular () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"Card - Inspection", "Card - Palpation", "Card - Auscultation",
												"Abd vasc - Inspection, palpation, and auscultation", "Upper limb vasc - Inspection, palpation, and auscultation",
												"Lower limb vasc - Inspection, palpation, and auscultation"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Card - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Card - ", "");
			} else if (menuOption.name.Contains ("Abd vasc")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace
					("Abd vasc - Inspection, palpation, and auscultation", "Abdominal vasculature - insp, palp, and ausc");
			} else if (menuOption.name.Contains ("limb vasc")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("vasc", "vasculature");
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace
					("Inspection, palpation, and auscultation", "insp, palp, and ausc");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalAbdominal () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"Abd - Inspection", "Abd - Inspection from the side, eyes at bedside level", "Abd - Palpation - Superficial",
												"Abd - Palpation - Deep", "Abd - Percussion", "Abd - Auscultation"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains (", eyes at bedside level")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace (", eyes at bedside level", "");
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Abd - ", "");
			} else if (menuOption.name.Contains ("Abd - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Abd - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalNeurologic () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[3] 	{"Cranial Nerves", "Peripheral Nervous System", "Cerebellar Examination"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Cranial Nerves") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalCranialNerves (); } );
			} else if (menuOption.name == "Peripheral Nervous System") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalPeripheralNervousSystem (); } );
			} else if (menuOption.name == "Cerebellar Examination") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalCerebellar (); } );
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCranialNerves () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions1 = new string[3] 	{"Olfactory Nerve (CN I)", "Optic Nerve (CN II)", "Oculomotor, Trochlear, and Abducens Nerves (CN III, IV, VI)"};
		foreach (string i in menuOptions1) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		string[] menuOptions2 = new string[2] 	{"Trigeminal Nerve (CN V)", "Facial Nerve (CN VII)"};
		foreach (string i in menuOptions2) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Trigeminal Nerve (CN V)") {
				menuOption.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCNV (); } );
			} else if (menuOption.name == "Facial Nerve (CN VII)") {
				menuOption.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCNVII (); } );
			}
		}
		string[] menuOptions3 = new string[2] 	{"Vestibulocochlear Nerve (CN VIII)", "Glosspharyngeal and Vagus Nerves (CN IX, X)"};
		foreach (string i in menuOptions3) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
		}
		string[] menuOptions4 = new string[2] 	{"Spinal Accessory Nerve (CN XI)", "Hypoglossal Nerve (CN XII)"};
		foreach (string i in menuOptions4) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Spinal Accessory Nerve (CN XI)") {
				menuOption.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCNXI (); } );
			} else if (menuOption.name == "Hypoglossal Nerve (CN XII)") {
				menuOption.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCNXII (); } );
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalNeurologic (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCNV () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"CN V - Sensation - Light touch", "CN V - Sensation - Pain and Temperature", "CN V - Sensation - Corneal Reflex",
												"CN V - Motor - Temporalis and masseters", "CN V - Motor - Jaw Jerk Reflex",
												"CN V - Motor - Lateral and Medial pterygoids"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("CN V - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("CN V - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCranialNerves (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCNVII () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[3] 	{"CN VII - Inspection", "CN VII - Motor - Muscles of facial expression", "CN VII - Reflexes"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("CN VII - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("CN VII - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCranialNerves (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCNXI () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[2] 	{"CN XI - Inspection", "CN XI - Motor"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("CN XI - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("CN XI - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCranialNerves (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCNXII () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[2] 	{"CN XII - Inspection", "CN XII - Motor"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("CN XII - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("CN XII - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalCranialNerves (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalPeripheralNervousSystem () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[7] 	{"Neuro - General inspection", "Neuro - Tone", "Neuro - Power", "Neuro - Sensation", "Neuro - Vibration",
												"Neuro - Proprioception", "Neuro - Reflexes"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Neuro - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Neuro - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalNeurologic (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalCerebellar () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"Cere - General inspection", "Cere - Gait", "Cere - Speech", "Cere - Coordination", "Cere - Motor"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Cere - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Cere - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalNeurologic (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalMSK () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"Knees", "Hips", "Shoulder", "Spine"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name == "Knees") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalKnees (); } );
			} else if (menuOption.name == "Hips") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalHips (); } );
			} else if (menuOption.name == "Shoulder") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalShoulder (); } );
			} else if (menuOption.name == "Spine") {
				menuOption.GetComponent<Button> ().onClick.AddListener( () => { PhysicalSpine (); } );
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMain (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalKnees () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[4] 	{"Knees - Inspection and gait assessment", "Knees - Range of movement", "Knees - Palpation",
												"Knees - Special tests"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Knees - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Knees - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMSK (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalHips () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[6] 	{"Hips - Gait", "Hips - Inspection", "Hips - Range of movement", "Hips - Palpation", "Thomas Test",
												"Trendelenberg Sign"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Hips - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Hips - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMSK (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalShoulder () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[7] 	{"Shoulder - Inspection", "Shoulder - Range of movement - active", "Shoulder - Range of movement - passive",
												"Shoulder - Palpation", "Lift-off Test", "Speed's Test", "Yergason's Test"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Shoulder - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Shoulder - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMSK (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void PhysicalSpine () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[5] 	{"Spine - Inspection", "Spine - Range of movement", "Spine - Palpation", "Straight Leg Test", "Schober's Test"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (1f, 0.588f, 0.196f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("Spine - ")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Spine - ", "");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { PhysicalMSK (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void Labs () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		playerMenuPanel.SetActive (true);
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		GameObject menuOption1 = Instantiate (playerMenuButtonPrefab, playerMenuPanel.transform);
		menuOption1.name = "Blood";
		menuOption1.GetComponent<Image> ().color = new Color (0.392f, 1f, 0.392f, 1f);
		menuOption1.GetComponentInChildren<Text> ().text = "Blood";
		menuOption1.transform.localScale = new Vector3 (1, 1, 1);
		menuOption1.GetComponent<Button> ().onClick.AddListener( () => { Blood (); } );
		GameObject menuOption2 = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
		menuOption2.name = "Urinalysis";
		menuOption2.GetComponent<Image> ().color = new Color (0.392f, 1f, 0.392f, 1f);
		menuOption2.GetComponentInChildren<Text> ().text = "Urine";
		menuOption2.transform.localScale = new Vector3 (1, 1, 1);
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { MainMenu (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void Blood () {
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[10] 	{"CBC", "BMP", "Coag", "LFT", "ABG", "ESR, CRP", "Amylase, lipase", "Thyroid hormones", "Troponin I",
												"Cortisol (random)"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (0.392f, 1f, 0.392f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);
			if (menuOption.name.Contains ("CBC")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("CBC", "Complete Blood Count");
			} else if (menuOption.name.Contains ("BMP")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("BMP", "Basic Metabolic Panel");
			} else if (menuOption.name.Contains ("Coag")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("Coag", "Coagulation studies");
			} else if (menuOption.name.Contains ("LFT")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("LFT", "Liver Function Tests");
			} else if (menuOption.name.Contains ("ABG")) {
				menuOption.GetComponentInChildren<Text> ().text = menuOption.GetComponentInChildren<Text> ().text.Replace ("ABG", "Arterial Blood Gas");
			}
		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { Labs (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

	public void Imaging () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		playerMenuPanel.SetActive (true);
		foreach (Transform child in GameObject.Find("Player Menu Panel").transform){
			Destroy (child.gameObject);
		}
		string[] menuOptions = new string[9] 	{"X-ray (chest)", "X-ray (abdomen)", "X-ray (spine)", "CT (head)", "CT (chest)", "CT (abdomen)", "MRI (brain)",
												"Ultrasound (abdomen)", "Ultrasound (extremities)"};
		foreach (string i in menuOptions) {
			GameObject menuOption = Instantiate (playerSelectionButtonPrefab, playerMenuPanel.transform);
			menuOption.name = i;
			menuOption.GetComponent<Image> ().color = new Color (0.196f, 0.784f, 1f, 1f);
			menuOption.GetComponentInChildren<Text> ().text = i;
			menuOption.transform.localScale = new Vector3 (1, 1, 1);

		}
		GameObject backButton = Instantiate (backButtonPrefab, playerMenuPanel.transform);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { MainMenu (); } );
		backButton.transform.localScale = new Vector3 (1, 1, 1);
	}

}
