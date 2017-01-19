using System;


//This class should contain all your disease information
//It is effectually a giant list calling the disease constructor once for each disease you want to include
namespace AssemblyCSharp
{
	public class BigBadDiseaseStruct
	{
		private Disease huge_list;

		//This constructor should be called once in some start up code that runs at program start
		public BigBadDiseaseStruct (int size)
		{
			//Create new diseases
			huge_list = new Disease[size];

			//The benefit of storing the data like this is that it would be really easy to generate this from an excel sheet
			huge_list[0] = new Disease("Cancer", 20, 60, 0.5, /*race probabilities*/);
			huge_list[1] = new Disease(/*Next Disease*/);
		}

		public Disease GetDiseaseFromList(int index)
		{
			return huge_list [index];
		}

	}
}

