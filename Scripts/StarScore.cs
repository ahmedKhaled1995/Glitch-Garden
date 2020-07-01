using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarScore : MonoBehaviour {
	public int stars;
	private Text staresText;

	public enum Status{SUCCESS, FAIL}  

	// Use this for initialization
	void Start () {
		//stars = 100;
		staresText = this.GetComponent<Text>();
		this.staresText.text = stars.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddStars(int amount){
		stars += amount;
		staresText.text = stars.ToString();
	}

	public Status UseStars(int amount){
		if(this.stars >= amount){
			stars -= amount;
			staresText.text = stars.ToString();
			return Status.SUCCESS;
		}
		return Status.FAIL;
	}
}
