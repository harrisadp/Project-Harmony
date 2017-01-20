using UnityEngine;
using System.Collections;

[System.Serializable]
public class Disease 
{
	// Name
	public string diseaseName = "New Disease";
	// Demographic information
	public int ageMin = 1;
	public int ageMax = 100;
	public float maleProbability = 0.5f;
	public float asianProbability = 0.25f;
	public float blackProbability = 0.25f;
	public float hispanicProbability = 0.25f;
	public float whiteProbability = 0.25f;
	// Dialogue
	// Intro
	public string[] intro;
	// History of Presenting Illness
	public string[] whenWereYouLastCompletelyWell;
	public string[] whenDidThePainFirstStart;
	public string[] howWouldYouDescribeYourPain;
	public string[] whereIsThePainLocated;
	public string[] doesThePainMoveAnywhere;
	public string[] howDidThePainFirstStart;
	public string[] howSevereIsYourPain;
	public string[] haveYouEverHadASimilarPainInThePast;
	public string[] doesAnythingMakeThePainBetterOrWorse;
	public string[] whatHasBeenTheImpactOfThisProblemOnYourLife;
	public string[] whoElseHaveYouSeenAboutThisProblem;
	public string[] whatTreatmentsHaveBeenRecommendedForThisProblem;
	public string[] whatMedicationsIncludingNonPrescriptionMedicationsHaveYouUsedForThisProblem;
	public string[] haveYouHadAnyTestsRelatedToThisProblem;
	public string[] isThereAnythingElseBotheringYou;
}