using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

	public float fadeTime;
	public Color currentColor;
	
	private Image fadePanel;
	
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeTime){
			fadeIn ();
		} else {
			gameObject.SetActive (false);
		}
	}
	
	public void fadeIn (){
		float alphaChange = Time.deltaTime / fadeTime;
		currentColor.a -= alphaChange;
		fadePanel.color = currentColor;
	}
	
	public void fadeOut(){
		float alphaChange = Time.deltaTime / fadeTime;
		currentColor.a += alphaChange;
		fadePanel.color = currentColor;
	}
}
