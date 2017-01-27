using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseInstance {

	// Disease ID
	public string disease_name;

	// Demographics
	public int age_min;
	public int age_max;
	public float male_probability;
	public float asian_probability;
	public float black_probability;
	public float hispanic_probability;
	public float white_probability;
	public enum Race {asian, black, hispanic, white};
	public enum Personality {personalityA, personalityB};

	// Questions
	public string[] questions = new string[186]
		{"Intro", "When were you last completely well", "When did the pain first start", "How would you describe your pain", "Where is the pain located",
		"Does the pain move anywhere", "How did the pain first start", "How severe is your pain", "Have you ever had a similar pain in the past",
		"Does anything make the pain better or worse", "What has been the impact of this problem on your life", "Who else have you seen about this problem",
		"What treatments have been recommended for this problem", "What medications, including non-prescription medication, have you used for this problem",
		"Have you had any tests related to this problem", "Is there anything else bothering you", "What medical conditions have you been diagnosed with",
		"Have you ever had any operations", "What diseases have you had as a child", "What prescription medications do you take",
		"Do you take any over-the-counter medications", "Are you allergic to any medications", "Are you adherent with your medications", "Were you adopted",
		"Tell me about your parents health", "Did anyone in your family, including grandparents, die at a young age", "What was the cause of death",
		"Do any members of your family have blood clotting problems", "Is there any history of cancer in your family",
		"Do any members of your family have heart problems", "Is there any history of autoimmune disorders in your family",
		"Are there any other chronic medical conditions that run in your family", "Describe your lifestyle and where you are living",
		"Are you currently employed", "What is your marital status", "Is your preferred sexual partner of the opposite sex or the same sex",
		"Who lives at home with you","Do you drink any alcohol", "How much do you drink in a week", "Have you ever thought about cutting down", "Do you smoke",
		"How many years have you smoked", "How many packs per day have you smoked", "Have you ever thought about quitting",
		"Do you do any illicit or recreational drugs", "Which drugs do you use and how frequently do you use them",
		"Have you ever tried to quit using drugs or have been in a detoxification program", "Where were you born", "What is your financial situation",
		"How active are you", "How are your energy levels", "Have you noticed any significant weight gain", "Have you noticed any significant weight loss",
		"Do you have any difficulty sleeping", "Have you experienced any fevers or chills", "Have you experienced any drenching night sweats",
		"Do you have any pains, stiffness, or swelling in your joints", "Do you have backaches", "Do you have pains in your legs",
		"Do you have pains or cramps in your muscles", "Do you feel nervous", "Do you feel anxious", "Do you feel depressed",
		"Do you ever feel short of breath on exertion", "Has your breathing changed over the past month", "Do you suffer from a cough",
		"Is your cough productive", "What color is the sputum", "Have you traveled anywhere outside of the country recently",
		"Did you travel by airplane for long distances", "Have you been in contact with any individuals who are sick",
		"Do you work in or frequently visit a healthcare facility", "Have you ever lived in a shelter or prison", "Have you ever worked in a shipyard",
		"Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis", "Have you ever had a tuberculosis skin test",
		"Have you ever experienced chest pain on exertion before", "Do you experience palpitations", "Have you ever had a heart attack",
		"Have you noticed any swelling in your ankles", "Have you noticed any change in waist circumference",
		"Do you ever wake up in the middle of the night gasping for air", "Do you experience any difficulty with your breathing when you lie flat",
		"How many pillows do you sleep with at night", "Have you ever fainted", "Have you experienced any pain in your legs while walking",
		"Do your legs feel cold", "Is there any history in your family of sudden cardiac death", "Have you recently had a cold or flu",
		"Have you ever been told you have a heart murmur", "Did you ever have rheumatic heart disease as a child", "How is your appetite",
		"Does food ever get stuck in your throat", "Do you ever experience pain while swallowing",
		"Do you have difficulty swallowing solids, or liquids, or both", "Do you suffer from heartburn",
		"Have you ever felt that you get full really quickly during meals", "Have you experienced any nausea or vomiting",
		"Have you experienced any abdominal bloating", "Have you had any diarrhea", "Have you had any constipation", "Have you ever had any blood in your stool",
		"Have you ever had any black, tarry stools", "Do you experience any pain while passing bowel movements", "Do you ever have any pale, fatty stools",
		"Have you taken any antibiotics recently", "Are your stools foul-smelling", "Have you ever vomited blood", "Was it bright red blood",
		"Did it look like coffee grounds", "Have you ever had a colonoscopy", "Have you ever had a gastroscopy",
		"Have you had any recent travel outside of the country", "Have you noticed any yellowing of the eyes or skin",
		"Have you experienced any easy bruising or bleeding", "Have you noticed any enlargement of your breast tissue", "Have you noticed any muscle wasting",
		"Have you ever had a stroke", "Was it due to a blood clot or a bleed", "Do you have any residual symptoms", "Have you ever had a seizure",
		"Have you experienced double-vision", "Have you experienced blurred vision", "Have you or others noticed any asymmetry in your face",
		"Have you experienced any slurring of your speech", "Have you experienced any numbness or tingling in your body",
		"Have you experienced any weakness on one side of your body", "Have you ever lost control of your bowels or bladder", "Do you use any walking aids",
		"Do you have difficulty buttoning your shirts", "Have you noticed a tremor", "Have you had any problems with balance or coordination",
		"Have you noticed any changes in your voice", "Do you find that you choke or cough when you eat or drink",
		"Have you noticed any changes with your memory", "Have you ever left the tap or the stove on in your house", "Do you drive a car",
		"Do you suffer from any headache", "Is it the worst headache you've ever had", "Have you had any associated nausea or vomiting",
		"Have you experienced any scalp tenderness or pain in your jaw", "How difficult is it to stop bleeding when you have a small cut", "Do you have anemia",
		"Have you ever had a blood transfusion", "Did you experience any problems with the blood transfusion", "Do you bruise easily",
		"How well do you tolerate the heat", "How well do you tolerate the cold", "Do you urinate frequently", "Are you excessively hungry",
		"Are you excessively thirsty", "Do you sweat excessively", "Have you noticed any changes to your skin or hair", "Do you have any pain on urination",
		"Have you experienced an increased frequency in urinating", "How often do you urinate at night", "Do you often feel the urge to urinate",
		"Do you find it difficult to begin urinating", "Have you ever had blood in your urine", "Is your urine foamy", "Have you been experiencing any flank pain",
		"Have you noticed any skin changes to your external genitalia", "Have you experienced any change in your voice", "Do you get frequent sore throats",
		"Do you have any problems with your teeth or gums", "Do you have any bleeding in your mouth", "How often do you have nosebleeds",
		"Do you have any discharge from your nose", "Do you have difficulty breathing through your nose",
		"Have you had a recent cold or infection in your sinuses", "Do you have problems hearing", "Have you experienced a ringing in your ears",
		"Do you have earaches", "Have you had an infection or discharge from your ears", "Do you wear glasses or contact lenses",
		"When was your last eye examination", "Have you had any recent changes to your vision", "Do you have excessive tearing in your eyes",
		"Have you had any pain or redness in your eyes", "Have you had any injury to your head", "Have you had a stiff neck",
		"Do you have any lumps on your skin", "Do you have any rashes on your skin", "Do you have any itching, or dry skin",
		"Have you noticed any changes to your finger nails", "Have you noticed any changes to your hair growth"};

	// Answers
	public string[,] answers = new string[186,2];

	// Physical Exam Maneuvers
	public string[] physicalManeuvers = new string[83]
		{"General appearance", "Glasgow Coma Scale", "Pulm - Inspection", "Pulm - Palpation", "Pulm - Percussion", "Pulm - Auscultation", "Tactile fremitus",
		"Whispered pectoriloquy", "Egophony", "Card - Inspection", "Card - Palpation", "Card - Auscultation", "Abd vasc - Inspection, palpation, and auscultation",
		"Upper limb vasc - Inspection, palpation, and auscultation", "Lower limb vasc - Inspection, palpation, and auscultation", "Abd - Inspection", "Abd - Inspection from the side, eyes at bedside level", "Abd - Palpation - Superficial",
		"Abd - Palpation - Deep", "Abd - Percussion", "Abd - Auscultation", "JVP", "Thyroid gland", "Carotids", "Lymph node palpation", "Oph - General inspection",
		"Fundoscopy", "Slit lamp exam", "Ears - General examination", "Otoscopic examination", "Oro - General inspection",
		"Knees - Inspection and gait assessment", "Knees - Range of movement", "Knees - Palpation", "Knees - Special tests", "Hips - Gait", "Hips - Inspection",
		"Hips - Range of movement", "Hips - Palpation", "Thomas Test", "Trendelenberg Sign", "Shoulder - Inspection", "Shoulder - Range of movement - active",
		"Shoulder - Range of movement - passive", "Shoulder - Palpation", "Lift-off Test", "Speed's Test", "Yergason's Test", "Back - Inspection",
		"Back - Range of movement", "Back - Palpation", "Straight Leg Test", "Schober's Test", "Olfactory Nerve (CN I)", "Optic Nerve (CN II)",
		"Oculomotor, Trochlear, and Abducens Nerves (CN III, IV, VI)", "CN V - Sensation - Light touch", "CN V - Sensation - Pain and Temperature",
		"CN V - Sensation - Corneal Reflex", "CN V - Motor - Temporalis and masseters", "CN V - Motor - Jaw Jerk Reflex",
		"CN V - Motor - Lateral and Medial pterygoids", "CN VII - Inspection", "CN VII - Motor - Muscles of facial expression", "CN VII - Reflexes",
		"Vestibulocochlear Nerve (CN VIII)", "Glossopharyngeal and Vagus Nerves (CN IX, X)", "CN XI - Inspection", "CN XI - Motor", "CN XII - Inspection",
		"CN XII - Motor", "Neuro - General inspection", "Neuro - Tone", "Neuro - Power", "Neuro - Sensation", "Neuro - Vibration", "Neuro - Proprioception",
		"Neuro - Reflexes", "Cere - General inspection", "Cere - Gait", "Cere - Speech", "Cere - Coordination", "Cere - Motor"};

	// Physical Exam Results
	public string[] physicalResults = new string[83];

	// Performance Tracking
	public List<int> goodQuestions = new List<int>();
	public List<int> badQuestions = new List<int>();
	public List<int> goodPhysicalManeuvers = new List<int>();
	public List<int> badPhysicalManeuvers = new List<int>();

	public DiseaseInstance (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability,
		float hispanicProbability, float whiteProbability, string[,] diseaseAnswers, string[] diseasePhysical, int[] goodQuestionIDs, int[] badQuestionIDs,
		int[] goodPhysicalManeuverIDs, int[] badPhysicalManeuverIDs) {
		Debug.Log ("Instance of disease " + diseaseName + " created.");
		this.disease_name = diseaseName;
		this.age_min = ageMin;
		this.age_max = ageMax;
		this.male_probability = maleProbability;
		this.asian_probability = asianProbability;
		this.black_probability = blackProbability;
		this.hispanic_probability = hispanicProbability;
		this.white_probability = whiteProbability;
		this.answers = diseaseAnswers;
		this.physicalResults = diseasePhysical;
		foreach (int i in goodQuestionIDs) {
			goodQuestions.Add (i);
		}
		foreach (int i in badQuestionIDs) {
			badQuestions.Add (i);
		}
		foreach (int i in goodPhysicalManeuverIDs) {
			goodPhysicalManeuvers.Add (i);
		}
		foreach (int i in badPhysicalManeuverIDs) {
			badPhysicalManeuvers.Add (i);
		}
	}

	public int RandomAge (int ageMin, int ageMax) {
		return Random.Range (ageMin, ageMax);
	}

	public bool RandomSex (float maleProbability) {
		float randomSex = Random.value;
		if (maleProbability <= randomSex) {
			return true;
		} else {
			return false;
		}
	}

	public Race RandomRace (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability) {
		float randomRace = Random.value;
		if (randomRace <= asianProbability) {
			return Race.asian;
		} else if (randomRace > asianProbability && randomRace <= (asianProbability + blackProbability)){
			return Race.black;
		} else if (randomRace > (asianProbability + blackProbability) && randomRace <= (asianProbability + blackProbability + hispanicProbability)) {
			return Race.hispanic;
		} else {
			return Race.white;
		}
	}

	public Personality RandomPersonality (int age, bool male, Race race) {
		if (age <= 50) {
			return Personality.personalityA;
		} else {
			return Personality.personalityB;
		}
	}

	public void OverwriteHistory (History history, string historyKey, string historyValue) {
		history.history [historyKey] = historyValue;
	}

	public void OverwritePhysical (PhysicalExam physical, string physicalKey, string physicalValue) {
		if (physicalValue != "x") {
			physical.physical [physicalKey] = physicalValue;
		} else {
			return;
		}
	}

}
