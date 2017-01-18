using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalExam : MonoBehaviour {

	public Dictionary<string, string> physical = new Dictionary<string, string>();

	void Awake () {
		// General inspection
		physical ["General appearance"] = "Patient appears well";
		physical ["Glasgow Coma Scale"] = "15/15";
		// Respiratory
		physical ["Inspection"] = "No abnormalities";
		physical ["Palpation"] = "No abnormalities";
		physical ["Percussion"] = "No abnormalities";
		physical ["Auscultation"] = "Lungs are clear to auscultation bilaterally";
		physical ["Tactile fremitus"] = "No tactile fremitus appreciated";
		physical ["Whispered pectoriloquy"] = "No whispered pectoriloquy";
		physical ["Egophony"] = "No egophony";
		// Cardiac
		physical ["Inspection"] = "No abnormalities";
		physical ["Palpation"] = "No abnormalities";
		physical ["Auscultation"] = "Normal S1 and S2. No murmurs, rubs, or gallups.";
		// Peripheral vasculature
		physical ["Abdomen - Inspection, palpation, and auscultation"] = "No abnormalities";
		physical ["Upper limb - Inspection, palpation, and auscultation"] = "No abnormalities";
		physical ["Lower limb, Inspection, palpation, and auscultation"] = "No abnormalities";
		physical ["Elevation of lower limb"] = "No abnormalities";
		physical ["Dependence of lower limb"] = "No abnormalities";
		// Abdominal
		physical ["General inspection"] = "No abnormalities";
		physical ["Inspection from the side, eyes at bedside level"] = "No abnormalities";
		physical ["Palpation - Superficial"] = "No abnormalities";
		physical ["Palpation - Deep"] = "No abnormalities";
		physical ["Percussion"] = "No abnormalities";
		physical ["Auscultation"] = "No abnormalities";
		// Neck
		physical ["JVP"] = "[JVP]";
		physical ["Thyroid gland"] = "No abnormalities";
		physical ["Carotids"] = "No abnormalities";
		physical ["Lymph node palpation"] = "No abnormalities";
		// Ophthalmologic
		physical ["General inspection"] = "No abnormalities";
		physical ["Fundoscopy"] = "No abnormalities";
		physical ["Slit lamp exam"] = "No abnormalities";
		// Ears
		physical ["General examination"] = "No abnormalities";
		physical ["Otoscopic examination"] = "No abnormalities";
		// Oropharynx
		physical ["General inspection"] = "No abnormalities";
		// Musculoskeletal - Knees
		physical ["Inspection and gait assessment"] = "No abnormalities";
		physical ["Range of movement"] = "No abnormalities";
		physical ["Palpation"] = "No abnormalities";
		physical ["Special tests"] = "No abnormalities";
		// Musculoskeletal - Hips
		physical ["Gait"] = "No abnormalities";
		physical ["Inspection"] = "No abnormalities";
		physical ["Range of movement"] = "No abnormalities";
		physical ["Palpation"] = "No abnormalities";
		physical ["Thomas Test"] = "No abnormalities";
		physical ["Trendelenberg Sign"] = "No abnormalities";
		// Musculoskeletal - Shoulder
		physical ["Inspection"] = "[Inspection]";
		physical ["Range of movement - active"] = "No abnormalities";
		physical ["Range of movement - passive"] = "No abnormalities";
		physical ["Palpation"] = "No abnormalities";
		physical ["Lift-off Test"] = "No abnormalities";
		physical ["Speed’s Test"] = "No abnormalities";
		physical ["Yergason’s Test"] = "No abnormalities";
		// Musculoskeletal - Back
		physical ["Inspection"] = "No abnormalities";
		physical ["Range of movement"] = "No abnormalities";
		physical ["Palpation"] = "No abnormalities";
		physical ["Straight Leg Test"] = "No abnormalities";
		physical ["Shober’s Test"] = "No abnormalities";
		physical ["Leseague’s Test"] = "No abnormalities";
		// Neurological - Cranial nerves
		physical ["Olfactory Nerve (CN I)"] = "No abnormalities";
		physical ["Optic Nerve (CN II)"] = "No abnormalities";
		// CN III
		physical ["Inspection"] = "No abnormalities";
		physical ["Ocular Movements"] = "No abnormalities";
		// CN V
		physical ["Sensation: Light touch"] = "No abnormalities";
		physical ["Sensation: Pain and Temperature"] = "No abnormalities";
		physical ["Sensation: Corneal Reflex"] = "No abnormalities";
		physical ["Motor: Temporalis and masseters"] = "No abnormalities";
		physical ["Motor: Jaw Jerk Reflex"] = "No abnormalities";
		physical ["Motor: Lateral and Medial pterygoids"] = "No abnormalities";
		// CN VII
		physical ["Inspection"] = "No abnormalities";
		physical ["Motor: Muscles of facial expression"] = "No abnormalities";
		physical ["Reflexes"] = "No abnormalities";
		physical ["Vestibulocochlear Nerve (CN VIII)"] = "No abnormalities";
		physical ["Glosspharyngeal and Vagus Nerves (CN IX, X)"] = "No abnormalities";
		// CN XI
		physical ["Inspection"] = "No abnormalities";
		physical ["Motor"] = "No abnormalities";
		// CN XII
		physical ["Inspection"] = "No abnormalities";
		physical ["Motor"] = "No abnormalities";
		// Neurological - Peripheral nervous system
		physical ["General inspection"] = "No abnormalities";
		physical ["Tone"] = "No abnormalities";
		physical ["Power"] = "No abnormalities";
		physical ["Sensation"] = "No abnormalities";
		physical ["Vibration"] = "No abnormalities";
		physical ["Proprioception"] = "No abnormalities";
		physical ["Reflexes"] = "No abnormalities";
		// Neurological - Cerebellar examination
		physical ["General inspection"] = "No abnormalities";
		physical ["Gait"] = "No abnormalities";
		physical ["Speech"] = "No abnormalities]";
		physical ["Coordination"] = "No abnormalities";
		physical ["Motor"] = "No abnormalities";
	}

}
