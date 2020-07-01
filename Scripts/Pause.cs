using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	private bool isGamePaused;
	private GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		isGamePaused = false;
		pauseMenu = GameObject.Find ("PausePanel");
		pauseMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(!isGamePaused){
				PauseGame();
			}else{
				ResumeGame();
			}
		}
	}

	void PauseGame(){
		isGamePaused = true;
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
	}

	public void ResumeGame(){
		isGamePaused = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
	}
}
