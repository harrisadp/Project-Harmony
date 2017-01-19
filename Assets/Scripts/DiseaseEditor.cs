using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DiseaseEditor : EditorWindow {

	public DiseaseList diseaseList;
	private int viewIndex = 1;

	[MenuItem ("Window/Disease Editor %#e")]
	static void  Init () 
	{
		EditorWindow.GetWindow (typeof (DiseaseEditor));
	}

	void  OnEnable () {
		if(EditorPrefs.HasKey("ObjectPath")) 
		{
			string objectPath = EditorPrefs.GetString("ObjectPath");
			diseaseList = AssetDatabase.LoadAssetAtPath (objectPath, typeof(DiseaseList)) as DiseaseList;
		}

	}

	void  OnGUI () {
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Disease Editor", EditorStyles.boldLabel);
		if (diseaseList != null) {
			if (GUILayout.Button("Show Disease List")) 
			{
				EditorUtility.FocusProjectWindow();
				Selection.activeObject = diseaseList;
			}
		}
		if (GUILayout.Button("Open Disease List")) 
		{
			OpenItemList();
		}
		if (GUILayout.Button("New Disease List")) 
		{
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = diseaseList;
		}
		GUILayout.EndHorizontal ();

		if (diseaseList == null) 
		{
			GUILayout.BeginHorizontal ();
			GUILayout.Space(10);
			if (GUILayout.Button("Create New Disease List", GUILayout.ExpandWidth(false))) 
			{
				CreateNewItemList();
			}
			if (GUILayout.Button("Open Existing Disease List", GUILayout.ExpandWidth(false))) 
			{
				OpenItemList();
			}
			GUILayout.EndHorizontal ();
		}

		GUILayout.Space(20);

		if (diseaseList != null) 
		{
			GUILayout.BeginHorizontal ();

			GUILayout.Space(10);

			if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) 
			{
				if (viewIndex > 1)
					viewIndex --;
			}
			GUILayout.Space(5);
			if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) 
			{
				if (viewIndex < diseaseList.diseaseList.Count) 
				{
					viewIndex ++;
				}
			}

			GUILayout.Space(60);

			if (GUILayout.Button("Add Disease", GUILayout.ExpandWidth(false))) 
			{
				AddItem();
			}
			if (GUILayout.Button("Delete Disease", GUILayout.ExpandWidth(false))) 
			{
				DeleteItem(viewIndex - 1);
			}

			GUILayout.EndHorizontal ();
			if (diseaseList.diseaseList == null)
				Debug.Log("wtf");
			if (diseaseList.diseaseList.Count > 0) 
			{
				GUILayout.BeginHorizontal ();
				viewIndex = Mathf.Clamp (EditorGUILayout.IntField ("Current Disease", viewIndex, GUILayout.ExpandWidth(false)), 1, diseaseList.diseaseList.Count);
				//Mathf.Clamp (viewIndex, 1, inventoryItemList.itemList.Count);
				EditorGUILayout.LabelField ("of   " +  diseaseList.diseaseList.Count.ToString() + "  diseases", "", GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();

				diseaseList.diseaseList[viewIndex-1].diseaseName = EditorGUILayout.TextField ("Disease Name", diseaseList.diseaseList[viewIndex-1].diseaseName as string);

				GUILayout.Space(10);

				GUILayout.BeginHorizontal ();

				GUILayout.EndHorizontal ();

				GUILayout.Space(10);

				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].ageMin = EditorGUILayout.IntField("Minimum Age", diseaseList.diseaseList[viewIndex-1].ageMin,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].ageMax = EditorGUILayout.IntField("Maximum Age", diseaseList.diseaseList[viewIndex-1].ageMax,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].maleProbability = EditorGUILayout.FloatField("Male Probability", diseaseList.diseaseList[viewIndex-1].maleProbability,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].asianProbability = EditorGUILayout.FloatField("Asian Probability", diseaseList.diseaseList[viewIndex-1].asianProbability,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].blackProbability = EditorGUILayout.FloatField("Black Probability", diseaseList.diseaseList[viewIndex-1].blackProbability,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].hispanicProbability = EditorGUILayout.FloatField("Hispanic Probability", diseaseList.diseaseList[viewIndex-1].hispanicProbability,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].whiteProbability = EditorGUILayout.FloatField("White Probability", diseaseList.diseaseList[viewIndex-1].whiteProbability,  GUILayout.ExpandWidth(false));
				GUILayout.EndHorizontal ();

				GUILayout.Space(10);

				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].introPersonality1 = EditorGUILayout.TextField("Intro Personality 1", diseaseList.diseaseList[viewIndex-1].introPersonality1,  GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].introPersonality2 = EditorGUILayout.TextField("Intro Personality 2", diseaseList.diseaseList[viewIndex-1].introPersonality2,  GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].introPersonality3 = EditorGUILayout.TextField("Intro Personality 3", diseaseList.diseaseList[viewIndex-1].introPersonality3,  GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].introPersonality4 = EditorGUILayout.TextField("Intro Personality 4", diseaseList.diseaseList[viewIndex-1].introPersonality4,  GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].introPersonality5 = EditorGUILayout.TextField("Intro Personality 5", diseaseList.diseaseList[viewIndex-1].introPersonality5,  GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal ();
				GUILayout.BeginHorizontal ();
				diseaseList.diseaseList[viewIndex-1].introPersonality6 = EditorGUILayout.TextField("Intro Personality 6", diseaseList.diseaseList[viewIndex-1].introPersonality6,  GUILayout.ExpandWidth(true));
				GUILayout.EndHorizontal ();

				GUILayout.Space(10);

			} 
			else 
			{
				GUILayout.Label ("This Inventory List is Empty.");
			}
		}
		if (GUI.changed) 
		{
			EditorUtility.SetDirty(diseaseList);
		}
	}

	void CreateNewItemList () 
	{
		// There is no overwrite protection here!
		// There is No "Are you sure you want to overwrite your existing object?" if it exists.
		// This should probably get a string from the user to create a new name and pass it ...
		viewIndex = 1;
		diseaseList = CreateDiseaseList.Create();
		if (diseaseList) 
		{
			diseaseList.diseaseList = new List<Disease>();
			string relPath = AssetDatabase.GetAssetPath(diseaseList);
			EditorPrefs.SetString("ObjectPath", relPath);
		}
	}

	void OpenItemList () 
	{
		string absPath = EditorUtility.OpenFilePanel ("Select Disease List", "", "");
		if (absPath.StartsWith(Application.dataPath)) 
		{
			string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
			diseaseList = AssetDatabase.LoadAssetAtPath (relPath, typeof(DiseaseList)) as DiseaseList;
			if (diseaseList.diseaseList == null)
				diseaseList.diseaseList = new List<Disease>();
			if (diseaseList) {
				EditorPrefs.SetString("ObjectPath", relPath);
			}
		}
	}

	void AddItem () 
	{
		Disease newDisease = new Disease();
		newDisease.diseaseName = "New Disease";
		diseaseList.diseaseList.Add (newDisease);
		viewIndex = diseaseList.diseaseList.Count;
	}

	void DeleteItem (int index) 
	{
		diseaseList.diseaseList.RemoveAt (index);
	}
}