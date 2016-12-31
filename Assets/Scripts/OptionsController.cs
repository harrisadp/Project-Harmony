using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMastervolume();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}
	
	public void saveAndExit (){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		levelManager.LoadLevel ("01a_Start");
	}
	
	public void SetDefaults () {
		volumeSlider.value = 0.8f;
	}
	
}
