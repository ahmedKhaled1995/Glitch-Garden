using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {
	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer> ().GetComponent<MusicPlayer> ();
		musicPlayer.ChangeVolume (PlayerprefsManager.GetVolume());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
