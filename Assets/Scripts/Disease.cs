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
	public string introPersonality1;
	public string introPersonality2;
	public string introPersonality3;
	public string introPersonality4;
	public string introPersonality5;
	public string introPersonality6;
	// History of Presenting Illness
	// When were you last completely well
	public string whenWereYouLastCompletelyWellPersonality1;
	public string whenWereYouLastCompletelyWellPersonality2;
	public string whenWereYouLastCompletelyWellPersonality3;
	public string whenWereYouLastCompletelyWellPersonality4;
	public string whenWereYouLastCompletelyWellPersonality5;
	public string whenWereYouLastCompletelyWellPersonality6;
}