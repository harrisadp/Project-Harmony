﻿using System;
using UnityEngine;

namespace AssemblyCSharp {
	
	public class DiseaseStruct {
		
		private DiseaseInstance[] disease_list;

		public DiseaseStruct (int size) {
			disease_list = new DiseaseInstance[size];
			disease_list[0] = new DiseaseInstance ("Asthma", 5, 10, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f, "I can't breath.", "I can't breath! Help!", "It started about an hour ago.", "Just an hour ago!", "I'm not in any pain; I just can't breathe.", "I ain't in any pain! Just help me breathe!", "3a", "3b", "4a", "4b", "5a", "5b", "6a", "6b", "7a", "7b", "8a", "8b", "9a", "9b", "10a", "10b", "11a", "11b", "12a", "12b", "13a", "13b", "14a", "14b", "15a", "15b", new int[] {0,1});
			disease_list[1] = new DiseaseInstance ("Bronchitis", 20, 50, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f, "I have a terrible cough.", "I can't stop coughing!", "It started about a week ago.", "Just a week ago!", "I'm not in that much pain. My throat is a little sore from the coughing, though.", "No pain! Just the throat is a little sore!", "3a", "3b", "4a", "4b", "5a", "5b", "6a", "6b", "7a", "7b", "8a", "8b", "9a", "9b", "10a", "10b", "11a", "11b", "12a", "12b", "13a", "13b", "14a", "14b", "15a", "15b", new int[] {0,2});
			disease_list[2] = new DiseaseInstance ("COPD", 60, 90, 0.9f, 0.25f, 0.25f, 0.25f, 0.25f, "I can't breath.", "I can't breath! Help!", "It's been off and on for years.", "I've had this for years!", "I'm not in any pain; I just can't breathe.", "I ain't in any pain! Just help me breathe!", "3a", "3b", "4a", "4b", "5a", "5b", "6a", "6b", "7a", "7b", "8a", "8b", "9a", "9b", "10a", "10b", "11a", "11b", "12a", "12b", "13a", "13b", "14a", "14b", "15a", "15b", new int[] {0,1});
		}

		public DiseaseInstance GetDiseaseFromList(int index) {
			return disease_list [index];
		}

		public void OutputData(int index) {
			Debug.Log(disease_list[index].disease_name);
		}
	}

}

