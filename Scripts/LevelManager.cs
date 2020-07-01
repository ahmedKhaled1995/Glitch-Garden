using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(string level){
		if(Time.timeScale == 0f){
			Time.timeScale = 1f;
		}
		Application.LoadLevel (level);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void LoadNextLevel(){
		int currentLevel = Application.loadedLevel;
		Application.LoadLevel (currentLevel + 1);
	}
}
