using UnityEngine;
using System.Collections;

[System.Serializable]
public class Disease 
{
	public string diseaseName = "New Disease";
	public int ageMin = 1;
	public int ageMax = 100;
	public float maleProbability = 0.5f;
	public float asianProbability = 0.25f;
	public float blackProbability = 0.25f;
	public float hispanicProbability = 0.25f;
	public float whiteProbability = 0.25f;
}