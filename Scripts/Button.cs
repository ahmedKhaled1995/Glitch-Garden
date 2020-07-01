using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	public GameObject buttonPrefab;
	public static GameObject selectedDefender;
	
	private Button[] buttonsArray;
	private Text cost;

	// Use this for initialization
	void Start () {
		buttonsArray = GameObject.FindObjectsOfType<Button>();
		this.cost = this.GetComponentInChildren<Text>();
		this.cost.text = buttonPrefab.GetComponent<Defenders> ().starsCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		foreach(Button button in buttonsArray){
			button.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f);
		}
		this.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f);
		Button.selectedDefender = buttonPrefab;
	}


	/*
	void OnMouseUp(){
		this.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f);
	}
	*/
}
