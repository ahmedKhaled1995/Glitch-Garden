using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] attackersPrefabArray;     //0 is fox, 1 is lizard
	public bool spawnEnimies;

	private static float numberOfLanes = 5f;
	private TimeSlider time;

	// Use this for initialization
	void Start () {
		spawnEnimies = true;
		time = GameObject.FindObjectOfType<TimeSlider>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject attacker in attackersPrefabArray){
			if(IsTimeToSpawn(attacker)){
				SpawnAttacker(attacker);
			}
		}
	}

	void SpawnAttacker(GameObject attackerPrefab){
		//Debug.Log (attackerPrefab.name + " meanSpawnDelay = " + attackerPrefab.GetComponent<Attacker> ().seenEveryHowManySeconds);
		GameObject attacker = Instantiate (attackerPrefab, this.transform.position, Quaternion.identity) as GameObject;
		attacker.transform.parent = this.transform;
	}
	
	bool IsTimeToSpawn(GameObject attackerPrefab){
		if (time.startHarderWave) {
			attackerPrefab.GetComponent<Attacker> ().HarderSpawnRate ();
		} else {
			attackerPrefab.GetComponent<Attacker> ().RegularSpawnRate();
		}
		float meanSpawnDelay = attackerPrefab.GetComponent<Attacker> ().seenEveryHowManySeconds;
		float spawnsPerSecond = 1f / meanSpawnDelay;
		float threshold = spawnsPerSecond * Time.deltaTime / numberOfLanes;
		return ( spawnEnimies && (Random.value < threshold) );
	}
}
