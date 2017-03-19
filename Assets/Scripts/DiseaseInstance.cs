using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseInstance {

	// Disease ID
	public string disease_name;

	// Demographics
	public int age;
	public bool male;
	public float bmi;
	public enum Race {asian, black, hispanic, white};
	public Race race;
	public enum Personality	{Schoolgirl, BaseballBoy, GenericFemale, BasicGirl, HairGirl, GenericMale, AsianMale, BasketballMale, JockMale, CatLady, OldMale, PunkGirl, RockDude, ObeseBlackFemale, ObeseWhiteFemale, ObeseBlackMale, ObeseWhiteMale};
	public Personality personality;

	private List <Personality> youngFemales = new List <Personality> {Personality.Schoolgirl};
	private List <Personality> youngMales = new List <Personality> {Personality.BaseballBoy};
	private List <Personality> adultFemales = new List <Personality> {Personality.GenericFemale, Personality.BasicGirl, Personality.HairGirl, Personality.PunkGirl};
	private List <Personality> adultFemalesObese = new List <Personality> {Personality.ObeseBlackFemale, Personality.ObeseWhiteFemale};
	private List <Personality> adultMales = new List <Personality> {Personality.GenericMale, Personality.AsianMale, Personality.BasketballMale, Personality.JockMale, Personality.RockDude};
	private List <Personality> adultMalesObese = new List <Personality> {Personality.ObeseBlackMale, Personality.ObeseWhiteMale};
	private List <Personality> elderlyFemales = new List <Personality> {Personality.CatLady};
	private List <Personality> elderlyMales = new List <Personality> {Personality.OldMale};

	// Questions
	public string[] questions = new string[204] {"Intro", "When were you last completely well", "When did the pain first start", "How would you describe your pain", "Where is the pain located", "Does the pain move anywhere", "How did the pain first start", "How severe is your pain", "Have you ever had a similar pain in the past", "Does anything make the pain better or worse", "What has been the impact of this problem on your life", "Who else have you seen about this problem", "What treatments have been recommended for this problem", "What medications, including non-prescription medications, have you used for this problem", "Have you had any tests related to this problem", "Is there anything else bothering you", "What medical conditions have you been diagnosed with", "Have you ever had any operations", "What diseases have you had as a child", "What prescription medications do you take", "Do you take any over-the-counter medications", "Are you allergic to any medications", "Are you adherent with your medications", "Were you adopted", "Tell me about your parents health", "Did anyone in your family, including grandparents, die at a young age", "What was the cause of death", "Do any members of your family have blood clotting problems", "Is there any history of cancer in your family", "Do any members of your family have heart problems", "Is there any history of autoimmune disorders in your family", "Are there any other chronic medical conditions that run in your family", "Describe your lifestyle and where you are living", "Are you currently employed", "What is your marital status", "Are you currently sexually active", "Is your preferred sexual partner of the opposite sex or the same sex", "Do you use contraception", "Have you ever been diagnosed with a sexually transmitted infection", "Have you ever been the victim of sexual abuse", "Who lives at home with you", "Do you drink any alcohol", "How much do you drink in a week", "Have you ever thought about cutting down", "Do you smoke", "How many years have you smoked", "How many packs per day have you smoked", "Have you ever thought about quitting", "Do you do any illicit or recreational drugs", "Which drugs do you use and how frequently do you use them", "Have you ever tried to quit using drugs or have been in a detoxification program", "Where were you born", "What is your financial situation", "How active are you", "How are your energy levels", "Have you noticed any significant weight gain", "Have you noticed any significant weight loss", "Do you have any difficulty sleeping", "Have you experienced any fevers or chills", "Have you experienced any drenching night sweats", "Do you have any pains, stiffness, or swelling in your joints", "Do you have backaches", "Do you have pains in your legs", "Do you have pains or cramps in your muscles", "Do you feel nervous", "Do you feel anxious", "Do you feel depressed", "Do you ever feel short of breath on exertion", "Has your breathing changed over the past month", "Do you suffer from a cough", "Is your cough productive", "What color is the sputum", "Have you traveled anywhere outside of the country recently", "Did you travel by airplane for long distances", "Have you been in contact with any individuals who are sick", "Do you work in or frequently visit a healthcare facility", "Have you ever lived in a shelter or prison", "Have you ever worked in a shipyard", "Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis", "Have you ever had a tuberculosis skin test", "Have you ever experienced chest pain on exertion before", "Do you experience palpitations", "Have you ever had a heart attack", "Have you noticed any swelling in your ankles", "Have you noticed any change in waist circumference", "Do you ever wake up in the middle of the night gasping for air", "Do you experience any difficulty with your breathing when you lie flat", "How many pillows do you sleep with at night", "Have you ever fainted", "Have you experienced any pain in your legs while walking", "Do your legs feel cold", "Is there any history in your family of sudden cardiac death", "Have you recently had a cold or flu", "Have you ever been told you have a heart murmur", "Did you ever have rheumatic heart disease as a child", "How is your appetite", "Does food ever get stuck in your throat", "Do you ever experience pain while swallowing", "Do you have difficulty swallowing solids, or liquids, or both", "Do you suffer from heartburn", "Have you ever felt that you get full really quickly during meals", "Have you experienced any nausea or vomiting", "Have you experienced any abdominal bloating", "Have you had any diarrhea", "Have you had any constipation", "Have you ever had any blood in your stool", "Have you ever had any black, tarry stools", "Do you experience any pain while passing bowel movements", "Do you ever have any pale, fatty stools", "Have you taken any antibiotics recently", "Are your stools foul-smelling", "Have you ever vomited blood", "Was it bright red blood", "Did it look like coffee grounds", "Have you ever had a colonoscopy", "Have you ever had a gastroscopy", "Have you had any recent travel outside of the country", "Have you noticed any yellowing of the eyes or skin", "Have you experienced any easy bruising or bleeding", "Have you noticed any enlargement of your breast tissue", "Have you noticed any muscle wasting", "Have you ever had a stroke", "Was it due to a blood clot or a bleed", "Do you have any residual symptoms", "Have you ever had a seizure", "Have you experienced double-vision", "Have you experienced blurred vision", "Have you or others noticed any asymmetry in your face", "Have you experienced any slurring of your speech", "Have you experienced any numbness or tingling in your body", "Have you experienced any weakness on one side of your body", "Have you ever lost control of your bowels or bladder", "Do you use any walking aids", "Do you have difficulty buttoning your shirts", "Have you noticed a tremor", "Have you had any problems with balance or coordination", "Have you noticed any changes in your voice", "Do you find that you choke or cough when you eat or drink", "Have you noticed any changes with your memory", "Have you ever left the tap or the stove on in your house", "Do you drive a car", "Do you suffer from any headache", "Is it the worst headache you've ever had", "Have you had any associated nausea or vomiting", "Have you experienced any scalp tenderness or pain in your jaw", "How difficult is it to stop bleeding when you have a small cut", "Do you have anemia", "Have you ever had a blood transfusion", "Did you experience any problems with the blood transfusion", "Do you bruise easily", "How well do you tolerate the heat", "How well do you tolerate the cold", "Do you urinate frequently", "Are you excessively hungry", "Are you excessively thirsty", "Do you sweat excessively", "Have you noticed any changes to your skin or hair", "Do you have any pain on urination", "Have you experienced an increased frequency in urinating", "How often do you urinate at night", "Do you often feel the urge to urinate", "Do you find it difficult to begin urinating", "Have you ever had blood in your urine", "Is your urine foamy", "Have you been experiencing any flank pain", "Have you noticed any skin changes to your external genitalia", "How many times have you been pregnant", "How many children have you had", "Have you ever had an abortion (spontaneous or elective)", "Do you have a history of infertility", "How old were you when you had your first period", "When was your last menstrual period", "What is the typical length of your periods", "How many days are usually between your periods", "Have you had any recent changes in your periods", "Have you ever had a history of irregular periods", "Have you ever had vaginal bleeding between your periods", "Have you ever experienced vaginal bleeding during or immediately after sexual intercourse", "When was your last Pap smear", "Have you ever had an abnormal Pap smear", "Have you experienced any change in your voice", "Do you get frequent sore throats", "Do you have any problems with your teeth or gums", "Do you have any bleeding in your mouth", "How often do you have nosebleeds", "Do you have any discharge from your nose", "Do you have difficulty breathing through your nose", "Have you had a recent cold or infection in your sinuses", "Do you have problems hearing", "Have you experienced a ringing in your ears", "Do you have earaches", "Have you had an infection or discharge from your ears", "Do you wear glasses or contact lenses", "When was your last eye examination", "Have you had any recent changes to your vision", "Do you have excessive tearing in your eyes", "Have you had any pain or redness in your eyes", "Have you had any injury to your head", "Have you had a stiff neck", "Do you have any lumps on your skin", "Do you have any rashes on your skin", "Do you have any itching, or dry skin", "Have you noticed any changes to your fingernails", "Have you noticed any changes to your hair growth"};

	// Answers
	public string[,] answers = new string[204, Enum.GetNames(typeof(Personality)).Length];

	// Vitals
	public string [] vitalStrings = new string[6] {"T", "HR", "SBP", "DBP", "RR", "SpO2"};
	public float temperature, heartRate, systolicBP, diastolicBP, respiratoryRate, spO2;

	// Physical Exam Maneuvers
	public string[] physicalManeuvers = new string[90] {"General appearance", "Glasgow Coma Scale", "Pulm - Inspection", "Pulm - Palpation", "Pulm - Percussion", "Pulm - Auscultation", "Tactile fremitus", "Whispered pectoriloquy", "Egophony", "Card - Inspection", "Card - Palpation", "Card - Auscultation", "Abd vasc - Inspection, palpation, and auscultation", "Upper limb vasc - Inspection, palpation, and auscultation", "Lower limb vasc - Inspection, palpation, and auscultation", "Abd - Inspection", "Abd - Inspection from the side, eyes at bedside level", "Abd - Palpation - Superficial", "Abd - Palpation - Deep", "Abd - Percussion", "Abd - Auscultation", "JVP", "Thyroid gland", "Carotids", "Lymph node palpation", "Oph - General inspection", "Fundoscopy", "Slit lamp exam", "Ears - General examination", "Otoscopic examination", "Oro - General inspection", "Knees - Inspection and gait assessment", "Knees - Range of movement", "Knees - Palpation", "Knees - Special tests", "Hips - Gait", "Hips - Inspection", "Hips - Range of movement", "Hips - Palpation", "Thomas Test", "Trendelenberg Sign", "Shoulder - Inspection", "Shoulder - Range of movement - active", "Shoulder - Range of movement - passive", "Shoulder - Palpation", "Lift-off Test", "Speed's Test", "Yergason's Test", "Back - Inspection", "Back - Range of movement", "Back - Palpation", "Straight Leg Test", "Schober's Test", "Olfactory Nerve (CN I)", "Optic Nerve (CN II)", "Oculomotor, Trochlear, and Abducens Nerves (CN III, IV, VI)", "CN V - Sensation - Light touch", "CN V - Sensation - Pain and Temperature", "CN V - Sensation - Corneal Reflex", "CN V - Motor - Temporalis and masseters", "CN V - Motor - Jaw Jerk Reflex", "CN V - Motor - Lateral and Medial pterygoids", "CN VII - Inspection", "CN VII - Motor - Muscles of facial expression", "CN VII - Reflexes", "Vestibulocochlear Nerve (CN VIII)", "Glossopharyngeal and Vagus Nerves (CN IX, X)", "CN XI - Inspection", "CN XI - Motor", "CN XII - Inspection", "CN XII - Motor", "Neuro - General inspection", "Neuro - Tone", "Neuro - Power", "Neuro - Sensation", "Neuro - Vibration", "Neuro - Proprioception", "Neuro - Reflexes", "Cere - General inspection", "Cere - Gait", "Cere - Speech", "Cere - Coordination", "Cere - Motor", "Breast - Inspection", "Breast - Palpation", "Inspection of external genitalia", "Palpation of Bartholin glands", "Speculum examination", "Bimanual examination", "Rectovaginal examination"};

	// Physical Exam Results
	public string[] physicalResults = new string[90];

	// Lab Studies
	public string[] labStudies = new string[11] {"CBC", "BMP", "Coag", "LFT", "ABG", "ESR, CRP", "Amylase, lipase", "Thyroid hormones", "Troponin I", "Cortisol", "Urinalysis"};
		
	public string[] labComponents = new string[37] {"WBC", "HGB", "PLT", "Na", "K", "Cl", "HCO3", "BUN", "Cr", "Glu", "AST", "ALT", "AlkPhos", "Ca", "TotalProt", "Albumin", "TotalBili", "PT", "PTT", "INR", "Amylase", "Lipase", "Lactate", "Troponin I", "CK", "CRP", "ESR", "Cortisol (random)", "TSH", "T3", "T4", "pH", "paCO2", "paO2", "upH", "uSpGrav", "uGluc"};

	public string[] labStudiesBinary = new string[12] {"Pregnancy Test", "Blood cultures", "Urine cultures", "Sputum cultures", "Chlamydia", "Ghonorrea", "Herpes", "HPV", "Syphilis", "HIV", "Lab - Pap smear", "Endometrial biopsy"};
	
	// Lab Results
	public float[] labResults = new float[37] {-1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, -1f, 1f};

	public bool[] labResultsBinary = new bool[1] {false};

	// Imaging Studies
	public int[] imagingStudies = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};

	// Differential
	public string[] differential = new string[10];

	// Performance Tracking
	public List<int> goodQuestions = new List<int>();
	public List<int> badQuestions = new List<int>();
	public List<int> goodPhysicalManeuvers = new List<int>();
	public List<int> badPhysicalManeuvers = new List<int>();
	public List<int> goodLabs = new List<int>();
	public List<int> badLabs = new List<int>();
	public List<int> goodLabsBinary = new List<int>();
	public List<int> badLabsBinary = new List<int>();
	public List<int> goodImages = new List<int>();
	public List<int> badImages = new List<int>();

	public DiseaseInstance 	(string diseaseName, int ageMin, int ageMax, float maleProbability, float bmiMin, float bmiMax, float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability, string[,] diseaseAnswers, float diseaseTMin, float diseaseTMax, float diseaseHRMin, float diseaseHRMax, float diseaseSBPMin, float diseaseSBPMax, float diseaseDBPMin, float diseaseDBPMax, float diseaseRRMin, float diseaseRRMax, float diseaseSpO2Min, float diseaseSpO2Max, string[] diseasePhysical, float[,] diseaseLabMinMax, bool[] diseaseLabsBinary, int[] images, int[] goodQuestionIDs, int[] badQuestionIDs, int[] goodPhysicalManeuverIDs, int[] badPhysicalManeuverIDs, int[] goodLabIDs, int[] badLabIDs, int[] goodLabBinaryIDs, int[] badLabBinaryIDs, int[] goodImageIDs, int[] badImageIDs, string[] differentialOptions) {
		Debug.Log ("Instance of disease " + diseaseName + " created.");
		this.disease_name = diseaseName;
		this.age = RandomAge (ageMin, ageMax);
		this.male = RandomSex (maleProbability);
		this.bmi = RandomBMI (bmiMin, bmiMax);
		this.race = RandomRace (asianProbability, blackProbability, hispanicProbability, whiteProbability);
		this.personality = RandomPersonality (age, male, race);
		this.answers = diseaseAnswers;
		this.physicalResults = diseasePhysical;
		RandomVitals (diseaseTMin, diseaseTMax, diseaseHRMin, diseaseHRMax, diseaseSBPMin, diseaseSBPMax, diseaseDBPMin, diseaseDBPMax, diseaseRRMin, diseaseRRMax, diseaseSpO2Min, diseaseSpO2Max);
		RandomLabValue(diseaseLabMinMax);
		this.labResultsBinary = diseaseLabsBinary;
		this.imagingStudies = images;
		this.differential = differentialOptions;
		foreach (int i in goodQuestionIDs) {goodQuestions.Add (i);}
		foreach (int i in badQuestionIDs) {badQuestions.Add (i);}
		foreach (int i in goodPhysicalManeuverIDs) {goodPhysicalManeuvers.Add (i);}
		foreach (int i in badPhysicalManeuverIDs) {badPhysicalManeuvers.Add (i);}
		foreach (int i in goodLabIDs) {goodLabs.Add (i);}
		foreach (int i in badLabIDs) {badLabs.Add (i);}
		foreach (int i in goodLabBinaryIDs) {goodLabsBinary.Add (i);}
		foreach (int i in badLabBinaryIDs) {badLabsBinary.Add (i);}
		foreach (int i in goodImageIDs) {goodImages.Add (i);}
		foreach (int i in badImageIDs) {badImages.Add (i);}
	}

	public int RandomAge (int ageMin, int ageMax) {
		return UnityEngine.Random.Range (ageMin, ageMax);
	}

	public bool RandomSex (float maleProbability) {
		float randomSex = UnityEngine.Random.value;
		if (randomSex < maleProbability) {return true;}
		else {return false;}
	}

	public float RandomBMI (float bmiMin, float bmiMax) {
		return (Mathf.Round(10*(UnityEngine.Random.Range (bmiMin, bmiMax))))/10;
	}

	public Race RandomRace (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		float randomRace = UnityEngine.Random.value;
		if (randomRace <= asianProbability) {return Race.asian;}
		else if (randomRace > asianProbability && randomRace <= (asianProbability + blackProbability)){return Race.black;}
		else if (randomRace > (asianProbability + blackProbability) && randomRace <= (asianProbability + blackProbability + hispanicProbability)) {return Race.hispanic;}
		else {return Race.white;}
	}

	public Personality RandomPersonality (int age, bool male, Race race) {
		if (age <= 15 && male == false) {
			return youngFemales [(UnityEngine.Random.Range (0, youngFemales.Count))];
		} else if (age <= 15 && male == true) {
			return youngMales [(UnityEngine.Random.Range (0, youngMales.Count))];
		} else if (age > 15 && age <= 60 && male == false && bmi < 30.0f) {
			return adultFemales [(UnityEngine.Random.Range (0, adultFemales.Count))];
		} else if (age > 15 && age <= 60 && male == false && bmi >= 30.0f) {
			return adultFemalesObese [(UnityEngine.Random.Range (0, adultFemalesObese.Count))];
		} else if (age > 15 && age <= 60 && male == true && bmi < 30.0f) {
			return adultMales [(UnityEngine.Random.Range (0, adultMales.Count))];
		} else if (age > 15 && age <= 60 && male == true && bmi >= 30.0f) {
			return adultMalesObese [(UnityEngine.Random.Range (0, adultMalesObese.Count))];
		} else if (age > 60 && male == false) {
			return elderlyFemales [(UnityEngine.Random.Range (0, elderlyFemales.Count))];
		} else if (age > 60 && male == true) {
			return elderlyMales [(UnityEngine.Random.Range (0, elderlyMales.Count))];
		} else {return Personality.GenericMale;}
	}

	public void RandomVitals (float tMin, float tMax, float hrMin, float hrMax, float sbpMin, float sbpMax, float dbpMin, float dbpMax, float rrMin, float rrMax, float spo2Min, float spo2Max) {
		this.temperature = Mathf.Round(10*(UnityEngine.Random.Range (tMin, tMax)))/10;
		this.heartRate = Mathf.Round(UnityEngine.Random.Range (hrMin, hrMax));
		this.systolicBP = Mathf.Round(UnityEngine.Random.Range (sbpMin, sbpMax));
		this.diastolicBP = Mathf.Round(UnityEngine.Random.Range (dbpMin, dbpMax));
		this.respiratoryRate = Mathf.Round(UnityEngine.Random.Range (rrMin, rrMax));
		this.spO2 = Mathf.Round(10*(UnityEngine.Random.Range (spo2Min, spo2Max)))/10;
	}

	public void RandomLabValue (float[,] diseaseLabMaxMin){
		foreach (string i in labComponents) {
			if (diseaseLabMaxMin [Array.IndexOf (labComponents, i), 0] != -1f && diseaseLabMaxMin [Array.IndexOf (labComponents, i), 1] != -1f) {
				labResults [Array.IndexOf (labComponents, i)] = UnityEngine.Random.Range (diseaseLabMaxMin [Array.IndexOf (labComponents, i), 0], diseaseLabMaxMin [Array.IndexOf (labComponents, i), 1]);
			}
			if (i == "HGB"){
				labResults [Array.IndexOf (labComponents, i)] = Mathf.Round(10*(labResults [Array.IndexOf (labComponents, i)]))/10;
			}
		}
	}

	public void OverwriteHistory (History history, string historyKey, string historyValue) {
		history.history [historyKey] = historyValue;
	}

	public void OverwriteVitals (Vitals vitals, string vitalsKey, float vitalsValue) {
		vitals.vitals [vitalsKey] = vitalsValue;
	}

	public void OverwritePhysical (PhysicalExam physical, string physicalKey, string physicalValue) {
		if (physicalValue != "x") {
			physical.physical [physicalKey] = physicalValue;
		}
	}

	public void OverwriteLabs (LabValues labValues, string labKey, float labValue){
		if (labValue != -1f) {
			labValues.labValues [labKey] = labValue;
		}
	}

	public void OverwriteLabsBinary (LabValues labValues, string labKey, bool labValue){
		labValues.labValuesBinary [labKey] = labValue;
	}

}
