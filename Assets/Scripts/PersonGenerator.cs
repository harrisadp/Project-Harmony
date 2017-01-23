using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

	public DiseaseList diseaseList;

	private enum Race {asian, black, hispanic, white};
	private enum Personality {personality1, personality2, personality3, personality4, personality5, personality6};
	private int age;
	private bool male;
	private Race race;
	private Personality personality;
	private History history;
	private PerformanceTracker performanceTracker;

	void Start (){
		history = FindObjectOfType <History> ();
		performanceTracker = FindObjectOfType<PerformanceTracker> ();
	}

	public void GeneratePerson(){
		int randomDisease = Random.Range (0, 1);
		performanceTracker.diseaseChosen = randomDisease;
		RandomAge (diseaseList.diseaseList [randomDisease].ageMin, diseaseList.diseaseList [randomDisease].ageMax);
		RandomSex (diseaseList.diseaseList [randomDisease].maleProbability);
		RandomRace (diseaseList.diseaseList [randomDisease].asianProbability, diseaseList.diseaseList [randomDisease].blackProbability, diseaseList.diseaseList [randomDisease].hispanicProbability, diseaseList.diseaseList [randomDisease].whiteProbability);
		RandomPersonality ();
		OverwriteHistory (randomDisease, (int)personality);
		Debug.Log (diseaseList.diseaseList [randomDisease].diseaseName);
		Debug.Log (age);
		Debug.Log (male);
		Debug.Log (race);
		Debug.Log (personality);
		Debug.Log ("Intro for this patient is: " + history.history ["Intro"]);
		Debug.Log ("Answer 1 for this patient is: " + history.history ["When were you last completely well"]);
	}

	int RandomAge(int ageMin, int ageMax){
		return age = Random.Range (ageMin, ageMax);
	}

	bool RandomSex (float maleProbability){
		float randomSex = Random.value;
		if (randomSex <= maleProbability) {
			return male = true;
		} else {
			return male = false;
		}
	}

	Race RandomRace (float asianProbability, float blackProbability, float hispanicProbability, float whiteProbability){
		float randomRace = Random.value;
		if (randomRace <= asianProbability) {
			return race = Race.asian;
		} else if (randomRace > asianProbability && randomRace <= (asianProbability + blackProbability)){
			return race = Race.black;
		} else if (randomRace > (asianProbability + blackProbability) && randomRace <= (asianProbability + blackProbability + hispanicProbability)) {
			return race = Race.hispanic;
		} else {
			return race = Race.white;
		}
	}

	Personality RandomPersonality (){
		if (age <= 20) {
			return personality = Personality.personality1;
		} else {
			return personality = Personality.personality1;
		}
	}

	void OverwriteHistory (int disease, int personality){
		history.history ["Intro"] = diseaseList.diseaseList [disease].intro[personality];
		history.history ["When were you last completely well"] = diseaseList.diseaseList [disease].whenWereYouLastCompletelyWell[personality];
		history.history ["When did the pain first start"] = diseaseList.diseaseList [disease].whenDidThePainFirstStart [personality];
		history.history ["How would you describe your pain"] = diseaseList.diseaseList [disease].howWouldYouDescribeYourPain [personality];
		history.history ["Where is the pain located"] = diseaseList.diseaseList [disease].whereIsThePainLocated [personality];
		history.history ["Does the pain move anywhere"] = diseaseList.diseaseList [disease].doesThePainMoveAnywhere [personality];
		history.history ["How did the pain first start"] = diseaseList.diseaseList [disease].howDidThePainFirstStart [personality];
		history.history ["How severe is your pain"] = diseaseList.diseaseList [disease].howSevereIsYourPain [personality];
		history.history ["Have you ever had a similar pain in the past"] = diseaseList.diseaseList [disease].haveYouEverHadASimilarPainInThePast [personality];
		history.history ["Does anything make the pain better or worse"] = diseaseList.diseaseList [disease].doesAnythingMakeThePainBetterOrWorse [personality];
		history.history ["What has been the impact of this problem on your life"] = diseaseList.diseaseList [disease].whatHasBeenTheImpactOfThisProblemOnYourLife [personality];
		history.history ["Who else have you seen about this problem"] = diseaseList.diseaseList [disease].whoElseHaveYouSeenAboutThisProblem [personality];
		history.history ["What treatments have been recommended for this problem"] = diseaseList.diseaseList [disease].whatTreatmentsHaveBeenRecommendedForThisProblem [personality];
		history.history ["What medications, including non-prescription medication, have you used for this problem"] = diseaseList.diseaseList [disease].whatMedicationsIncludingNonPrescriptionMedicationsHaveYouUsedForThisProblem [personality];
		history.history ["Have you had any tests related to this problem"] = diseaseList.diseaseList [disease].haveYouHadAnyTestsRelatedToThisProblem [personality];
		history.history ["Is there anything else bothering you"] = diseaseList.diseaseList [disease].isThereAnythingElseBotheringYou [personality];
	}

}
