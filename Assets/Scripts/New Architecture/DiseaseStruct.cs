using System;
using UnityEngine;

namespace AssemblyCSharp {
	
	public class DiseaseStruct {
		
		private DiseaseInstance[] disease_list;

		public DiseaseStruct (int size) {
			disease_list = new DiseaseInstance[size];
			disease_list[0] = new DiseaseInstance ("Asthma", 5, 10, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
			disease_list[1] = new DiseaseInstance ("Bronchitis", 20, 50, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
			disease_list[2] = new DiseaseInstance ("COPD", 60, 90, 0.9f, 0.25f, 0.25f, 0.25f, 0.25f);
		}

		public DiseaseInstance GetDiseaseFromList(int index) {
			return disease_list [index];
		}

		public void OutputData(int index) {
			Debug.Log(disease_list[index].disease_name);
		}
	}

}

