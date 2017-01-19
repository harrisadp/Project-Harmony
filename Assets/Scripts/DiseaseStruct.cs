using System;

namespace AssemblyCSharp
{
	public class DiseaseStruct
	{
		private Person disease_list;

		//This constructor should be called once in some start up code that runs at program start
		public DiseaseStruct (int size)
		{
			disease_list = new Person[size];

			//The benefit of storing the data like this is that it would be really easy to generate this from an excel sheet
			disease_list[0] = new Person("Asthma", 20, 60, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f);
			disease_list[1] = new Person(/*Next Disease*/);
		}

		public Person GetDiseaseFromList(int index)
		{
			return disease_list [index];
		}

	}
}

