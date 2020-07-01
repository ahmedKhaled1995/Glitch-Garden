using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] levelsMusic;

	private AudioSource audioSource;
	private LevelManager levelManager;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = this.GetComponent<AudioSource>();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		float splashClipLength = levelsMusic[0].length;
		loadMusicLevel (0, false);
		Invoke("LoadMenuScene", (splashClipLength + 0.5f) );     // load the main menu scene after the splash scene music is over plus half a second delay
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LoadMenuScene(){
		levelManager.LoadLevel ("01a_Menu");
	}

	void loadMusicLevel(int level, bool loopMusic){
		if(levelsMusic[level]){
			if(audioSource.isPlaying){
				audioSource.Stop();
			}
			audioSource.clip = levelsMusic[level];
			audioSource.loop = loopMusic;
			audioSource.Play();
		}
	}

	void OnLevelWasLoaded (int level) 
	{
		if( levelsMusic[level] && (audioSource.clip != levelsMusic[level]) ){
			loadMusicLevel(level, true);
		}
	}

	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
