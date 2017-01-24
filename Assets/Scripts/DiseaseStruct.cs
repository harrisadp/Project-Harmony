using System;
using UnityEngine;

namespace AssemblyCSharp {
	
	public class DiseaseStruct {
		
		private Person[] disease_list;

		public DiseaseStruct (int size) {
			disease_list = new Person[size];
			disease_list[0] = new Person("Asthma", 5, 10, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
			disease_list[1] = new Person("Bronchitis", 20, 50, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
			disease_list[2] = new Person("COPD", 60, 90, 0.9f, 0.25f, 0.25f, 0.25f, 0.25f);
		}

		public Person GetDiseaseFromList(int index) {
			return disease_list [index];
		}

		public void OutputData(int index) {
			Debug.Log(disease_list[index].disease_name);
		}
	}

}

