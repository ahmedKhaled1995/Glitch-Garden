using UnityEngine;
using System.Collections;

public class PlayerprefsManager : MonoBehaviour {
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetVolume(float vol){
		if (vol >= 0f && vol <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, vol);
		} else {
			Debug.LogError("Error! Volume value is out of range!");
		}
	}

	public static float GetVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}


	// start counting levels from 0 (see build settings)
	// value is either 0 or 1 ... 0 for locked level, 1 for unlocked level
	public static void SetLevelStatues(int level, int value){
		if ( (level < Application.levelCount) && (value == 0 || value == 1) ) {
			PlayerPrefs.SetInt( (LEVEL_KEY + level.ToString()), value);
		} else {
			Debug.LogError("Error! Level doesn't exisr. Check build settings!");
		}
	}

	public static bool GetLevelStatues(int level){
		if(level < Application.levelCount){
			int status = PlayerPrefs.GetInt( (LEVEL_KEY + level.ToString()) );
			if (status == 1) {
				return true;
			} else {
				return false;
			}
		}
		Debug.LogError("Error! Level doesn't exisr. Check build settings!");
		return false;
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Error! Difficulty out of range!");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

}
