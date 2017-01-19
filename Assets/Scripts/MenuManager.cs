using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Main Menu
	private GameObject history;
	private GameObject physical;
	private GameObject labs;
	private GameObject imaging;
	private GameObject ddx;

		// History
		private GameObject hpi;
		private GameObject pmh;
		private GameObject sh;
		private GameObject fh;
		private GameObject ros;
		private GameObject backToMainFromHistory;

			// History of Present Illness
			private GameObject whenWereYouLastCompletelyWell;
			private GameObject whenDidThePainFirstStart;
			private GameObject howWouldYouDescribeYourPain;
			private GameObject whereIsThePainLocated;
			private GameObject doesThePainMoveAnywhere;
			private GameObject howDidThePainFirstStart;
			private GameObject howSevereIsYourPain;
			private GameObject haveYouEverHadASimilarPainInThePast;
			private GameObject doesAnythingMakeThePainBetterOrWorse;
			private GameObject whatHasBeenTheImpactOfThisProblemOnYourLife;
			private GameObject hpiNextPage;
			private GameObject backToHistoryFromHPI;
			private GameObject whoElseHaveYouSeenAboutThisProblem;
			private GameObject whatTreatmentsHaveBeenRecommendedForThisProblem;
			private GameObject whatMedicationsIncludingNonPrescriptionMedicationsHaveYouUsedForThisProblem;
			private GameObject haveYouHadAnyTestsRelatedToThisProblem;
			private GameObject isThereAnythingElseBotheringYou;
			private GameObject hpiPrevousPage;

			// Past Medical History
			private GameObject whatMedicalConditionsHaveYouBeenDiagnosedWith;
			private GameObject haveYouEverHadAnyOperations;
			private GameObject whatDiseasesHaveYouHadAsAChild;
			private GameObject whatPrescriptionMedicationsDoYouTake;
			private GameObject doYouTakeAnyOverTheCounterMedications;
			private GameObject areYouAllergicToAnyMedications;
			private GameObject areYouAdherentWithYourMedications;
			private GameObject backToHistoryFromPMH;

			// Family History
			private GameObject wereYouAdopted;
			private GameObject tellMeAboutYourParentsHealth;
			private GameObject didAnyoneInYourFamilyIncludingGrandparentsDieAtAYoungAge;
			private GameObject whatWasTheCauseOfDeath;
			private GameObject doAnyMembersOfYourFamilyHaveBloodClottingProblems;
			private GameObject isThereAnyHistoryOfCancerInYourFamily;
			private GameObject doAnyMembersOfYourFamilyHaveHeartProblems;
			private GameObject isThereAnyHistoryOfAutoimmuneDisordersInYourFamily;
			private GameObject areThereAnyOtherChronicMedicalConditionsThatRunInYourFamily;
			private GameObject backToHistoryFromFH;

			// Social History
			private GameObject describeYourLifestyleAndWhereYouAreLiving;
			private GameObject AreYouCurrentlyEmployed;
			private GameObject whatIsYourMaritalStatus;
			private GameObject isYourPreferredSexualPartnerOfTheOppositeSexOrTheSameSex;
			private GameObject whoLivesAtHomeWithYou;
			private GameObject doYouDrinkAnyAlcohol;
			private GameObject howMuchDoYouDrinkInAWeek;
			private GameObject HaveYouEverThoughtAboutCuttingDown;
			private GameObject doYouSmoke;
			private GameObject howManyYearsHaveYouSmoked;
			private GameObject shNextPage;
			private GameObject backToHistoryFromSH;
			private GameObject howManyPacksPerDayHaveYouSmoked;
			private GameObject haveyoueverthoughtaboutquitting;
			private GameObject doYouDoAnyIllicitOrRecreationalDrugs;
			private GameObject whichDrugsDoYouUseAndHowFrequentlyDoYouUseThem;
			private GameObject haveYouEverTriedToQuitUsingDrugsOrHaveBeenInADetoxificationProgram;
			private GameObject whereWereYouBorn;
			private GameObject whatIsYourFinancialSituation;
			private GameObject howActiveAreYou;
			private GameObject shPreviousPage;

			// Review of Systems

	// Physical
	private GameObject heent;
	private GameObject card;
	private GameObject pulm;
	private GameObject abd;
	private GameObject neuro;
	private GameObject msk;
	private GameObject skin;
	private GameObject backPhysical;

	// Labs
	private GameObject blood;
	private GameObject urine;
	private GameObject csf;
	private GameObject backLabs;

	// Blood
	private GameObject cbc;
	private GameObject bmp;
	private GameObject lft;
	private GameObject coags;
	private GameObject backBlood;

	// Imaging
	private GameObject xray;
	private GameObject ct;
	private GameObject mri;
	private GameObject us;
	private GameObject pet;
	private GameObject backImaging;

	// Proceed from viewing imaging
	private GameObject proceedAfterImaging;

	// Other random things

	public DifferentialManager differentialManager;
	public bool victory = false;
	public bool displayImage = false;
	public bool isFirstTurn = true;

	private DialogueManager dialogueManager;
	private LevelManager levelManager;
	private Canvas menuCanvas;
	private string imageToDisplay;

	// Use this for initialization
	void Start () {
		// Boring menu button identifiers

		// Main Menu
		history = GameObject.Find ("History");
		physical = GameObject.Find ("Physical");
		labs = GameObject.Find ("Labs");
		imaging = GameObject.Find ("Imaging");
		ddx = GameObject.Find ("DDX");

			// History
			hpi = GameObject.Find("HPI");
			pmh = GameObject.Find ("PMH");
			fh = GameObject.Find ("FH");
			sh = GameObject.Find ("SH");
			ros = GameObject.Find ("ROS");
			backToMainFromHistory = GameObject.Find ("Back to Main from History");

				// History of Present Illness
				whenWereYouLastCompletelyWell = GameObject.Find("When were you last completely well");
				whenDidThePainFirstStart = GameObject.Find("When did the pain first start");
				howWouldYouDescribeYourPain = GameObject.Find("How would you describe your pain");
				whereIsThePainLocated = GameObject.Find("Where is the pain located");
				doesThePainMoveAnywhere = GameObject.Find("Does the pain move anywhere");
				howDidThePainFirstStart = GameObject.Find("How did the pain first start");
				howSevereIsYourPain = GameObject.Find("How severe is your pain");
				haveYouEverHadASimilarPainInThePast = GameObject.Find("Have you ever had a similar pain in the past");
				doesAnythingMakeThePainBetterOrWorse = GameObject.Find("Does anything make the pain better or worse");
				whatHasBeenTheImpactOfThisProblemOnYourLife = GameObject.Find("What has been the impact of this problem on your life");
				hpiNextPage = GameObject.Find("HPI Next Page");
				backToHistoryFromHPI = GameObject.Find ("Back to History from HPI");			
				whoElseHaveYouSeenAboutThisProblem = GameObject.Find("Who else have you seen about this problem");
				whatTreatmentsHaveBeenRecommendedForThisProblem = GameObject.Find("What treatments have been recommended for this problem");
				whatMedicationsIncludingNonPrescriptionMedicationsHaveYouUsedForThisProblem = GameObject.Find("What medications, including non-prescription medications, have you used for this problem");
				haveYouHadAnyTestsRelatedToThisProblem = GameObject.Find("Have you had any tests related to this problem");
				isThereAnythingElseBotheringYou = GameObject.Find("Is there anything else bothering you");
				hpiPrevousPage = GameObject.Find("HPI Previous Page");

				// Past Medical History
				whatMedicalConditionsHaveYouBeenDiagnosedWith = GameObject.Find("What medical conditions have you been diagnosed with");
				haveYouEverHadAnyOperations = GameObject.Find("Have you ever had any operations");
				whatDiseasesHaveYouHadAsAChild = GameObject.Find("What diseases have you had as a child");
				whatPrescriptionMedicationsDoYouTake = GameObject.Find("What prescription medications do you take");
				doYouTakeAnyOverTheCounterMedications = GameObject.Find("Do you take any over-the-counter medications");
				areYouAllergicToAnyMedications = GameObject.Find("Are you allergic to any medications");
				areYouAdherentWithYourMedications = GameObject.Find("Are you adherent with your medications");
				backToHistoryFromPMH = GameObject.Find("Back to History from PMH");

				// Family History
				wereYouAdopted = GameObject.Find("Were you adopted");
				tellMeAboutYourParentsHealth = GameObject.Find("Tell me about your parents health");
				didAnyoneInYourFamilyIncludingGrandparentsDieAtAYoungAge = GameObject.Find("Did anyone in your family, including grandparents, die at a young age");
				whatWasTheCauseOfDeath = GameObject.Find("What was the cause of death");
				doAnyMembersOfYourFamilyHaveBloodClottingProblems = GameObject.Find("Do any members of your family have blood clotting problems");
				isThereAnyHistoryOfCancerInYourFamily = GameObject.Find("Is there any history of cancer in your family");
				doAnyMembersOfYourFamilyHaveHeartProblems = GameObject.Find("Do any members of your family have heart problems");
				isThereAnyHistoryOfAutoimmuneDisordersInYourFamily = GameObject.Find("Is there any history of autoimmune disorders in your family");
				areThereAnyOtherChronicMedicalConditionsThatRunInYourFamily = GameObject.Find("Are there any other chronic medical conditions that run in your family");
				backToHistoryFromFH = GameObject.Find("Back to History from FH");

		// Other things to identify

		dialogueManager = FindObjectOfType<DialogueManager> ();
		levelManager = FindObjectOfType<LevelManager> ();
		menuCanvas = GetComponentInParent<Canvas> ();

		// Actual initialization

		foreach (Transform child in transform) {child.gameObject.SetActive (false);}

	}

	public void Reset () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
	}

	public void NewTurn () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}

		// Destroys an image, if there is one
		if (GameObject.Find ("Image") != null) {
			Destroy (GameObject.Find ("Image"));
		}

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

	public void FirstTurn() {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		differentialManager.Enable ();
		isFirstTurn = false;
		dialogueManager.LineStart (91);
		dialogueManager.LineBreak (91);
		dialogueManager.NewTalk ();
	}

	public void HasImage(string imageType){
		displayImage = true;
		imageToDisplay = imageType;
	}

	public void DisplayImage(){
		Debug.Log ("Image to display: " + imageToDisplay);
		GameObject image = new GameObject ("Image");
		image.transform.SetParent (menuCanvas.transform);
		image.AddComponent<RectTransform> ();
		image.AddComponent<CanvasRenderer> ();
		image.GetComponent<RectTransform> ().anchorMin = new Vector2 (0.5f, 0.5f);
		image.GetComponent<RectTransform> ().anchorMax = new Vector2 (0.5f, 0.5f);
		image.GetComponent<RectTransform> ().pivot = new Vector2 (0.5f, 0.5f);
		image.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 0, 0);
		image.GetComponent<RectTransform> ().sizeDelta = new Vector2 (450f, 450f);
		image.AddComponent<Image> ();
//		if (imageToDisplay == "xray") {
//			image.GetComponent<Image> ().sprite = disease.xray;
//		} else if (imageToDisplay == "ct") {
//			image.GetComponent<Image> ().sprite = disease.ct;
//		} else if (imageToDisplay == "mri") {
//			image.GetComponent<Image> ().sprite = disease.mri;
//		} else if (imageToDisplay == "us") {
//			image.GetComponent<Image> ().sprite = disease.us;
//		} else if (imageToDisplay == "pet") {
//			image.GetComponent<Image> ().sprite = disease.pet;
//		} else if (imageToDisplay == null) {
//			Debug.LogError ("No sprite exists for this image type");
//		}
		proceedAfterImaging.SetActive (true);
		displayImage = false;
	}

	// Boring menu navigation below

	public void History () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		hpi.SetActive (true);
		pmh.SetActive (true);
		sh.SetActive (true);
		fh.SetActive (true);
		ros.SetActive (true);
		backToMainFromHistory.SetActive (true);
	}

	public void HPIPage1 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		whenWereYouLastCompletelyWell.SetActive (true);
		whenDidThePainFirstStart.SetActive (true);
		howWouldYouDescribeYourPain.SetActive (true);
		whereIsThePainLocated.SetActive (true);
		doesThePainMoveAnywhere.SetActive (true);
		howDidThePainFirstStart.SetActive (true);
		howSevereIsYourPain.SetActive (true);
		haveYouEverHadASimilarPainInThePast.SetActive (true);
		doesAnythingMakeThePainBetterOrWorse.SetActive (true);
		whatHasBeenTheImpactOfThisProblemOnYourLife.SetActive (true);
		hpiNextPage.SetActive (true);
		backToHistoryFromHPI.SetActive (true);
	}

	public void HPIPage2 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		whoElseHaveYouSeenAboutThisProblem.SetActive (true);
		whatTreatmentsHaveBeenRecommendedForThisProblem.SetActive (true);
		whatMedicationsIncludingNonPrescriptionMedicationsHaveYouUsedForThisProblem.SetActive (true);
		haveYouHadAnyTestsRelatedToThisProblem.SetActive (true);
		isThereAnythingElseBotheringYou.SetActive (true);
		hpiPrevousPage.SetActive (true);
	}

	public void PMH () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		whatMedicalConditionsHaveYouBeenDiagnosedWith.SetActive(true);
		haveYouEverHadAnyOperations.SetActive(true);
		whatDiseasesHaveYouHadAsAChild.SetActive(true);
		whatPrescriptionMedicationsDoYouTake.SetActive(true);
		doYouTakeAnyOverTheCounterMedications.SetActive(true);
		areYouAllergicToAnyMedications.SetActive(true);
		areYouAdherentWithYourMedications.SetActive(true);
		backToHistoryFromPMH.SetActive(true);
	}

	public void FH () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		wereYouAdopted.SetActive(true);
		tellMeAboutYourParentsHealth.SetActive(true);
		didAnyoneInYourFamilyIncludingGrandparentsDieAtAYoungAge.SetActive(true);
		whatWasTheCauseOfDeath.SetActive(true);
		doAnyMembersOfYourFamilyHaveBloodClottingProblems.SetActive(true);
		isThereAnyHistoryOfCancerInYourFamily.SetActive(true);
		doAnyMembersOfYourFamilyHaveHeartProblems.SetActive(true);
		isThereAnyHistoryOfAutoimmuneDisordersInYourFamily.SetActive(true);
		areThereAnyOtherChronicMedicalConditionsThatRunInYourFamily.SetActive(true);
		backToHistoryFromFH.SetActive(true);
	}

	public void Physical () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		heent.SetActive (true);
		card.SetActive (true);
		pulm.SetActive (true);
		abd.SetActive (true);
		neuro.SetActive (true);
		msk.SetActive (true);
		skin.SetActive (true);
		backPhysical.SetActive (true);
	}

	public void Labs () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		blood.SetActive (true);
		urine.SetActive (true);
		csf.SetActive (true);
		backLabs.SetActive (true);
	}

	public void Blood () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		cbc.SetActive (true);
		bmp.SetActive (true);
		lft.SetActive (true);
		coags.SetActive (true);
		backBlood.SetActive (true);
	}

	public void Imaging () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		xray.SetActive (true);
		ct.SetActive (true);
		mri.SetActive (true);
		us.SetActive (true);
		pet.SetActive (true);
		backImaging.SetActive (true);
	}

}
