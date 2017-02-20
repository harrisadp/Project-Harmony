using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour {

	public Dictionary<string, string> history = new Dictionary<string, string>();

	void Awake () {
		// Introduction
		history ["Intro"] = "[Intro]";
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
		history ["What medications, including non-prescription medications, have you used for this problem"] = "[What medications, including non-prescription medications, have you used for this problem]";
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
		history ["Are you currently employed"] = "[Are you currently employed]";
		history ["What is your marital status"] = "[What is your marital status]";
		history ["Are you currently sexually active"] = "[Are you currently sexually active]";
		history ["Is your preferred sexual partner of the opposite sex or the same sex"] = "[Is your preferred sexual partner of the opposite sex of the same sex]";
		history ["Do you use contraception"] = "[Do you use contraception]";
		history ["Have you ever been diagnosed with a sexually transmitted infection"] = "[Have you ever been diagnosed with a sexually transmitted infection]";
		history ["Have you ever been the victim of sexual abuse"] = "[Have you ever been the victim of sexual abuse]";
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
		// Review of Systems
		// General
		history ["How are your energy levels"] = "[How are your energy levels]";
		history ["Have you noticed any significant weight gain"] = "[Have you noticed any significant weight gain]";
		history ["Have you noticed any significant weight loss"] = "[Have you noticed any significant weight loss]";
		history ["Do you have any difficulty sleeping"] = "[Do you have any difficulty sleeping]";
		history ["Have you experienced any fevers or chills"] = "[Have you experienced any fevers or chills]";
		history ["Have you experienced any drenching night sweats"] = "[Have you experienced any drenching night sweats]";
		// Musculoskeletal
		history ["Do you have any pains, stiffness, or swelling in your joints"] = "[Do you have any pains, stiffness, or swelling in your joints]";
		history ["Do you have backaches"] = "[Do you have backaches]";
		history ["Do you have pains in your legs"] = "[Do you have pains in your legs]";
		history ["Do you have pains or cramps in your muscles"] = "[Do you have pains or cramps in your muscles]";
		// Psychiatric
		history ["Do you feel nervous"] = "[Do you feel nervous]";
		history ["Do you feel anxious"] = "[Do you feel anxious]";
		history ["Do you feel depressed"] = "[Do you feel depressed]";
		// Respiratory
		history ["Do you ever feel short of breath on exertion"] = "[Do you ever feel short of breath on exertion]";
		history ["Has your breathing changed over the past month"] = "[Has your breathing changed over the past month]";
		history ["Do you suffer from a cough"] = "[Do you suffer from a cough]";
		history ["Is your cough productive"] = "[Is your cough productive]";
		history ["What color is the sputum"] = "[What color is the sputum]";
		history ["Have you traveled anywhere outside of the country recently"] = "[Have you traveled anywhere outside of the country recently]";
		history ["Did you travel by airplane for long distances"] = "[Did you travel by airplane for long distances]";
		history ["Have you been in contact with any individuals who are sick"] = "[Have you been in contact with any individuals who are sick]";
		history ["Do you work in or frequently visit a healthcare facility"] = "[Do you work in or frequently visit a healthcare facility]";
		history ["Have you ever lived in a shelter or prison"] = "[Have you ever lived in a shelter or prison]";
		history ["Have you ever worked in a shipyard"] = "[Have you ever worked in a shipyard]";
		history ["Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis"] = "[Have you ever been exposed or in contact with an individual who is diagnosed with tuberculosis]";
		history ["Have you ever had a tuberculosis skin test"] = "[Have you ever had a tuberculosis skin test]";
		// Cardiovascular
		history ["Have you ever experienced chest pain on exertion before"] = "[Have you ever experienced chest pain on exertion before]";
		history ["Do you experience palpitations"] = "[Do you experience palpitations]";
		history ["Have you ever had a heart attack"] = "[Have you ever had a heart attack]";
		history ["Have you noticed any swelling in your ankles"] = "[Have you noticed any swelling in your ankles]";
		history ["Have you noticed any change in waist circumference"] = "[Have you noticed any change in waist circumference]";
		history ["Do you ever wake up in the middle of the night gasping for air"] = "[Do you ever wake up in the middle of the night gasping for air]";
		history ["Do you experience any difficulty with your breathing when you lie flat"] = "[Do you experience any difficulty with your breathing when you lie flat]";
		history ["How many pillows do you sleep with at night"] = "[How many pillows do you sleep with at night]";
		history ["Have you ever fainted"] = "[Have you ever fainted]";
		history ["Have you experienced any pain in your legs while walking"] = "[Have you experienced any pain in your legs while walking]";
		history ["Do your legs feel cold"] = "[Do your legs feel cold]";
		history ["Is there any history in your family of sudden cardiac death"] = "[Is there any history in your family of sudden cardiac death]";
		history ["Have you recently had a cold or flu"] = "[Have you recently had a cold or flu]";
		history ["Have you ever been told you have a heart murmur"] = "[Have you ever been told you have a heart murmur]";
		history ["Did you ever have rheumatic heart disease as a child"] = "[Did you ever have rheumatic heart disease as a child]";
		// Gastrointestinal
		history ["How is your appetite"] = "[How is your appetite]";
		history ["Does food ever get stuck in your throat"] = "[Does food ever get stuck in your throat]";
		history ["Do you ever experience pain while swallowing"] = "[Do you ever experience pain while swallowing]";
		history ["Do you have difficulty swallowing solids, or liquids, or both"] = "[Do you have difficulty swallowing solids, or liquids, or both]";
		history ["Do you suffer from heartburn"] = "[Do you suffer from heartburn]";
		history ["Have you ever felt that you get full really quickly during meals"] = "[Have you ever felt that you get full really quickly during meals]";
		history ["Have you experienced any nausea or vomiting"] = "[Have you experienced any nausea or vomiting]";
		history ["Have you experienced any abdominal bloating"] = "[Have you experienced any abdominal bloating]";
		history ["Have you had any diarrhea"] = "[Have you had any diarrhea]";
		history ["Have you had any constipation"] = "[Have you had any constipation]";
		history ["Have you ever had any blood in your stool"] = "[Have you ever had any blood in your stool]";
		history ["Have you ever had any black, tarry stools"] = "[Have you ever had any black, tarry stools]";
		history ["Do you experience any pain while passing bowel movements"] = "[Do you experience any pain while passing bowel movements]";
		history ["Do you ever have any pale, fatty stools"] = "[Do you ever have any pale, fatty stools]";
		history ["Have you taken any antibiotics recently"] = "[Have you taken any antibiotics recently]";
		history ["Are your stools foul-smelling"] = "[Are your stools foul-smelling]";
		history ["Have you ever vomited blood"] = "[Have you ever vomited blood]";
		history ["Was it bright red blood"] = "[Was it bright red blood]";
		history ["Did it look like coffee grounds"] = "[Did it look like coffee grounds]";
		history ["Have you ever had a colonoscopy"] = "[Have you ever had a colonoscopy]";
		history ["Have you ever had a gastroscopy"] = "[Have you ever had a gastroscopy]";
		history ["Have you had any recent travel outside of the country"] = "[Have you had any recent travel outside of the country]";
		history ["Have you noticed any yellowing of the eyes or skin"] = "[Have you noticed any yellowing of the eyes or skin]";
		history ["Have you experienced any easy bruising or bleeding"] = "[Have you experienced any easy bruising or bleeding]";
		history ["Have you noticed any enlargement of your breast tissue"] = "[Have you noticed any enlargement of your breast tissue]";
		history ["Have you noticed any muscle wasting"] = "[Have you noticed any muscle wasting]";
		// Neurologic
		history ["Have you ever had a stroke"] = "[Have you ever had a stroke]";
		history ["Was it due to a blood clot or a bleed"] = "[Was it due to a blood clot or a bleed]";
		history ["Do you have any residual symptoms"] = "[Do you have any residual symptoms]";
		history ["Have you ever had a seizure"] = "[Have you ever had a seizure]";
		history ["Have you experienced double-vision"] = "[Have you experienced double-vision]";
		history ["Have you experienced blurred vision"] = "[Have you experienced blurred vision]";
		history ["Have you or others noticed any asymmetry in your face"] = "[Have you or others noticed any asymmetry in your face]";
		history ["Have you experienced any slurring of your speech"] = "[Have you experienced any slurring of your speech]";
		history ["Have you experienced any numbness or tingling in your body"] = "[Have you experienced any numbness or tingling in your body]";
		history ["Have you experienced any weakness on one side of your body"] = "[Have you experienced any weakness on one side of your body]";
		history ["Have you ever lost control of your bowels or bladder"] = "[Have you ever lost control of your bowels or bladder]";
		history ["Do you use any walking aids"] = "[Do you use any walking aids]";
		history ["Do you have difficulty buttoning your shirts"] = "[Do you have difficulty buttoning your shirts]";
		history ["Have you noticed a tremor"] = "[Have you noticed a tremor]";
		history ["Have you had any problems with balance or coordination"] = "[Have you had any problems with balance or coordination]";
		history ["Have you noticed any changes in your voice"] = "[Have you noticed any changes in your voice]";
		history ["Do you find that you choke or cough when you eat or drink"] = "[Do you find that you choke or cough when you eat or drink]";
		history ["Have you noticed any changes with your memory"] = "[Have you noticed any changes with your memory]";
		history ["Have you ever left the tap or the stove on in your house"] = "[Have you ever left the tap or the stove on in your house]";
		history ["Do you drive a car"] = "[Do you drive a car]";
		history ["Have you ever fainted"] = "[Have you ever fainted]";
		history ["Do you suffer from any headache"] = "[Do you suffer from any headache]";
		history ["Is it the worst headache you've ever had"] = "[Is it the worst headache you've ever had]";
		history ["Have you had any associated nausea or vomiting"] = "[Have you had any associated nausea or vomiting]";
		history ["Have you experienced any scalp tenderness or pain in your jaw"] = "[Have you experienced any scalp tenderness or pain in your jaw]";
		// Hematologic
		history ["How difficult is it to stop bleeding when you have a small cut"] = "[How difficult is it to stop bleeding when you have a small cut]";
		history ["Do you have anemia"] = "[Do you have anemia]";
		history ["Have you ever had a blood transfusion"] = "[Have you ever had a blood transfusion]";
		history ["Did you experience any problems with the blood transfusion"] = "[Did you experience any problems with the blood transfusion]";
		history ["Do you bruise easily"] = "[Do you bruise easily]";
		// Endocrine
		history ["How well do you tolerate the heat"] = "[How well do you tolerate the heat]";
		history ["How well do you tolerate the cold"] = "[How well do you tolerate the cold]";
		history ["Do you urinate frequently"] = "[Do you urinate frequently]";
		history ["Are you excessively hungry"] = "[Are you excessively hungry]";
		history ["Are you excessively thirsty"] = "[Are you excessively thirsty]";
		history ["Do you sweat excessively"] = "[Do you sweat excessively]";
		history ["Have you noticed any changes to your skin or hair"] = "[Have you noticed any changes to your skin or hair]";
		// Genitourinary
		history ["Do you have any pain on urination"] = "[Do you have any pain on urination]";
		history ["Have you experienced an increased frequency in urinating"] = "[Have you experienced an increased frequency in urinating]";
		history ["How often do you urinate at night"] = "[How often do you urinate at night]";
		history ["Do you often feel the urge to urinate"] = "[Do you often feel the urge to urinate]";
		history ["Do you find it difficult to begin urinating"] = "[Do you find it difficult to begin urinating]";
		history ["Have you ever had blood in your urine"] = "[Have you ever had blood in your urine]";
		history ["Is your urine foamy"] = "[Is your urine foamy]";
		history ["Have you been experiencing any flank pain"] = "[Have you been experiencing any flank pain]";
		history ["Have you noticed any skin changes to your external genitalia"] = "[Have you noticed any skin changes to your external genitalia]";
		// Gynecologic
		history ["How many times have you been pregnant"] = "[How many times have you been pregnant]";
		history ["How many children have you had"] = "[How many children have you had]";
		history ["Have you ever had an abortion (spontaneous or elective)"] = "[Have you ever had an abortion (spontaneous or elective)]";
		history ["When was your last menstrual period"] = "[When was your last menstrual period]";
		history ["What are your periods usually like"] = "[What are your periods usually like]";
		history ["When was your last Pap smear"] = "[When was your last Pap smear]";
		history ["Have you ever had an abnormal Pap smear" ] = "[Have you ever had an abnormal Pap smear]";
		// Oropharynx
		history ["Have you experienced any change in your voice"] = "[Have you experienced any change in your voice]";
		history ["Do you get frequent sore throats"] = "[Do you get frequent sore throats]";
		history ["Do you have any problems with your teeth or gums"] = "[Do you have any problems with your teeth or gums]";
		history ["Do you have any bleeding in your mouth"] = "[Do you have any bleeding in your mouth]";
		// Nose and Sinus
		history ["How often do you have nosebleeds"] = "[How often do you have nosebleeds]";
		history ["Do you have any discharge from your nose"] = "[Do you have any discharge from your nose]";
		history ["Do you have difficulty breathing through your nose"] = "[Do you have difficulty breathing through your nose]";
		history ["Have you had a recent cold or infection in your sinuses"] = "[Have you had a recent cold or infection in your sinuses]";
		// Ears
		history ["Do you have problems hearing"] = "[Do you have problems hearing]";
		history ["Have you experienced a ringing in your ears"] = "[Have you experienced a ringing in your ears]";
		history ["Do you have earaches"] = "[Do you have earaches]";
		history ["Have you had an infection or discharge from your ears"] = "[Have you had an infection or discharge from your ears]";
		// Eyes
		history ["Do you wear glasses or contact lenses"] = "[Do you wear glasses or contact lenses]";
		history ["When was your last eye examination"] = "[When was your last eye examination]";
		history ["Have you had any recent changes to your vision"] = "[Have you had any recent changes to your vision]";
		history ["Do you have excessive tearing in your eyes"] = "[Do you have excessive tearing in your eyes]";
		history ["Have you had any pain or redness in your eyes"] = "[Have you had any pain or redness in your eyes]";
		// Head
		history ["Have you had any injury to your head"] = "[Have you had any injury to your head]";
		history ["Have you had a stiff neck"] = "[Have you had a stiff neck]";
		// Dermatologic
		history ["Do you have any lumps on your skin"] = "[Do you have any lumps on your skin]";
		history ["Do you have any rashes on your skin"] = "[Do you have any rashes on your skin]";
		history ["Do you have any itching, or dry skin"] = "[Do you have any itching, or dry skin]";
		history ["Have you noticed any changes to your fingernails"] = "[Have you noticed any changes to your finger nails]";
		history ["Have you noticed any changes to your hair growth"] = "[Have you noticed any changes to your hair growth]";
	}

}
