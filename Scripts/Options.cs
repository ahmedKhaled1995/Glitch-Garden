using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Options : MonoBehaviour {
	private MusicPlayer musicPlayer;
	private LevelManager levelManager;
	private Slider volumeSlider;
	//private Slider difficultySlider;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.Find ("MusicPlayer").GetComponent<MusicPlayer>();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		volumeSlider = GameObject.Find ("VolumeSlider").GetComponent<Slider>();
		//difficultySlider = GameObject.Find ("DifficultySlider").GetComponent<Slider>();
		ChangeSliders ();
		ApplyChanges ();
	}
	
	// Update is called once per frame
	void Update () {
		musicPlayer.ChangeVolume (volumeSlider.value);
	}

	public void SaveAndExit(){
		ApplyChanges ();
		levelManager.LoadLevel ("01a_Menu");
	}

	public void ApplyChanges(){
		PlayerprefsManager.SetVolume (volumeSlider.value);
		//PlayerprefsManager.SetDifficulty (difficultySlider.value);
	}

	void ChangeSliders(){
		volumeSlider.value = PlayerprefsManager.GetVolume ();
		//difficultySlider.value = PlayerprefsManager.GetDifficulty ();
	}

	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		//difficultySlider.value = 2f;
	}
}
