using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateDiseaseList {
	[MenuItem("Assets/Create/Disease List")]
	public static DiseaseList  Create()
	{
		DiseaseList asset = ScriptableObject.CreateInstance<DiseaseList>();

		AssetDatabase.CreateAsset(asset, "Assets/DiseaseList.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
}