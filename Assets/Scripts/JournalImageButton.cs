using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalImageButton : MonoBehaviour {

	public GameObject imagePanel;
	public GameObject backButtonPrefab;

	private GameObject scrollView;
	private DiseaseChooser diseaseChooser;
	private Images images;
	private 

	// Use this for initialization
	void Start () {
		scrollView = GameObject.Find ("Scroll View");
		diseaseChooser = FindObjectOfType<DiseaseChooser> ();
		images = FindObjectOfType<Images> ();
	}

	public void DisplayImage () {
		scrollView.SetActive (false);
		GameObject imagingStudy = Instantiate (imagePanel, GameObject.Find ("Player Menu Canvas").transform);
		imagingStudy.transform.localScale = new Vector3 (1, 1, 1);
		imagingStudy.transform.localPosition = new Vector3 (0, 0, 0);
		imagingStudy.name = "Journal Image Popup";
		Image image = imagingStudy.transform.FindChild ("Image").GetComponent<Image> ();
		int imageNumber = images.imagingStudies.IndexOf (this.name);
		if (imageNumber == 0) {
			image.sprite = images.xrayChests[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 1) {
			image.sprite = images.xrayAbdomens[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 2) {
			image.sprite = images.xraySpines[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 3) {
			image.sprite = images.ctHeads[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 4) {
			image.sprite = images.ctChests[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 5) {
			image.sprite = images.ctAbdomens[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 6) {
			image.sprite = images.mriBrains[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 7) {
			image.sprite = images.ultrasoundAbdomens[diseaseChooser.disease_data.imagingStudies[0]];
		} else if (imageNumber == 8) {
			image.sprite = images.ultrasoundExtremities[diseaseChooser.disease_data.imagingStudies[0]];
		}
		GameObject backButton = Instantiate (backButtonPrefab, imagingStudy.transform);
		imagingStudy.transform.localScale = new Vector3 (1, 1, 1);
		backButton.transform.localPosition = new Vector3 (0, -350f, 0);
		backButton.GetComponent<Button> ().onClick.AddListener (() => { CloseImage (); } );

	}

	private void CloseImage () {
		Destroy (GameObject.Find ("Journal Image Popup"));
	}

}
