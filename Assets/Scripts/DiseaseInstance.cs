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
		"Do you suffer from any headache", "Is it the worst headache you’ve ever had", "Have you had any associated nausea or vomiting",
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
	public string[,] answers = new string[187,2];

	// Performance Tracking
	public List<int> goodQuestions = new List<int>();

	public DiseaseInstance (string diseaseName, int ageMin, int ageMax, float maleProbability, float asianProbability, float blackProbability,
							float hispanicProbability, float whiteProbability, string introA, string introB, string question1A, string question1B,
							string question2A, string question2B, string question3A, string question3B, string question4A, string question4B, string question5A,
							string question5B, string question6A, string question6B, string question7A, string question7B, string question8A, string question8B,
							string question9A, string question9B, string question10A, string question10B, string question11A, string question11B,
							string question12A, string question12B, string question13A, string question13B, string question14A, string question14B,
							string question15A, string question15B, string question16A, string question16B, string question17A, string question17B,
							string question18A, string question18B, string question19A, string question19B, string question20A, string question20B,
							string question21A, string question21B, string question22A, string question22B, string question23A, string question23B,
							string question24A, string question24B, string question25A, string question25B, string question26A, string question26B,
							string question27A, string question27B, string question28A, string question28B, string question29A, string question29B,
							string question30A, string question30B, string question31A, string question31B, string question32A, string question32B,
							string question33A, string question33B, string question34A, string question34B, string question35A, string question35B,
							string question36A, string question36B, string question37A, string question37B, string question38A, string question38B,
							string question39A, string question39B, string question40A, string question40B, string question41A, string question41B,
							string question42A, string question42B, string question43A, string question43B, string question44A, string question44B,
							string question45A, string question45B, string question46A, string question46B, string question47A, string question47B,
							string question48A, string question48B, string question49A, string question49B, string question50A, string question50B,
							string question51A, string question51B, string question52A, string question52B, string question53A, string question53B,
							string question54A, string question54B, string question55A, string question55B, string question56A, string question56B,
							string question57A, string question57B, string question58A, string question58B, string question59A, string question59B,
							string question60A, string question60B, string question61A, string question61B, string question62A, string question62B,
							string question63A, string question63B, string question64A, string question64B, string question65A, string question65B,
							string question66A, string question66B, string question67A, string question67B, string question68A, string question68B,
							string question69A, string question69B, string question70A, string question70B, string question71A, string question71B,
							string question72A, string question72B, string question73A, string question73B, string question74A, string question74B,
							string question75A, string question75B, string question76A, string question76B, string question77A, string question77B,
							string question78A, string question78B, string question79A, string question79B, string question80A, string question80B,
							string question81A, string question81B, string question82A, string question82B, string question83A, string question83B,
							string question84A, string question84B, string question85A, string question85B, string question86A, string question86B,
							string question87A, string question87B, string question88A, string question88B, string question89A, string question89B,
							string question90A, string question90B, string question91A, string question91B, string question92A, string question92B,
							string question93A, string question93B, string question94A, string question94B, string question95A, string question95B,
							string question96A, string question96B, string question97A, string question97B, string question98A, string question98B,
							string question99A, string question99B, string question100A, string question100B, string question101A, string question101B,
							string question102A, string question102B, string question103A, string question103B, string question104A, string question104B,
							string question105A, string question105B, string question106A, string question106B, string question107A, string question107B,
							string question108A, string question108B, string question109A, string question109B, string question110A, string question110B,
							string question111A, string question111B, string question112A, string question112B, string question113A, string question113B,
							string question114A, string question114B, string question115A, string question115B, string question116A, string question116B,
							string question117A, string question117B, string question118A, string question118B, string question119A, string question119B,
							string question120A, string question120B, string question121A, string question121B, string question122A, string question122B,
							string question123A, string question123B, string question124A, string question124B, string question125A, string question125B,
							string question126A, string question126B, string question127A, string question127B, string question128A, string question128B,
							string question129A, string question129B, string question130A, string question130B, string question131A, string question131B,
							string question132A, string question132B, string question133A, string question133B, string question134A, string question134B,
							string question135A, string question135B, string question136A, string question136B, string question137A, string question137B,
							string question138A, string question138B, string question139A, string question139B, string question140A, string question140B,
							string question141A, string question141B, string question142A, string question142B, string question143A, string question143B,
							string question144A, string question144B, string question145A, string question145B, string question146A, string question146B,
							string question147A, string question147B, string question148A, string question148B, string question149A, string question149B,
							string question150A, string question150B, string question151A, string question151B, string question152A, string question152B,
							string question153A, string question153B, string question154A, string question154B, string question155A, string question155B,
							string question156A, string question156B, string question157A, string question157B, string question158A, string question158B,
							string question159A, string question159B, string question160A, string question160B, string question161A, string question161B,
							string question162A, string question162B, string question163A, string question163B, string question164A, string question164B,
							string question165A, string question165B, string question166A, string question166B, string question167A, string question167B,
							string question168A, string question168B, string question169A, string question169B, string question170A, string question170B,
							string question171A, string question171B, string question172A, string question172B, string question173A, string question173B,
							string question174A, string question174B, string question175A, string question175B, string question176A, string question176B,
							string question177A, string question177B, string question178A, string question178B, string question179A, string question179B,
							string question180A, string question180B, string question181A, string question181B, string question182A, string question182B,
							string question183A, string question183B, string question184A, string question184B, string question185A, string question185B,
							int[] goodQuestionIDs) {
		Debug.Log ("Instance of disease " + diseaseName + " created.");
		this.disease_name = diseaseName;
		this.age_min = ageMin;
		this.age_max = ageMax;
		this.male_probability = maleProbability;
		this.asian_probability = asianProbability;
		this.black_probability = blackProbability;
		this.hispanic_probability = hispanicProbability;
		this.white_probability = whiteProbability;
		this.answers [0, 0] = introA;
		this.answers [0, 1] = introB;
		this.answers [1, 0] = question1A;
		this.answers [1, 1] = question1B;
		this.answers [2, 0] = question2A;
		this.answers [2, 1] = question2B;
		this.answers [3, 0] = question3A;
		this.answers [3, 1] = question3B;
		this.answers [4, 0] = question4A;
		this.answers [4, 1] = question4B;
		this.answers [5, 0] = question5A;
		this.answers [5, 1] = question5B;
		this.answers [6, 0] = question6A;
		this.answers [6, 1] = question6B;
		this.answers [7, 0] = question7A;
		this.answers [7, 1] = question7B;
		this.answers [8, 0] = question8A;
		this.answers [8, 1] = question8B;
		this.answers [9, 0] = question9A;
		this.answers [9, 1] = question9B;
		this.answers [10, 0] = question10A;
		this.answers [10, 1] = question10B;
		this.answers [11, 0] = question11A;
		this.answers [11, 1] = question11B;
		this.answers [12, 0] = question12A;
		this.answers [12, 1] = question12B;
		this.answers [13, 0] = question13A;
		this.answers [13, 1] = question13B;
		this.answers [14, 0] = question14A;
		this.answers [14, 1] = question14B;
		this.answers [15, 0] = question15A;
		this.answers [15, 1] = question15B;
		this.answers [16, 0] = question16A;
		this.answers [16, 1] = question16B;
		this.answers [17, 0] = question17A;
		this.answers [17, 1] = question17B;
		this.answers [18, 0] = question18A;
		this.answers [18, 1] = question18B;
		this.answers [19, 0] = question19A;
		this.answers [19, 1] = question19B;
		this.answers [20, 0] = question20A;
		this.answers [20, 1] = question20B;
		this.answers [21, 0] = question21A;
		this.answers [21, 1] = question21B;
		this.answers [22, 0] = question22A;
		this.answers [22, 1] = question22B;
		this.answers [23, 0] = question23A;
		this.answers [23, 1] = question23B;
		this.answers [24, 0] = question24A;
		this.answers [24, 1] = question24B;
		this.answers [25, 0] = question25A;
		this.answers [25, 1] = question25B;
		this.answers [26, 0] = question26A;
		this.answers [26, 1] = question26B;
		this.answers [27, 0] = question27A;
		this.answers [27, 1] = question27B;
		this.answers [28, 0] = question28A;
		this.answers [28, 1] = question28B;
		this.answers [29, 0] = question29A;
		this.answers [29, 1] = question29B;
		this.answers [30, 0] = question30A;
		this.answers [30, 1] = question30B;
		this.answers [31, 0] = question31A;
		this.answers [31, 1] = question31B;
		this.answers [32, 0] = question32A;
		this.answers [32, 1] = question32B;
		this.answers [33, 0] = question33A;
		this.answers [33, 1] = question33B;
		this.answers [34, 0] = question34A;
		this.answers [34, 1] = question34B;
		this.answers [35, 0] = question35A;
		this.answers [35, 1] = question35B;
		this.answers [36, 0] = question36A;
		this.answers [36, 1] = question36B;
		this.answers [37, 0] = question37A;
		this.answers [37, 1] = question37B;
		this.answers [38, 0] = question38A;
		this.answers [38, 1] = question38B;
		this.answers [39, 0] = question39A;
		this.answers [39, 1] = question39B;
		this.answers [40, 0] = question40A;
		this.answers [40, 1] = question40B;
		this.answers [41, 0] = question41A;
		this.answers [41, 1] = question41B;
		this.answers [42, 0] = question42A;
		this.answers [42, 1] = question42B;
		this.answers [43, 0] = question43A;
		this.answers [43, 1] = question43B;
		this.answers [44, 0] = question44A;
		this.answers [44, 1] = question44B;
		this.answers [45, 0] = question45A;
		this.answers [45, 1] = question45B;
		this.answers [46, 0] = question46A;
		this.answers [46, 1] = question46B;
		this.answers [47, 0] = question47A;
		this.answers [47, 1] = question47B;
		this.answers [48, 0] = question48A;
		this.answers [48, 1] = question48B;
		this.answers [49, 0] = question49A;
		this.answers [49, 1] = question49B;
		this.answers [50, 0] = question50A;
		this.answers [50, 1] = question50B;
		this.answers [51, 0] = question51A;
		this.answers [51, 1] = question51B;
		this.answers [52, 0] = question52A;
		this.answers [52, 1] = question52B;
		this.answers [53, 0] = question53A;
		this.answers [53, 1] = question53B;
		this.answers [54, 0] = question54A;
		this.answers [54, 1] = question54B;
		this.answers [55, 0] = question55A;
		this.answers [55, 1] = question55B;
		this.answers [56, 0] = question56A;
		this.answers [56, 1] = question56B;
		this.answers [57, 0] = question57A;
		this.answers [57, 1] = question57B;
		this.answers [58, 0] = question58A;
		this.answers [58, 1] = question58B;
		this.answers [59, 0] = question59A;
		this.answers [59, 1] = question59B;
		this.answers [60, 0] = question60A;
		this.answers [60, 1] = question60B;
		this.answers [61, 0] = question61A;
		this.answers [61, 1] = question61B;
		this.answers [62, 0] = question62A;
		this.answers [62, 1] = question62B;
		this.answers [63, 0] = question63A;
		this.answers [63, 1] = question63B;
		this.answers [64, 0] = question64A;
		this.answers [64, 1] = question64B;
		this.answers [65, 0] = question65A;
		this.answers [65, 1] = question65B;
		this.answers [66, 0] = question66A;
		this.answers [66, 1] = question66B;
		this.answers [67, 0] = question67A;
		this.answers [67, 1] = question67B;
		this.answers [68, 0] = question68A;
		this.answers [68, 1] = question68B;
		this.answers [69, 0] = question69A;
		this.answers [69, 1] = question69B;
		this.answers [70, 0] = question70A;
		this.answers [70, 1] = question70B;
		this.answers [71, 0] = question71A;
		this.answers [71, 1] = question71B;
		this.answers [72, 0] = question72A;
		this.answers [72, 1] = question72B;
		this.answers [73, 0] = question73A;
		this.answers [73, 1] = question73B;
		this.answers [74, 0] = question74A;
		this.answers [74, 1] = question74B;
		this.answers [75, 0] = question75A;
		this.answers [75, 1] = question75B;
		this.answers [76, 0] = question76A;
		this.answers [76, 1] = question76B;
		this.answers [77, 0] = question77A;
		this.answers [77, 1] = question77B;
		this.answers [78, 0] = question78A;
		this.answers [78, 1] = question78B;
		this.answers [79, 0] = question79A;
		this.answers [79, 1] = question79B;
		this.answers [80, 0] = question80A;
		this.answers [80, 1] = question80B;
		this.answers [81, 0] = question81A;
		this.answers [81, 1] = question81B;
		this.answers [82, 0] = question82A;
		this.answers [82, 1] = question82B;
		this.answers [83, 0] = question83A;
		this.answers [83, 1] = question83B;
		this.answers [84, 0] = question84A;
		this.answers [84, 1] = question84B;
		this.answers [85, 0] = question85A;
		this.answers [85, 1] = question85B;
		this.answers [86, 0] = question86A;
		this.answers [86, 1] = question86B;
		this.answers [87, 0] = question87A;
		this.answers [87, 1] = question87B;
		this.answers [88, 0] = question88A;
		this.answers [88, 1] = question88B;
		this.answers [89, 0] = question89A;
		this.answers [89, 1] = question89B;
		this.answers [90, 0] = question90A;
		this.answers [90, 1] = question90B;
		this.answers [91, 0] = question91A;
		this.answers [91, 1] = question91B;
		this.answers [92, 0] = question92A;
		this.answers [92, 1] = question92B;
		this.answers [93, 0] = question93A;
		this.answers [93, 1] = question93B;
		this.answers [94, 0] = question94A;
		this.answers [94, 1] = question94B;
		this.answers [95, 0] = question95A;
		this.answers [95, 1] = question95B;
		this.answers [96, 0] = question96A;
		this.answers [96, 1] = question96B;
		this.answers [97, 0] = question97A;
		this.answers [97, 1] = question97B;
		this.answers [98, 0] = question98A;
		this.answers [98, 1] = question98B;
		this.answers [99, 0] = question99A;
		this.answers [99, 1] = question99B;
		this.answers [100, 0] = question100A;
		this.answers [100, 1] = question100B;
		this.answers [101, 0] = question101A;
		this.answers [101, 1] = question101B;
		this.answers [102, 0] = question102A;
		this.answers [102, 1] = question102B;
		this.answers [103, 0] = question103A;
		this.answers [103, 1] = question103B;
		this.answers [104, 0] = question104A;
		this.answers [104, 1] = question104B;
		this.answers [105, 0] = question105A;
		this.answers [105, 1] = question105B;
		this.answers [106, 0] = question106A;
		this.answers [106, 1] = question106B;
		this.answers [107, 0] = question107A;
		this.answers [107, 1] = question107B;
		this.answers [108, 0] = question108A;
		this.answers [108, 1] = question108B;
		this.answers [109, 0] = question109A;
		this.answers [109, 1] = question109B;
		this.answers [110, 0] = question110A;
		this.answers [110, 1] = question110B;
		this.answers [111, 0] = question111A;
		this.answers [111, 1] = question111B;
		this.answers [112, 0] = question112A;
		this.answers [112, 1] = question112B;
		this.answers [113, 0] = question113A;
		this.answers [113, 1] = question113B;
		this.answers [114, 0] = question114A;
		this.answers [114, 1] = question114B;
		this.answers [115, 0] = question115A;
		this.answers [115, 1] = question115B;
		this.answers [116, 0] = question116A;
		this.answers [116, 1] = question116B;
		this.answers [117, 0] = question117A;
		this.answers [117, 1] = question117B;
		this.answers [118, 0] = question118A;
		this.answers [118, 1] = question118B;
		this.answers [119, 0] = question119A;
		this.answers [119, 1] = question119B;
		this.answers [120, 0] = question120A;
		this.answers [120, 1] = question120B;
		this.answers [121, 0] = question121A;
		this.answers [121, 1] = question121B;
		this.answers [122, 0] = question122A;
		this.answers [122, 1] = question122B;
		this.answers [123, 0] = question123A;
		this.answers [123, 1] = question123B;
		this.answers [124, 0] = question124A;
		this.answers [124, 1] = question124B;
		this.answers [125, 0] = question125A;
		this.answers [125, 1] = question125B;
		this.answers [126, 0] = question126A;
		this.answers [126, 1] = question126B;
		this.answers [127, 0] = question127A;
		this.answers [127, 1] = question127B;
		this.answers [128, 0] = question128A;
		this.answers [128, 1] = question128B;
		this.answers [129, 0] = question129A;
		this.answers [129, 1] = question129B;
		this.answers [130, 0] = question130A;
		this.answers [130, 1] = question130B;
		this.answers [131, 0] = question131A;
		this.answers [131, 1] = question131B;
		this.answers [132, 0] = question132A;
		this.answers [132, 1] = question132B;
		this.answers [133, 0] = question133A;
		this.answers [133, 1] = question133B;
		this.answers [134, 0] = question134A;
		this.answers [134, 1] = question134B;
		this.answers [135, 0] = question135A;
		this.answers [135, 1] = question135B;
		this.answers [136, 0] = question136A;
		this.answers [136, 1] = question136B;
		this.answers [137, 0] = question137A;
		this.answers [137, 1] = question137B;
		this.answers [138, 0] = question138A;
		this.answers [138, 1] = question138B;
		this.answers [139, 0] = question139A;
		this.answers [139, 1] = question139B;
		this.answers [140, 0] = question140A;
		this.answers [140, 1] = question140B;
		this.answers [141, 0] = question141A;
		this.answers [141, 1] = question141B;
		this.answers [142, 0] = question142A;
		this.answers [142, 1] = question142B;
		this.answers [143, 0] = question143A;
		this.answers [143, 1] = question143B;
		this.answers [144, 0] = question144A;
		this.answers [144, 1] = question144B;
		this.answers [145, 0] = question145A;
		this.answers [145, 1] = question145B;
		this.answers [146, 0] = question146A;
		this.answers [146, 1] = question146B;
		this.answers [147, 0] = question147A;
		this.answers [147, 1] = question147B;
		this.answers [148, 0] = question148A;
		this.answers [148, 1] = question148B;
		this.answers [149, 0] = question149A;
		this.answers [149, 1] = question149B;
		this.answers [150, 0] = question150A;
		this.answers [150, 1] = question150B;
		this.answers [151, 0] = question151A;
		this.answers [151, 1] = question151B;
		this.answers [152, 0] = question152A;
		this.answers [152, 1] = question152B;
		this.answers [153, 0] = question153A;
		this.answers [153, 1] = question153B;
		this.answers [154, 0] = question154A;
		this.answers [154, 1] = question154B;
		this.answers [155, 0] = question155A;
		this.answers [155, 1] = question155B;
		this.answers [156, 0] = question156A;
		this.answers [156, 1] = question156B;
		this.answers [157, 0] = question157A;
		this.answers [157, 1] = question157B;
		this.answers [158, 0] = question158A;
		this.answers [158, 1] = question158B;
		this.answers [159, 0] = question159A;
		this.answers [159, 1] = question159B;
		this.answers [160, 0] = question160A;
		this.answers [160, 1] = question160B;
		this.answers [161, 0] = question161A;
		this.answers [161, 1] = question161B;
		this.answers [162, 0] = question162A;
		this.answers [162, 1] = question162B;
		this.answers [163, 0] = question163A;
		this.answers [163, 1] = question163B;
		this.answers [164, 0] = question164A;
		this.answers [164, 1] = question164B;
		this.answers [165, 0] = question165A;
		this.answers [165, 1] = question165B;
		this.answers [166, 0] = question166A;
		this.answers [166, 1] = question166B;
		this.answers [167, 0] = question167A;
		this.answers [167, 1] = question167B;
		this.answers [168, 0] = question168A;
		this.answers [168, 1] = question168B;
		this.answers [169, 0] = question169A;
		this.answers [169, 1] = question169B;
		this.answers [170, 0] = question170A;
		this.answers [170, 1] = question170B;
		this.answers [171, 0] = question171A;
		this.answers [171, 1] = question171B;
		this.answers [172, 0] = question172A;
		this.answers [172, 1] = question172B;
		this.answers [173, 0] = question173A;
		this.answers [173, 1] = question173B;
		this.answers [174, 0] = question174A;
		this.answers [174, 1] = question174B;
		this.answers [175, 0] = question175A;
		this.answers [175, 1] = question175B;
		this.answers [176, 0] = question176A;
		this.answers [176, 1] = question176B;
		this.answers [177, 0] = question177A;
		this.answers [177, 1] = question177B;
		this.answers [178, 0] = question178A;
		this.answers [178, 1] = question178B;
		this.answers [179, 0] = question179A;
		this.answers [179, 1] = question179B;
		this.answers [180, 0] = question180A;
		this.answers [180, 1] = question180B;
		this.answers [181, 0] = question181A;
		this.answers [181, 1] = question181B;
		this.answers [182, 0] = question182A;
		this.answers [182, 1] = question182B;
		this.answers [183, 0] = question183A;
		this.answers [183, 1] = question183B;
		this.answers [184, 0] = question184A;
		this.answers [184, 1] = question184B;
		this.answers [185, 0] = question185A;
		this.answers [185, 1] = question185B;
		foreach (int i in goodQuestionIDs) {
			goodQuestions.Add (i);
		}
	}

	public int RandomAge (int ageMin, int ageMax) {
		return Random.Range (ageMin, ageMax);
	}

	public bool RandomSex (float maleProbability){
		float randomSex = Random.value;
		if (maleProbability <= randomSex) {
			return true;
		} else {
			return false;
		}
	}

	public Race RandomRace (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability){
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

	public Personality RandomPersonality (int age, bool male, Race race){
		if (age <= 50) {
			return Personality.personalityA;
		} else {
			return Personality.personalityB;
		}
	}

	public void OverwriteHistory (History history, string historyKey, string historyValue){
		history.history [historyKey] = historyValue;
	}

}
