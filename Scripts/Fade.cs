using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {
	private Image panel;
	private Color panalColor;
	private float fadeTime;
	private float alphaChangeRate;

	// Use this for initialization
	void Start () {
		panel = this.GetComponent<Image>();
		panalColor = Color.black;   // could have written panalColor = panel.color;    if I made sure to set the color of the panel black in the inspector 
		fadeTime = 2f;
		alphaChangeRate = Time.deltaTime / fadeTime;    // ex : 16 / 2
		panel.color = panalColor;
	}
	
	// Update is called once per frame
	void Update () {
		FadeIn ();
	}

	void FadeIn(){
		if (Time.timeSinceLevelLoad < fadeTime) {
			panalColor.a = panalColor.a - alphaChangeRate;
			panel.color = panalColor;
		} else {
			gameObject.SetActive(false);
		}
	}
}
