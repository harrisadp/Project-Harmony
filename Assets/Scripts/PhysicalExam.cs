using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalExam : MonoBehaviour {

	public Dictionary<string, string> physical = new Dictionary<string, string>();

	void Awake () {
		physical ["HEENT"] = "Head is atraumatic and normocephalic. Pupils are equal, round, and reactive to light and accomodation. Mucus membranes are moist.";
		physical ["CARD"] = "Regular rate and rhythm. Normal S1 and S2. No murmurs, rubs, or gallops. No jugular venous distention. Capillary refill is brisk.";
		physical ["PULM"] = "Lungs are clear to auscultation bilaterally. No increased work of breathing.";
		physical ["ABD"] = "Abdomen is soft, non-tender, and non-distended. Bowel sounds are normoactive.";
		physical ["NEURO"] = "Cranial nerves I - XII intact bilaterally. No focal neurologic deficits.";
		physical ["MSK"] = "No joint inflammation or tenderness. Normal range of motion in all extremities.";
		physical ["SKIN"] = "No rashes or lesions.";
	}
}
