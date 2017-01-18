using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour {

	public Dictionary<string, string> history = new Dictionary<string, string>();

	void Awake () {
		// Introduction
		history ["Intro"] = "Intro";
		// History of Presenting Illness
		history ["When were you last completely well"] = "[When were you last completely well]";
		history ["When did the pain first start"] = "[When did the pain first start]";
		history ["How would you describe your pain"] = "[How would you describe your pain]";
		history ["Where is the pain located"] = "[Where is the pain located]";
		history ["Does the pain move anywhere"] = "[Does the pain move anywhere]";
		history ["How did the pain first start"] = "[How did the pain first start]";
		history ["How severe is your pain"] = "[How severe is your pain]";
		history ["Have you ever had a similar pain in the past"] = "[Have you ever had a similar pain in the past]";
		history ["Does anything make the pain better or worse"] = "[Does anything make the pain better or worse]";
		history ["What has been the impact of this problem on your life"] = "[What has been the impact of this problem on your life]";
		history ["Who else have you seen about this problem"] = "[Who else have you seen about this problem]";
		history ["What treatments have been recommended for this problem"] = "[What treatments have been recommended for this problem]";
		history ["What medications, including non-prescription medication, have you used for this problem"] = "[What medications, including non-prescription medication, have you used for this problem]";
		history ["Have you had any tests related to this problem"] = "[Have you had any tests related to this problem]";
		history ["Is there anything else bothering you"] = "[Is there anything else bothering you]";
		// Past Medical History
		history ["What medical conditions have you been diagnosed with"] = "[What medical conditions have you been diagnosed with]";
		history ["Have you ever had any operations"] = "[Have you ever had any operations]";
		history ["What diseases have you had as a child"] = "[What diseases have you had as a child]";
		history ["What prescription medications do you take"] = "[What prescription medications do you take]";
		history ["Do you take any over-the-counter medications"] = "[Do you take any over-the-counter medications]";
		history ["Are you allergic to any medications"] = "[Are you allergic to any medications]";
		history ["Are you adherent with your medications"] = "[Are you adherent with your medications]";
		// Family History
		history ["Were you adopted"] = "[Were you adopted]";
		history ["Tell me about your parents health"] = "[Tell me about your parents health]";
		history ["Did anyone in your family, including grandparents, die at a young age"] = "[Did anyone in your family, including grandparents, die at a young age]";
		history ["What was the cause of death"] = "[What was the cause of death]";
		history ["Do any members of your family have blood clotting problems"] = "[Do any members of your family have blood clotting problems]";
		history ["Is there any history of cancer in your family"] = "[Is there any history of cancer in your family]";
		history ["Do any members of your family have heart problems"] = "[Do any members of your family have heart problems]";
		history ["Is there any history of autoimmune disorders in your family"] = "[Is there any history of autoimmune disorders in your family]";
		history ["Are there any other chronic medical conditions that run in your family"] = "[Are there any other chronic medical conditions that run in your family]";
		// Psychosocial History
		history ["Describe your lifestyle and where you are living"] = "[Describe your lifestyle and where you are living]";
		history ["Are you currently employed"] = "[]";
		history ["What is your marital status"] = "[]";
		history ["Is your preferred sexual partner of the opposite sex or the same sex"] = "[]";
		history ["Who lives at home with you"] = "[Who lives at home with you]";
		history ["Do you drink any alcohol"] = "[Do you drink any alcohol]";
		history ["How much do you drink in a week"] = "[How much do you drink in a week]";
		history ["Have you ever thought about cutting down"] = "[Have you ever thought about cutting down]";
		history ["Do you smoke"] = "[Do you smoke]";
		history ["How many years have you smoked"] = "[How many years have you smoked]";
		history ["How many packs per day have you smoked"] = "[How many packs per day have you smoked]";
		history ["Have you ever thought about quitting"] = "[Have you ever thought about quitting]";
		history ["Do you do any illicit or recreational drugs"] = "[Do you do any illicit or recreational drugs]";
		history ["Which drugs do you use and how frequently do you use them"] = "[Which drugs do you use and how frequently do you use them]";
		history ["Have you ever tried to quit using drugs or have been in a detoxification program"] = "[Have you ever tried to quit using drugs or have been in a detoxification program]";
		history ["Where were you born"] = "[Where were you born]";
		history ["What is your financial situation"] = "[What is your financial situation]";
		history ["How active are you"] = "[How active are you]";
	}

}
