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
			private GameObject haveYouEverThoughtAboutCuttingDown;
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
			private GameObject generalROS;
			private GameObject musculoskeletalROS;
			private GameObject psychiatricROS;
			private GameObject respiratoryROS;
			private GameObject cardiovascularROS;
			private GameObject gastrointestinalROS;
			private GameObject neurologicROS;
			private GameObject hematologicROS;
			private GameObject endocrineROS;
			private GameObject genitourinaryROS;
			private GameObject oropharynxROS;
			private GameObject noseAndSinusROS;
			private GameObject earsROS;
			private GameObject eyesROS;
			private GameObject headROS;
			private GameObject dermatologicROS;
			private GameObject backToHistoryFromROS;

				// General
				private GameObject howAreYourEnergyLevels;
				private GameObject haveYouNoticedAnySignificantWeightGain;
				private GameObject haveYouNoticedAnySignificantWeightLoss;
				private GameObject doYouHaveAnyDifficultySleeping;
				private GameObject haveYouExperiencedAnyFeversOrChills;
				private GameObject haveYouExperiencedAnyDrenchingNightSweats;
				private GameObject backToROSFromGeneralROS;
				
				//Musculoskeletal
				private GameObject doYouHaveAnyPainsStiffnessOrSwellingInYourJoints;
				private GameObject doYouHaveBackaches;
				private GameObject doYouHavePainsInYourLegs;
				private GameObject doYouHavePainsOrCrampsinYourMuscles;
				private GameObject backToROSFromMSKROS;			

				//Psychiatric
				private GameObject doYouFeelNervous;
				private GameObject doYouFeelAnxious;
				private GameObject doYouFeelDepressed;
				private GameObject backToROSFromPsychROS;			

				//Respiratory
				private GameObject doYouEverFeelShortOfBreathOnExertion;
				private GameObject hasYourBreathingChangedOverThePastMonth;
				private GameObject doYouSufferFromACough;
				private GameObject isYourCoughProductive;
				private GameObject whatColorIsTheSputum;
				private GameObject haveYouTraveledAnywhereOutsideOfTheCountryRecently;
				private GameObject didYouTravelByAirplaneForLongDistances;
				private GameObject haveYouBeenInContactWithAnyIndividualsWhoAreSick;
				private GameObject doYouWorkInOrFrequentlyVisitAHealthCareFacility;
				private GameObject haveYouEverLivedInAShelterOrPrison;
				private GameObject respROSNextPage;
				private GameObject backToROSFromRespROS;
				private GameObject haveYouEverWorkedInAShipyard;
				private GameObject haveYouEverBeenExposedOrInContactWithAnIndividualWhoIsDiagnosedWithTuberculosis;
				private GameObject haveYouEverHadATuberculosisSkinTest;
				private GameObject respROSPreviousPage;

				//Cardiovascular
				private GameObject haveYouEverExperiencedChestPainOnExertionBefore;
				private GameObject doYouExperiencePalpitations;
				private GameObject haveYouEverHadAHeartAttack;
				private GameObject haveYouNoticedAnySwellingInYourAnkles;
				private GameObject haveYouNoticedAnyChangeInWaistCircumference;
				private GameObject doYouEverWakeUpInTheMiddleOfTheNightGaspingForAir;
				private GameObject doYouExperienceAnyDifficultyWithYourBreathingWhenYouLieFlat;
				private GameObject howManyPillowsDoYouSleepWithAtNight;
				private GameObject haveYouEverFainted;
				private GameObject haveYouExperiencedAnyPainInYourLegsWhileWalking;
				private GameObject cardROSNextPage;
				private GameObject backToROSFromCardROS;
				private GameObject doYourLegsFeelCold;
				private GameObject isThereAnyHistoryInYourFamilyOfSuddenCardiacDeath;
				private GameObject haveYouRecentlyHadAColdOrFlu;
				private GameObject haveYouEverBeenToldYouHaveAHeartMurmur;
				private GameObject didYouEverHaveRheumaticHeartDiseaseAsAChild;
				private GameObject cardROSPrevousPage;
				
				//Gastrointestinal
				private GameObject howIsYourAppetite;
				private GameObject doesFoodEverGetStuckInYourThroat;
				private GameObject doYouEverExperiencePainWhileSwallowing;
				private GameObject doYouHaveDifficultySwallowingSolidsOrLiquidsOrBoth;
				private GameObject doYouSufferFromHeartBurn;
				private GameObject haveYouEverFeltThatYouGetFullReallyQuicklyDuringMeals;
				private GameObject haveYouExperiencedAnyNauseaOrVomiting;
				private GameObject haveYouExperiencedAnyAbdominalBloating;
				private GameObject haveYouHadAnyDiarrhea;
				private GameObject haveYouHadAnyConstipation;
				private GameObject giROSToPage2;
				private GameObject backToROSFromGIROS;
				private GameObject haveYouEverHadAnyBloodInYourStool;
				private GameObject haveYouEverHadAnyBlackTarryStools;
				private GameObject doYouExperienceAnyPainWhilePassingBowelMovements;
				private GameObject doYouEverHaveAnyPaleFattyStools;
				private GameObject haveYouTakenAnyAntibioticsRecently;
				private GameObject areYourStoolsFoulSmelling;
				private GameObject haveYouEverVomitedBlood;
				private GameObject wasItBrightRedBlood;
				private GameObject didItLookLikeCoffeeGrounds;
				private GameObject haveYouEverHadAColonoscopy;
				private GameObject giROSToPage3;
				private GameObject backToGIROSPage1;
				private GameObject haveYouEverHadAGastroscopy;
				private GameObject haveYouHadAnyRecentTravelOutsideOfTheCountry;
				private GameObject haveYouNoticedAnyYellowingOfTheEyesOrSkin;
				private GameObject haveYouExperiencedAnyEasyBruisingOrBleeding;
				private GameObject haveYouNoticedAnyEnlargementofYourBreastTissue;
				private GameObject haveYouNoticedAnyMuscleWasting;
				private GameObject backToGIROSPage2;
			
				//Neurologic
				private GameObject haveYouEverHadAStroke;
				private GameObject WasItDueToABloodClotOrABleed;
				private GameObject DoYouHaveAnyResidualSymptoms;
				private GameObject haveYouEverHadASeizure;
				private GameObject haveYouExperiencedDoubleVision;
				private GameObject haveYouExperiencedBlurredVision;
				private GameObject haveYouOrOthersNoticedAnyAsymmetryInYourFace;
				private GameObject haveYouExperiencedAnySlurringOfYourSpeech;
				private GameObject haveYouExperiencedAnyNumbnessOrTinglingInYourBody;
				private GameObject haveYouExperiencedAnyWeaknessOnOneSideOfYourBody;
				private GameObject neuroROSToPage2;
				private GameObject backToROSFromNeuroROS;
				private GameObject haveYouEverLostControlOfYourBowelsOrBladder;
				private GameObject doYouUseAnyWalkingAids;
				private GameObject doYouHaveDifficultyButtoningYourShirts;
				private GameObject haveYouNoticedATremor;
				private GameObject haveYouHadAnyProblemsWithBalanceOrCoordination;
				private GameObject haveYouNoticedAnyChangesInYourVoice;
				private GameObject doYouFindThatYouChokeOrCoughWhenYouEatOrDrink;
				private GameObject haveYouNoticedAnyChangesWithYourMemory;
				private GameObject haveYouEverLeftTheTapOrTheStoveOnInYourHouse;
				private GameObject doYouDriveACar;
				private GameObject neuroROSToPage3;
				private GameObject backToNeuroROSPage1;
				private GameObject doYouSufferFromAnyHeadache;
				private GameObject isItTheWorstHeadacheYouveEverDad;
				private GameObject haveYouHadAnyAssociatedNauseaOrVomiting;
				private GameObject haveYouExperiencedAnyScalpTendernessOrPainInYourJaw;
				private GameObject backToNeuroROSPage2;
			
				//Hematologic
				private GameObject howDifficultIsItToStopBleedingWhenYouHaveASmallCut;
				private GameObject doYouHaveAnemia;
				private GameObject haveYouEverHadABloodTransfusion;
				private GameObject didYouExperienceAnyProblemsWithTheBloodTransfusion;
				private GameObject doYouBruiseEasily;
				private GameObject backToROSFromHemeROS;
			
				//Endocrine
				private GameObject howWellDoYouTolerateTheHeat;
				private GameObject howWellDoYouTolerateTheCold;
				private GameObject doYouUrinateFrequently;
				private GameObject areYouExcessivelyHungry;
				private GameObject areYouExcessivelyThirsty;
				private GameObject doYouSweatExcessively;
				private GameObject haveYouNoticedAnyChangesToYourSkinOrHair;
				private GameObject backToROSFromEndoROS;
		
				//Genitourinary
				private GameObject doYouHaveAnyPainOnUrination;
				private GameObject haveYouExperiencedAnIncreasedFrequencyInUrinating;
				private GameObject howOftenDoYouUrinateAtNight;
				private GameObject doYouOftenFeelTheUrgeToUrinate;
				private GameObject doYouFindItDifficultToBeginUrinating;
				private GameObject haveYouEverHadBloodInYourUrine;
				private GameObject isYourUrineFoamy;
				private GameObject haveYouBeenExperiencingAnyFlankPain;
				private GameObject haveYouNoticedAnySkinChangesToYourExternalGenitalia;
				private GameObject backToROSFromGUROS;	

				//Oropharynx
				private GameObject haveYouExperiencedAnyChangeInYourVoice;
				private GameObject doYouGetFrequentSoreThroats;
				private GameObject doYouHaveAnyProblemsWithYourTeethOrGums;
				private GameObject doYouHaveAnyBleedingInYourMouth;
				private GameObject backToROSFromOropharynxROS;
			
				//NoseandSinus
				private GameObject howOftenDoYouHaveNosebleeds;
				private GameObject doYouHaveAnyDischargeFromYourNose;
				private GameObject doYouHaveDifficultyBreathingThroughYourNose;
				private GameObject haveYouHadARecentColdOrInfectionInYourSinuses;
				private GameObject backToROSFromNoseSinusROS;
		
				//Ears
				private GameObject doYouHaveProblemsHearing;
				private GameObject haveYouExperiencedARingingInYourEars;
				private GameObject doYouHaveEaraches;
				private GameObject haveYouHadAnInfectionOrDischargeFromYourEars;
				private GameObject backToROSFromEarsROS;
			
				//Eyes
				private GameObject doYouWearGlassesOrContactLenses;
				private GameObject whenWasYourLastEyeExamination;
				private GameObject haveYouHadAnyRecentChangesToYourVision;
				private GameObject doYouHaveExcessiveTearingInYourEyes;
				private GameObject haveYouHadAnyPainOrRednessInYourEyes;
				private GameObject backToROSFromEyesROS;
			
				//Head
				private GameObject haveYouHadAnyInjuryToYourHead;
				private GameObject haveYouHadAStiffNeck;
				private GameObject backToROSFromHeadROS;
			
				//Dermatologic
				private GameObject doYouHaveAnyLumpsOnYourSkin;
				private GameObject doYouHaveAnyRashesOnYourSkin;
				private GameObject doYouHaveAnyItchingOrDrySkin;
				private GameObject haveYouNoticedAnyChangesToYourFingernails;
				private GameObject haveYouNoticedAnyChangesToYourHairGrowth;
				private GameObject backToROSFromDermROS;

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

				// Social History
				describeYourLifestyleAndWhereYouAreLiving = GameObject.Find("Describe your lifestyle and where you are living");
				AreYouCurrentlyEmployed = GameObject.Find("Are you currently employed");
				whatIsYourMaritalStatus = GameObject.Find("What is your marital status");
				isYourPreferredSexualPartnerOfTheOppositeSexOrTheSameSex = GameObject.Find("Is your preferred sexual partner of the opposite sex or the same sex");
				whoLivesAtHomeWithYou = GameObject.Find("Who lives at home with you");
				doYouDrinkAnyAlcohol = GameObject.Find("Do you drink any alcohol");
				howMuchDoYouDrinkInAWeek = GameObject.Find("How much do you drink in a week");
				haveYouEverThoughtAboutCuttingDown = GameObject.Find("Have you ever thought about cutting down");
				doYouSmoke = GameObject.Find("Do you smoke");
				howManyYearsHaveYouSmoked = GameObject.Find("How many years have you smoked");
				shNextPage = GameObject.Find("SH Next Page");
				backToHistoryFromSH = GameObject.Find("Back to History from SH");
				howManyPacksPerDayHaveYouSmoked = GameObject.Find("How many packs per day have you smoked");
				haveyoueverthoughtaboutquitting = GameObject.Find("Have you ever thought about quitting");
				doYouDoAnyIllicitOrRecreationalDrugs = GameObject.Find("Do you do any illicit or recreational drugs");
				whichDrugsDoYouUseAndHowFrequentlyDoYouUseThem = GameObject.Find("Which drugs do you use and how frequently do you use them");
				haveYouEverTriedToQuitUsingDrugsOrHaveBeenInADetoxificationProgram = GameObject.Find("Have you ever tried to quit using drugs or have been in a detoxification program");
				whereWereYouBorn = GameObject.Find("Where were you born");
				whatIsYourFinancialSituation = GameObject.Find("What is your financial situation");
				howActiveAreYou = GameObject.Find("How active are you");
				shPreviousPage = GameObject.Find("SH Previous Page");

				// Review of Systems
				generalROS = GameObject.Find("General ROS");
				musculoskeletalROS = GameObject.Find("MSK ROS");
				psychiatricROS = GameObject.Find("Psych ROS");
				respiratoryROS = GameObject.Find("Resp ROS");
				cardiovascularROS = GameObject.Find("Card ROS");
				gastrointestinalROS = GameObject.Find("GI ROS");
				neurologicROS = GameObject.Find("Neuro ROS");
				hematologicROS = GameObject.Find("Heme ROS");
				endocrineROS = GameObject.Find("Endo ROS");
				genitourinaryROS = GameObject.Find("GU ROS");
				oropharynxROS = GameObject.Find("Oropharynx ROS");
				noseAndSinusROS = GameObject.Find("Nose and Sinus ROS");
				earsROS = GameObject.Find("Ears ROS");
				eyesROS = GameObject.Find("Eyes ROS");
				headROS = GameObject.Find("Head ROS");
				dermatologicROS = GameObject.Find("Derm ROS");
				backToHistoryFromROS = GameObject.Find("Back to History from ROS");

					// General
					howAreYourEnergyLevels = GameObject.Find("How are your energy levels");
					haveYouNoticedAnySignificantWeightGain = GameObject.Find("Have you noticed any significant weight gain");
					haveYouNoticedAnySignificantWeightLoss = GameObject.Find("Have you noticed any significant weight loss");
					doYouHaveAnyDifficultySleeping = GameObject.Find("Do you have any difficulty sleeping");
					haveYouExperiencedAnyFeversOrChills = GameObject.Find("Have you experienced any fevers or chills");
					haveYouExperiencedAnyDrenchingNightSweats = GameObject.Find("Have you experienced any drenching night sweats");
					backToROSFromGeneralROS = GameObject.Find ("Back to ROS from General ROS");

					//Musculoskeletal
					doYouHaveAnyPainsStiffnessOrSwellingInYourJoints = GameObject.Find("Do you have any pains, stiffness, or swelling in your joints");
					doYouHaveBackaches = GameObject.Find("Do you have backaches");
					doYouHavePainsInYourLegs = GameObject.Find("Do you have pains in your legs");
					doYouHavePainsOrCrampsinYourMuscles = GameObject.Find("Do you have pains or cramps in your muscles");
					backToROSFromMSKROS = GameObject.Find ("Back to ROS from MSK ROS");

					//Psychiatric
					doYouFeelNervous = GameObject.Find("Do you feel nervous");
					doYouFeelAnxious = GameObject.Find("Do you feel anxious");
					doYouFeelDepressed = GameObject.Find("Do you feel depressed");
					backToROSFromPsychROS = GameObject.Find ("Back to ROS from Psych ROS");

					//Respiratory
					doYouEverFeelShortOfBreathOnExertion = GameObject.Find("Do you ever feel short of breath on exertion");
					hasYourBreathingChangedOverThePastMonth = GameObject.Find("Has your breathing changed over the past month");
					doYouSufferFromACough = GameObject.Find("Do you suffer from a cough");
					isYourCoughProductive = GameObject.Find("Is your cough productive");
					whatColorIsTheSputum = GameObject.Find("What color is the sputum");
					haveYouTraveledAnywhereOutsideOfTheCountryRecently = GameObject.Find("Have you traveled anywhere outside of the country recently");
					didYouTravelByAirplaneForLongDistances = GameObject.Find("Did you travel by airplane for long distances");
					haveYouBeenInContactWithAnyIndividualsWhoAreSick = GameObject.Find("Have you been in contact with any individuals who are sick");
					doYouWorkInOrFrequentlyVisitAHealthCareFacility = GameObject.Find("Do you work in or frequently visit a healthcare facility");
					haveYouEverLivedInAShelterOrPrison = GameObject.Find("Have you ever lived in a shelter or prison");
					respROSNextPage = GameObject.Find ("Resp ROS Next Page");
					backToROSFromRespROS = GameObject.Find ("Back to ROS from Resp ROS");
					haveYouEverWorkedInAShipyard = GameObject.Find("Have you ever worked in a shipyard");
					haveYouEverBeenExposedOrInContactWithAnIndividualWhoIsDiagnosedWithTuberculosis = GameObject.Find("Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis");
					haveYouEverHadATuberculosisSkinTest = GameObject.Find("Have you ever had a tuberculosis skin test");
					respROSPreviousPage = GameObject.Find("Resp ROS Previous Page");

					//Cardiovascular
					haveYouEverExperiencedChestPainOnExertionBefore = GameObject.Find("Have you ever experienced chest pain on exertion before");
					doYouExperiencePalpitations = GameObject.Find("Do you experience palpitations");
					haveYouEverHadAHeartAttack = GameObject.Find("Have you ever had a heart attack");
					haveYouNoticedAnySwellingInYourAnkles = GameObject.Find("Have you noticed any swelling in your ankles");
					haveYouNoticedAnyChangeInWaistCircumference = GameObject.Find("Have you noticed any change in waist circumference");
					doYouEverWakeUpInTheMiddleOfTheNightGaspingForAir = GameObject.Find("Do you ever wake up in the middle of the night gasping for air");
					doYouExperienceAnyDifficultyWithYourBreathingWhenYouLieFlat = GameObject.Find("Do you experience any difficulty with your breathing when you lie flat");
					howManyPillowsDoYouSleepWithAtNight = GameObject.Find("How many pillows do you sleep with at night");
					haveYouEverFainted = GameObject.Find("Have you ever fainted");
					haveYouExperiencedAnyPainInYourLegsWhileWalking = GameObject.Find("Have you experienced any pain in your legs while walking");
					cardROSNextPage = GameObject.Find("Card ROS Next Page");
					backToROSFromCardROS = GameObject.Find("Back to ROS from Card ROS");
					doYourLegsFeelCold = GameObject.Find("Do your legs feel cold");
					isThereAnyHistoryInYourFamilyOfSuddenCardiacDeath = GameObject.Find("Is there any history in your family of sudden cardiac death");
					haveYouRecentlyHadAColdOrFlu = GameObject.Find("Have you recently had a cold or flu");
					haveYouEverBeenToldYouHaveAHeartMurmur = GameObject.Find("Have you ever been told you have a heart murmur");
					didYouEverHaveRheumaticHeartDiseaseAsAChild = GameObject.Find("Did you ever have rheumatic heart disease as a child");
					cardROSPrevousPage = GameObject.Find("Card ROS Previous Page");

					//Gastrointestinal
					howIsYourAppetite = GameObject.Find("How is your appetite");
					doesFoodEverGetStuckInYourThroat = GameObject.Find("Does food ever get stuck in your throat");
					doYouEverExperiencePainWhileSwallowing = GameObject.Find("Do you ever experience pain while swallowing");
					doYouHaveDifficultySwallowingSolidsOrLiquidsOrBoth = GameObject.Find("Do you have difficulty swallowing solids, or liquids, or both");
					doYouSufferFromHeartBurn = GameObject.Find("Do you suffer from heartburn");
					haveYouEverFeltThatYouGetFullReallyQuicklyDuringMeals = GameObject.Find("Have you ever felt that you get full really quickly during meals");
					haveYouExperiencedAnyNauseaOrVomiting = GameObject.Find("Have you experienced any nausea or vomiting");
					haveYouExperiencedAnyAbdominalBloating = GameObject.Find("Have you experienced any abdominal bloating");
					haveYouHadAnyDiarrhea = GameObject.Find("Have you had any diarrhea");
					haveYouHadAnyConstipation = GameObject.Find("Have you had any constipation");
					giROSToPage2 = GameObject.Find("GI ROS to Page 2");
					backToROSFromGIROS = GameObject.Find("Back to ROS from GI ROS");
					haveYouEverHadAnyBloodInYourStool = GameObject.Find("Have you ever had any blood in your stool");
					haveYouEverHadAnyBlackTarryStools = GameObject.Find("Have you ever had any black, tarry stools");
					doYouExperienceAnyPainWhilePassingBowelMovements = GameObject.Find("Do you experience any pain while passing bowel movements");
					doYouEverHaveAnyPaleFattyStools = GameObject.Find("Do you ever have any pale, fatty stools");
					haveYouTakenAnyAntibioticsRecently = GameObject.Find("Have you taken any antibiotics recently");
					areYourStoolsFoulSmelling = GameObject.Find("Are your stools foul-smelling");
					haveYouEverVomitedBlood = GameObject.Find("Have you ever vomited blood");
					wasItBrightRedBlood = GameObject.Find("Was it bright red blood");
					didItLookLikeCoffeeGrounds = GameObject.Find("Did it look like coffee grounds");
					haveYouEverHadAColonoscopy = GameObject.Find("Have you ever had a colonoscopy");
					giROSToPage3 = GameObject.Find("GI ROS to Page 3");
					backToGIROSPage1 = GameObject.Find("Back to GI ROS Page 1");
					haveYouEverHadAGastroscopy = GameObject.Find("Have you ever had a gastroscopy");
					haveYouHadAnyRecentTravelOutsideOfTheCountry = GameObject.Find("Have you had any recent travel outside of the country");
					haveYouNoticedAnyYellowingOfTheEyesOrSkin = GameObject.Find("Have you noticed any yellowing of the eyes or skin");
					haveYouExperiencedAnyEasyBruisingOrBleeding = GameObject.Find("Have you experienced any easy bruising or bleeding");
					haveYouNoticedAnyEnlargementofYourBreastTissue = GameObject.Find("Have you noticed any enlargement of your breast tissue");
					haveYouNoticedAnyMuscleWasting = GameObject.Find("Have you noticed any muscle wasting");
					backToGIROSPage2 = GameObject.Find("Back to GI ROS Page 2");

					//Neurologic
					haveYouEverHadAStroke = GameObject.Find("Have you ever had a stroke");
					WasItDueToABloodClotOrABleed = GameObject.Find("Was it due to a blood clot or a bleed");
					DoYouHaveAnyResidualSymptoms = GameObject.Find("Do you have any residual symptoms");
					haveYouEverHadASeizure = GameObject.Find("Have you ever had a seizure");
					haveYouExperiencedDoubleVision = GameObject.Find("Have you experienced double-vision");
					haveYouExperiencedBlurredVision = GameObject.Find("Have you experienced blurred vision");
					haveYouOrOthersNoticedAnyAsymmetryInYourFace = GameObject.Find("Have you or others noticed any asymmetry in your face");
					haveYouExperiencedAnySlurringOfYourSpeech = GameObject.Find("Have you experienced any slurring of your speech");
					haveYouExperiencedAnyNumbnessOrTinglingInYourBody = GameObject.Find("Have you experienced any numbness or tingling in your body");
					haveYouExperiencedAnyWeaknessOnOneSideOfYourBody = GameObject.Find("Have you experienced any weakness on one side of your body");
					neuroROSToPage2 = GameObject.Find("Neuro ROS to Page 2");
					backToROSFromNeuroROS = GameObject.Find("Back to ROS from Neuro ROS");
					haveYouEverLostControlOfYourBowelsOrBladder = GameObject.Find("Have you ever lost control of your bowels or bladder");
					doYouUseAnyWalkingAids = GameObject.Find("Do you use any walking aids");
					doYouHaveDifficultyButtoningYourShirts = GameObject.Find("Do you have difficulty buttoning your shirts");
					haveYouNoticedATremor = GameObject.Find("Have you noticed a tremor");
					haveYouHadAnyProblemsWithBalanceOrCoordination = GameObject.Find("Have you had any problems with balance or coordination");
					haveYouNoticedAnyChangesInYourVoice = GameObject.Find("Have you noticed any changes in your voice");
					doYouFindThatYouChokeOrCoughWhenYouEatOrDrink = GameObject.Find("Do you find that you choke or cough when you eat or drink");
					haveYouNoticedAnyChangesWithYourMemory = GameObject.Find("Have you noticed any changes with your memory");
					haveYouEverLeftTheTapOrTheStoveOnInYourHouse = GameObject.Find("Have you ever left the tap or the stove on in your house");
					doYouDriveACar = GameObject.Find("Do you drive a car");
					neuroROSToPage3 = GameObject.Find("Neuro ROS to Page 3");
					backToNeuroROSPage1 = GameObject.Find("Back to Neuro ROS Page 1");
					doYouSufferFromAnyHeadache = GameObject.Find("Do you suffer from any headache");
					isItTheWorstHeadacheYouveEverDad = GameObject.Find("Is it the worst headache you’ve ever had");
					haveYouHadAnyAssociatedNauseaOrVomiting = GameObject.Find("Have you had any associated nausea or vomiting");
					haveYouExperiencedAnyScalpTendernessOrPainInYourJaw = GameObject.Find("Have you experienced any scalp tenderness or pain in your jaw");
					backToNeuroROSPage2 = GameObject.Find("Back to Neuro ROS Page 2");

					//Hematologic
					howDifficultIsItToStopBleedingWhenYouHaveASmallCut = GameObject.Find("How difficult is it to stop bleeding when you have a small cut");
					doYouHaveAnemia = GameObject.Find("Do you have anemia");
					haveYouEverHadABloodTransfusion = GameObject.Find("Have you ever had a blood transfusion");
					didYouExperienceAnyProblemsWithTheBloodTransfusion = GameObject.Find("Did you experience any problems with the blood transfusion");
					doYouBruiseEasily = GameObject.Find("Do you bruise easily");
					backToROSFromHemeROS = GameObject.Find("Back to ROS from Heme ROS");

					//Endocrine
					howWellDoYouTolerateTheHeat = GameObject.Find("How well do you tolerate the heat");
					howWellDoYouTolerateTheCold = GameObject.Find("How well do you tolerate the cold");
					doYouUrinateFrequently = GameObject.Find("Do you urinate frequently");
					areYouExcessivelyHungry = GameObject.Find("Are you excessively hungry");
					areYouExcessivelyThirsty = GameObject.Find("Are you excessively thirsty");
					doYouSweatExcessively = GameObject.Find("Do you sweat excessively");
					haveYouNoticedAnyChangesToYourSkinOrHair = GameObject.Find("Have you noticed any changes to your skin or hair");
					backToROSFromEndoROS = GameObject.Find("Back to ROS from Endo ROS");

					//Genitourinary
					doYouHaveAnyPainOnUrination = GameObject.Find("Do you have any pain on urination");
					haveYouExperiencedAnIncreasedFrequencyInUrinating = GameObject.Find("Have you experienced an increased frequency in urinating");
					howOftenDoYouUrinateAtNight = GameObject.Find("How often do you urinate at night");
					doYouOftenFeelTheUrgeToUrinate = GameObject.Find("Do you often feel the urge to urinate");
					doYouFindItDifficultToBeginUrinating = GameObject.Find("Do you find it difficult to begin urinating");
					haveYouEverHadBloodInYourUrine = GameObject.Find("Have you ever had blood in your urine");
					isYourUrineFoamy = GameObject.Find("Is your urine foamy");
					haveYouBeenExperiencingAnyFlankPain = GameObject.Find("Have you been experiencing any flank pain");
					haveYouNoticedAnySkinChangesToYourExternalGenitalia = GameObject.Find("Have you noticed any skin changes to your external genitalia");
					backToROSFromGUROS = GameObject.Find("Back to ROS from GU ROS");

					//Oropharynx
					haveYouExperiencedAnyChangeInYourVoice = GameObject.Find("Have you experienced any change in your voice");
					doYouGetFrequentSoreThroats = GameObject.Find("Do you get frequent sore throats");
					doYouHaveAnyProblemsWithYourTeethOrGums = GameObject.Find("Do you have any problems with your teeth or gums");
					doYouHaveAnyBleedingInYourMouth = GameObject.Find("Do you have any bleeding in your mouth");
					backToROSFromOropharynxROS = GameObject.Find("Back to ROS from Oropharynx ROS");

					//NoseandSinus
					howOftenDoYouHaveNosebleeds = GameObject.Find("How often do you have nosebleeds");
					doYouHaveAnyDischargeFromYourNose = GameObject.Find("Do you have any discharge from your nose");
					doYouHaveDifficultyBreathingThroughYourNose = GameObject.Find("Do you have difficulty breathing through your nose");
					haveYouHadARecentColdOrInfectionInYourSinuses = GameObject.Find("Have you had a recent cold or infection in your sinuses");
					backToROSFromNoseSinusROS = GameObject.Find("Back to ROS from Nose Sinus ROS");

					//Ears
					doYouHaveProblemsHearing = GameObject.Find("Do you have problems hearing");
					haveYouExperiencedARingingInYourEars = GameObject.Find("Have you experienced a ringing in your ears");
					doYouHaveEaraches = GameObject.Find("Do you have earaches");
					haveYouHadAnInfectionOrDischargeFromYourEars = GameObject.Find("Have you had an infection or discharge from your ears");
					backToROSFromEarsROS = GameObject.Find("Back to ROS from Ears ROS");

					//Eyes
					doYouWearGlassesOrContactLenses = GameObject.Find("Do you wear glasses or contact lenses");
					whenWasYourLastEyeExamination = GameObject.Find("When was your last eye examination");
					haveYouHadAnyRecentChangesToYourVision = GameObject.Find("Have you had any recent changes to your vision");
					doYouHaveExcessiveTearingInYourEyes = GameObject.Find("Do you have excessive tearing in your eyes");
					haveYouHadAnyPainOrRednessInYourEyes = GameObject.Find("Have you had any pain or redness in your eyes");
					backToROSFromEyesROS = GameObject.Find("Back to ROS from Eyes ROS");

					//Head
					haveYouHadAnyInjuryToYourHead = GameObject.Find("Have you had any injury to your head");
					haveYouHadAStiffNeck = GameObject.Find("Have you had a stiff neck");
					backToROSFromHeadROS = GameObject.Find("Back to ROS from Head ROS");

					//Dermatologic
					doYouHaveAnyLumpsOnYourSkin = GameObject.Find("Do you have any lumps on your skin");
					doYouHaveAnyRashesOnYourSkin = GameObject.Find("Do you have any rashes on your skin");
					doYouHaveAnyItchingOrDrySkin = GameObject.Find("Do you have any itching, or dry skin");
					haveYouNoticedAnyChangesToYourFingernails = GameObject.Find("Have you noticed any changes to your finger nails");
					haveYouNoticedAnyChangesToYourHairGrowth = GameObject.Find("Have you noticed any changes to your hair growth");
					backToROSFromDermROS = GameObject.Find("Back to ROS from Derm ROS");

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

	public void MainMenu () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		history.SetActive (true);
		physical.SetActive (true);
		labs.SetActive (true);
		imaging.SetActive (true);
		ddx.SetActive (true);
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

	public void SHPage1 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		describeYourLifestyleAndWhereYouAreLiving.SetActive(true);
		AreYouCurrentlyEmployed.SetActive(true);
		whatIsYourMaritalStatus.SetActive(true);
		isYourPreferredSexualPartnerOfTheOppositeSexOrTheSameSex.SetActive(true);
		whoLivesAtHomeWithYou.SetActive(true);
		doYouDrinkAnyAlcohol.SetActive(true);
		howMuchDoYouDrinkInAWeek.SetActive(true);
		haveYouEverThoughtAboutCuttingDown.SetActive(true);
		doYouSmoke.SetActive(true);
		howManyYearsHaveYouSmoked.SetActive(true);
		shNextPage.SetActive(true);
		backToHistoryFromSH.SetActive(true);
	}

	public void SHPage2 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		howManyPacksPerDayHaveYouSmoked.SetActive(true);
		haveyoueverthoughtaboutquitting.SetActive(true);
		doYouDoAnyIllicitOrRecreationalDrugs.SetActive(true);
		whichDrugsDoYouUseAndHowFrequentlyDoYouUseThem.SetActive(true);
		haveYouEverTriedToQuitUsingDrugsOrHaveBeenInADetoxificationProgram.SetActive(true);
		whereWereYouBorn.SetActive(true);
		whatIsYourFinancialSituation.SetActive(true);
		howActiveAreYou.SetActive(true);
		shPreviousPage.SetActive(true);
	}

	public void ROS () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		generalROS.SetActive(true);
		musculoskeletalROS.SetActive(true);
		psychiatricROS.SetActive(true);
		respiratoryROS.SetActive(true);
		cardiovascularROS.SetActive(true);
		gastrointestinalROS.SetActive(true);
		neurologicROS.SetActive(true);
		hematologicROS.SetActive(true);
		endocrineROS.SetActive(true);
		genitourinaryROS.SetActive(true);
		oropharynxROS.SetActive(true);
		noseAndSinusROS.SetActive(true);
		earsROS.SetActive(true);
		eyesROS.SetActive(true);
		headROS.SetActive(true);
		dermatologicROS.SetActive(true);
		backToHistoryFromROS.SetActive(true);
	}

	public void ROSGeneral () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		howAreYourEnergyLevels.SetActive(true);
		haveYouNoticedAnySignificantWeightGain.SetActive(true);
		haveYouNoticedAnySignificantWeightLoss.SetActive(true);
		doYouHaveAnyDifficultySleeping.SetActive(true);
		haveYouExperiencedAnyFeversOrChills.SetActive(true);
		haveYouExperiencedAnyDrenchingNightSweats.SetActive(true);
		backToROSFromGeneralROS.SetActive(true);
	}

	public void ROSMSK () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouHaveAnyPainsStiffnessOrSwellingInYourJoints.SetActive(true);
		doYouHaveBackaches.SetActive(true);
		doYouHavePainsInYourLegs.SetActive(true);
		doYouHavePainsOrCrampsinYourMuscles.SetActive(true);
		backToROSFromMSKROS.SetActive(true);
	}

	public void ROSPsych () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouFeelNervous.SetActive(true);
		doYouFeelAnxious.SetActive(true);
		doYouFeelDepressed.SetActive(true);
		backToROSFromPsychROS.SetActive(true);
	}

	public void ROSRespPage1 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouEverFeelShortOfBreathOnExertion.SetActive(true);
		hasYourBreathingChangedOverThePastMonth.SetActive(true);
		doYouSufferFromACough.SetActive(true);
		isYourCoughProductive.SetActive(true);
		whatColorIsTheSputum.SetActive(true);
		haveYouTraveledAnywhereOutsideOfTheCountryRecently.SetActive(true);
		didYouTravelByAirplaneForLongDistances.SetActive(true);
		haveYouBeenInContactWithAnyIndividualsWhoAreSick.SetActive(true);
		doYouWorkInOrFrequentlyVisitAHealthCareFacility.SetActive(true);
		haveYouEverLivedInAShelterOrPrison.SetActive(true);
		respROSNextPage.SetActive(true);
		backToROSFromRespROS.SetActive(true);
	}

	public void ROSRespPage2 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouEverWorkedInAShipyard.SetActive(true);
		haveYouEverBeenExposedOrInContactWithAnIndividualWhoIsDiagnosedWithTuberculosis.SetActive(true);
		haveYouEverHadATuberculosisSkinTest.SetActive(true);
		respROSPreviousPage.SetActive(true);
	}

	public void ROSCardPage1 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouEverExperiencedChestPainOnExertionBefore.SetActive(true);
		doYouExperiencePalpitations.SetActive(true);
		haveYouEverHadAHeartAttack.SetActive(true);
		haveYouNoticedAnySwellingInYourAnkles.SetActive(true);
		haveYouNoticedAnyChangeInWaistCircumference.SetActive(true);
		doYouEverWakeUpInTheMiddleOfTheNightGaspingForAir.SetActive(true);
		doYouExperienceAnyDifficultyWithYourBreathingWhenYouLieFlat.SetActive(true);
		howManyPillowsDoYouSleepWithAtNight.SetActive(true);
		haveYouEverFainted.SetActive(true);
		haveYouExperiencedAnyPainInYourLegsWhileWalking.SetActive(true);
		cardROSNextPage.SetActive(true);
		backToROSFromCardROS.SetActive(true);
	}

	public void ROSCardPage2 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYourLegsFeelCold.SetActive(true);
		isThereAnyHistoryInYourFamilyOfSuddenCardiacDeath.SetActive(true);
		haveYouRecentlyHadAColdOrFlu.SetActive(true);
		haveYouEverBeenToldYouHaveAHeartMurmur.SetActive(true);
		didYouEverHaveRheumaticHeartDiseaseAsAChild.SetActive(true);
		cardROSPrevousPage.SetActive(true);
	}

	public void ROSGIPage1 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		howIsYourAppetite.SetActive(true);
		doesFoodEverGetStuckInYourThroat.SetActive(true);
		doYouEverExperiencePainWhileSwallowing.SetActive(true);
		doYouHaveDifficultySwallowingSolidsOrLiquidsOrBoth.SetActive(true);
		doYouSufferFromHeartBurn.SetActive(true);
		haveYouEverFeltThatYouGetFullReallyQuicklyDuringMeals.SetActive(true);
		haveYouExperiencedAnyNauseaOrVomiting.SetActive(true);
		haveYouExperiencedAnyAbdominalBloating.SetActive(true);
		haveYouHadAnyDiarrhea.SetActive(true);
		haveYouHadAnyConstipation.SetActive(true);
		giROSToPage2.SetActive(true);
		backToROSFromGIROS.SetActive(true);
	}

	public void ROSGIPage2 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouEverHadAnyBloodInYourStool.SetActive(true);
		haveYouEverHadAnyBlackTarryStools.SetActive(true);
		doYouExperienceAnyPainWhilePassingBowelMovements.SetActive(true);
		doYouEverHaveAnyPaleFattyStools.SetActive(true);
		haveYouTakenAnyAntibioticsRecently.SetActive(true);
		areYourStoolsFoulSmelling.SetActive(true);
		haveYouEverVomitedBlood.SetActive(true);
		wasItBrightRedBlood.SetActive(true);
		didItLookLikeCoffeeGrounds.SetActive(true);
		haveYouEverHadAColonoscopy.SetActive(true);
		giROSToPage3.SetActive(true);
		backToGIROSPage1.SetActive(true);
	}

	public void ROSGIPage3 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouEverHadAGastroscopy.SetActive(true);
		haveYouHadAnyRecentTravelOutsideOfTheCountry.SetActive(true);
		haveYouNoticedAnyYellowingOfTheEyesOrSkin.SetActive(true);
		haveYouExperiencedAnyEasyBruisingOrBleeding.SetActive(true);
		haveYouNoticedAnyEnlargementofYourBreastTissue.SetActive(true);
		haveYouNoticedAnyMuscleWasting.SetActive(true);
		backToGIROSPage2.SetActive(true);
	}

	public void ROSNeuroPage1 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouEverHadAStroke.SetActive(true);
		WasItDueToABloodClotOrABleed.SetActive(true);
		DoYouHaveAnyResidualSymptoms.SetActive(true);
		haveYouEverHadASeizure.SetActive(true);
		haveYouExperiencedDoubleVision.SetActive(true);
		haveYouExperiencedBlurredVision.SetActive(true);
		haveYouOrOthersNoticedAnyAsymmetryInYourFace.SetActive(true);
		haveYouExperiencedAnySlurringOfYourSpeech.SetActive(true);
		haveYouExperiencedAnyNumbnessOrTinglingInYourBody.SetActive(true);
		haveYouExperiencedAnyWeaknessOnOneSideOfYourBody.SetActive(true);
		neuroROSToPage2.SetActive(true);
		backToROSFromNeuroROS.SetActive(true);
	}

	public void ROSNeuroPage2 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouEverLostControlOfYourBowelsOrBladder.SetActive(true);
		doYouUseAnyWalkingAids.SetActive(true);
		doYouHaveDifficultyButtoningYourShirts.SetActive(true);
		haveYouNoticedATremor.SetActive(true);
		haveYouHadAnyProblemsWithBalanceOrCoordination.SetActive(true);
		haveYouNoticedAnyChangesInYourVoice.SetActive(true);
		doYouFindThatYouChokeOrCoughWhenYouEatOrDrink.SetActive(true);
		haveYouNoticedAnyChangesWithYourMemory.SetActive(true);
		haveYouEverLeftTheTapOrTheStoveOnInYourHouse.SetActive(true);
		doYouDriveACar.SetActive(true);
		neuroROSToPage3.SetActive(true);
		backToNeuroROSPage1.SetActive(true);
	}

	public void ROSNeuroPage3 () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouSufferFromAnyHeadache.SetActive(true);
		isItTheWorstHeadacheYouveEverDad.SetActive(true);
		haveYouHadAnyAssociatedNauseaOrVomiting.SetActive(true);
		haveYouExperiencedAnyScalpTendernessOrPainInYourJaw.SetActive(true);
		backToNeuroROSPage2.SetActive(true);
	}

	public void ROSHeme () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		howDifficultIsItToStopBleedingWhenYouHaveASmallCut.SetActive(true);
		doYouHaveAnemia.SetActive(true);
		haveYouEverHadABloodTransfusion.SetActive(true);
		didYouExperienceAnyProblemsWithTheBloodTransfusion.SetActive(true);
		doYouBruiseEasily.SetActive(true);
		backToROSFromHemeROS.SetActive(true);
	}

	public void ROSEndo () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		howWellDoYouTolerateTheHeat.SetActive(true);
		howWellDoYouTolerateTheCold.SetActive(true);
		doYouUrinateFrequently.SetActive(true);
		areYouExcessivelyHungry.SetActive(true);
		areYouExcessivelyThirsty.SetActive(true);
		doYouSweatExcessively.SetActive(true);
		haveYouNoticedAnyChangesToYourSkinOrHair.SetActive(true);
		backToROSFromEndoROS.SetActive(true);
	}

	public void ROSGU () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouHaveAnyPainOnUrination.SetActive(true);
		haveYouExperiencedAnIncreasedFrequencyInUrinating.SetActive(true);
		howOftenDoYouUrinateAtNight.SetActive(true);
		doYouOftenFeelTheUrgeToUrinate.SetActive(true);
		doYouFindItDifficultToBeginUrinating.SetActive(true);
		haveYouEverHadBloodInYourUrine.SetActive(true);
		isYourUrineFoamy.SetActive(true);
		haveYouBeenExperiencingAnyFlankPain.SetActive(true);
		haveYouNoticedAnySkinChangesToYourExternalGenitalia.SetActive(true);
		backToROSFromGUROS.SetActive(true);
	}

	public void ROSOropharynx () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouExperiencedAnyChangeInYourVoice.SetActive(true);
		doYouGetFrequentSoreThroats.SetActive(true);
		doYouHaveAnyProblemsWithYourTeethOrGums.SetActive(true);
		doYouHaveAnyBleedingInYourMouth.SetActive(true);
		backToROSFromOropharynxROS.SetActive(true);
	}

	public void ROSNoseSinus () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		howOftenDoYouHaveNosebleeds.SetActive(true);
		doYouHaveAnyDischargeFromYourNose.SetActive(true);
		doYouHaveDifficultyBreathingThroughYourNose.SetActive(true);
		haveYouHadARecentColdOrInfectionInYourSinuses.SetActive(true);
		backToROSFromNoseSinusROS.SetActive(true);
	}

	public void ROSEars () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouHaveProblemsHearing.SetActive(true);
		haveYouExperiencedARingingInYourEars.SetActive(true);
		doYouHaveEaraches.SetActive(true);
		haveYouHadAnInfectionOrDischargeFromYourEars.SetActive(true);
		backToROSFromEarsROS.SetActive(true);
	}

	public void ROSEyes () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouWearGlassesOrContactLenses.SetActive(true);
		whenWasYourLastEyeExamination.SetActive(true);
		haveYouHadAnyRecentChangesToYourVision.SetActive(true);
		doYouHaveExcessiveTearingInYourEyes.SetActive(true);
		haveYouHadAnyPainOrRednessInYourEyes.SetActive(true);
		backToROSFromEyesROS.SetActive(true);
	}

	public void ROSHead () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		haveYouHadAnyInjuryToYourHead.SetActive(true);
		haveYouHadAStiffNeck.SetActive(true);
		backToROSFromHeadROS.SetActive(true);
	}

	public void ROSDerm () {
		foreach (Transform child in transform) {child.gameObject.SetActive (false);}
		doYouHaveAnyLumpsOnYourSkin.SetActive(true);
		doYouHaveAnyRashesOnYourSkin.SetActive(true);
		doYouHaveAnyItchingOrDrySkin.SetActive(true);
		haveYouNoticedAnyChangesToYourFingernails.SetActive(true);
		haveYouNoticedAnyChangesToYourHairGrowth.SetActive(true);
		backToROSFromDermROS.SetActive(true);
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
