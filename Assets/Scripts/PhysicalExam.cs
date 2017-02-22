using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalExam : MonoBehaviour {

	public Dictionary<string, string> physical = new Dictionary<string, string>();
	public List <string> femaleOnlyPhysical = new List <string> ();

	void Awake () {
		// General inspection
		physical ["General appearance"] = "Patient appears well.";
		physical ["Glasgow Coma Scale"] = "15/15.";
		// Pulmonary
		physical ["Pulm - Inspection"] = "No abnormalities.";
		physical ["Pulm - Palpation"] = "No abnormalities.";
		physical ["Pulm - Percussion"] = "No abnormalities.";
		physical ["Pulm - Auscultation"] = "Lungs are clear to auscultation bilaterally.";
		physical ["Tactile fremitus"] = "No tactile fremitus appreciated.";
		physical ["Whispered pectoriloquy"] = "No whispered pectoriloquy.";
		physical ["Egophony"] = "No egophony";
		// Cardiac
		physical ["Card - Inspection"] = "No abnormalities.";
		physical ["Card - Palpation"] = "No abnormalities.";
		physical ["Card - Auscultation"] = "Normal S1 and S2. No murmurs, rubs, or gallups.";
		// Peripheral vasculature
		physical ["Abd vasc - Inspection, palpation, and auscultation"] = "No abnormalities.";
		physical ["Upper limb vasc - Inspection, palpation, and auscultation"] = "No abnormalities.";
		physical ["Lower limb vasc - Inspection, palpation, and auscultation"] = "No abnormalities.";
		// Abdominal
		physical ["Abd - Inspection"] = "No abnormalities.";
		physical ["Abd - Inspection from the side, eyes at bedside level"] = "No abnormalities.";
		physical ["Abd - Palpation - Superficial"] = "No abnormalities.";
		physical ["Abd - Palpation - Deep"] = "No abnormalities.";
		physical ["Abd - Percussion"] = "No abnormalities.";
		physical ["Abd - Auscultation"] = "No abnormalities.";
		// Neck
		physical ["JVP"] = "5 cm above the sternal angle.";
		physical ["Thyroid gland"] = "No abnormalities.";
		physical ["Carotids"] = "No abnormalities.";
		physical ["Lymph node palpation"] = "No abnormalities.";
		// Ophthalmologic
		physical ["Oph - General inspection"] = "No abnormalities.";
		physical ["Fundoscopy"] = "No abnormalities.";
		physical ["Slit lamp exam"] = "No abnormalities.";
		// Ears
		physical ["Ears - General examination"] = "No abnormalities.";
		physical ["Otoscopic examination"] = "No abnormalities.";
		// Oropharynx
		physical ["Oro - General inspection"] = "No abnormalities.";
		// Musculoskeletal - Knees
		physical ["Knees - Inspection and gait assessment"] = "No abnormalities.";
		physical ["Knees - Range of movement"] = "No abnormalities.";
		physical ["Knees - Palpation"] = "No abnormalities.";
		physical ["Knees - Special tests"] = "No abnormalities.";
		// Musculoskeletal - Hips
		physical ["Hips - Gait"] = "No abnormalities.";
		physical ["Hips - Inspection"] = "No abnormalities.";
		physical ["Hips - Range of movement"] = "No abnormalities.";
		physical ["Hips - Palpation"] = "No abnormalities.";
		physical ["Thomas Test"] = "No abnormalities.";
		physical ["Trendelenberg Sign"] = "No abnormalities.";
		// Musculoskeletal - Shoulder
		physical ["Shoulder - Inspection"] = "[Inspection]";
		physical ["Shoulder - Range of movement - active"] = "No abnormalities.";
		physical ["Shoulder - Range of movement - passive"] = "No abnormalities.";
		physical ["Shoulder - Palpation"] = "No abnormalities.";
		physical ["Lift-off Test"] = "No abnormalities.";
		physical ["Speed's Test"] = "No abnormalities.";
		physical ["Yergason's Test"] = "No abnormalities.";
		// Musculoskeletal - Spine
		physical ["Spine - Inspection"] = "No abnormalities.";
		physical ["Spine - Range of movement"] = "No abnormalities.";
		physical ["Spine - Palpation"] = "No abnormalities.";
		physical ["Straight Leg Test"] = "No abnormalities.";
		physical ["Schober's Test"] = "No abnormalities.";
		// Neurological - Cranial nerves
		physical ["Olfactory Nerve (CN I)"] = "No abnormalities.";
		physical ["Optic Nerve (CN II)"] = "No abnormalities.";
		physical ["Oculomotor, Trochlear, and Abducens Nerves (CN III, IV, VI)"] = "No abnormalities.";
		// CN V
		physical ["CN V - Sensation - Light touch"] = "No abnormalities.";
		physical ["CN V - Sensation - Pain and Temperature"] = "No abnormalities.";
		physical ["CN V - Sensation - Corneal Reflex"] = "No abnormalities.";
		physical ["CN V - Motor - Temporalis and masseters"] = "No abnormalities.";
		physical ["CN V - Motor - Jaw Jerk Reflex"] = "No abnormalities.";
		physical ["CN V - Motor - Lateral and Medial pterygoids"] = "No abnormalities.";
		// CN VII
		physical ["CN VII - Inspection"] = "No abnormalities.";
		physical ["CN VII - Motor - Muscles of facial expression"] = "No abnormalities.";
		physical ["CN VII - Reflexes"] = "No abnormalities.";
		// CN VIII
		physical ["Vestibulocochlear Nerve (CN VIII)"] = "No abnormalities.";
		// CN IX,X
		physical ["Glosspharyngeal and Vagus Nerves (CN IX, X)"] = "No abnormalities.";
		// CN XI
		physical ["CN XI - Inspection"] = "No abnormalities.";
		physical ["CN XI - Motor"] = "No abnormalities.";
		// CN XII
		physical ["CN XII - Inspection"] = "No abnormalities.";
		physical ["CN XII - Motor"] = "No abnormalities.";
		// Neurological - Peripheral nervous system
		physical ["Neuro - General inspection"] = "No abnormalities.";
		physical ["Neuro - Tone"] = "No abnormalities.";
		physical ["Neuro - Power"] = "No abnormalities.";
		physical ["Neuro - Sensation"] = "No abnormalities.";
		physical ["Neuro - Vibration"] = "No abnormalities.";
		physical ["Neuro - Proprioception"] = "No abnormalities.";
		physical ["Neuro - Reflexes"] = "No abnormalities.";
		// Neurological - Cerebellar examination
		physical ["Cere - General inspection"] = "No abnormalities.";
		physical ["Cere - Gait"] = "No abnormalities.";
		physical ["Cere - Speech"] = "No abnormalities.]";
		physical ["Cere - Coordination"] = "No abnormalities.";
		physical ["Cere - Motor"] = "No abnormalities.";
	
		// Breast
		physical ["Breast - Inspection"] = "No abnormalities.";
		physical ["Breast - Palpation"] = "No abnormalities.";

		// Pelvic
		physical ["Inspection of external genitalia"] = "No abnormalities.";
		femaleOnlyPhysical.Add("Inspection of external genitalia");
		physical ["Palpation of Bartholin glands"] = "No abnormalities.";
		femaleOnlyPhysical.Add("Palpation of Bartholin glands");
		physical ["Speculum examination"] = "No abnormalities.";
		femaleOnlyPhysical.Add("Speculum examination");
		physical ["Bimanual examination"] = "No abnormalities.";
		femaleOnlyPhysical.Add("Bimanual examination");
		physical ["Rectovaginal examination"] = "No abnormalities.";
		femaleOnlyPhysical.Add("Rectovaginal examination");

	}

}
