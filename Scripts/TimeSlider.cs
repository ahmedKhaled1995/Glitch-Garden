using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSlider : MonoBehaviour {
	private Slider timeSlider;
	private LevelManager levelManger;
	private Spawner[] attackerSpawners;
	private AudioSource audioSource;
	private GameObject winText;
	private bool enteredHandleWave;
	private bool enterdHandleWining;
	private GameObject wininngParticles;
	private bool waveComplete;
	private int midWavaTime;
	private GameObject wavePanel;

	public float levelTime;   // level time in seconds
	public float waveTime;
	public bool startHarderWave;

	// Use this for initialization
	void Start () {
		timeSlider = this.GetComponent<Slider>();
		timeSlider.maxValue = levelTime;
		timeSlider.minValue = 0f;
		timeSlider.value = timeSlider.maxValue;
		levelManger = GameObject.FindObjectOfType<LevelManager>();
		attackerSpawners = GameObject.FindObjectsOfType<Spawner>();
		audioSource = this.GetComponent<AudioSource>();
		winText = GameObject.Find ("WinText");
		winText.SetActive (false);
		enteredHandleWave = false;
		enterdHandleWining = false;
		startHarderWave = false;
		wininngParticles = GameObject.Find ("WininngParticles");
		wininngParticles.SetActive (false);
		waveComplete = false;
		midWavaTime = (int) levelTime / 2;
		wavePanel = GameObject.Find ("WavePanel");
		if(wavePanel){
			wavePanel.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 5) {    // special behaviour for the final level of the game
			UpdateForFinalLevel();
		} else {     // update behaviour for the first two levels
			UpdateRegularLevel();
		}
	}

	bool AreAttackerSpawnersEmpty(){
		foreach(Spawner spawner in attackerSpawners){
			if(spawner.transform.childCount > 0){
				return false;
			}
		}
		return true;
	}

	void HandleWining(){
		enterdHandleWining = true;
		audioSource.Play ();
		wininngParticles.SetActive (true);
		winText.SetActive (true);
		audioSource.volume = PlayerprefsManager.GetVolume ();
		Invoke ("LoadNextLevel", (audioSource.clip.length+0.25f) );
	}

	void HandleWave(){
		//Debug.Log ("Entered wave");
		if(wavePanel){
			wavePanel.SetActive(true);
		}
		startHarderWave = true;
		enteredHandleWave = true;
		Invoke ("StopSpawningAttackers", waveTime);
	}

	void ExitWaveState(){
		//Debug.Log ("Exiting wave state");
		if(wavePanel){
			wavePanel.SetActive(false);
		}
		startHarderWave = false;
		enteredHandleWave = false;
		SpawnEnimies ();
	}

	void LoadNextLevel(){
		levelManger.LoadNextLevel ();
	}

	void StopSpawningAttackers(){
		foreach(Spawner spawner in attackerSpawners){
			spawner.spawnEnimies = false;
		}
		//Debug.Log ("wave time over");
		waveComplete = true;
	}

	void SpawnEnimies(){
		foreach(Spawner spawner in attackerSpawners){
			spawner.spawnEnimies = true;
		}
		waveComplete = false;
	}

	void UpdateRegularLevel(){
		timeSlider.value -= Time.deltaTime;
		if(timeSlider.value <= 0 && !enteredHandleWave){
			HandleWave();
		}
		if(waveComplete && AreAttackerSpawnersEmpty() && !enterdHandleWining){
			HandleWining();
		}
	}

	void UpdateForFinalLevel(){
		if( ((int)Time.timeSinceLevelLoad == midWavaTime && !enteredHandleWave) || (timeSlider.value <= 0 && !enteredHandleWave) ){
			HandleWave();
		}
		if(enteredHandleWave){
			if(waveComplete && timeSlider.value>0){   // level is not yet over
				ExitWaveState();
			}else if (waveComplete && AreAttackerSpawnersEmpty() && timeSlider.value<=0){   // player survived final wave
				HandleWining();
			}
		}else{
			timeSlider.value -= Time.deltaTime;
		}
	}
}