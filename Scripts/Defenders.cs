using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {
	private StarScore starScore;
	private GameObject particelsPrefab;
	private GameObject currentParticles;
	private Attacker attacker;

	public int starsCost = 100;

	// Use this for initialization
	void Start () {
		this.starScore = GameObject.FindObjectOfType<StarScore>();
		this.GetParticalesPrefab ();
		this.InstantiateParticles ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!attacker){
			currentParticles.GetComponent<ParticleSystem> ().enableEmission = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.GetComponent<Attacker> ()) {
			if ((col.GetComponent<Lizard> ()) || (col.GetComponent<Fox> () && !this.GetComponent<Gravestone> ())) {
				currentParticles.GetComponent<ParticleSystem> ().enableEmission = true;
				attacker = col.GetComponent<Attacker>();
			}
		}

	}

	// this method is here since the trophy is the gameobject responsible for generating stars, and the trophy is a defender
	void AddStars(int amount){
		starScore.AddStars (amount);
	}

	void GetParticalesPrefab(){
		if(this.GetComponent<Trophy>()){
			this.particelsPrefab = this.GetComponent<Trophy>().trophyParticalesPrefab;
		}else if(this.GetComponent<Gravestone>()){
			this.particelsPrefab = this.GetComponent<Gravestone>().gravestoneParticalesPrefab;
		}else if(this.GetComponent<Cactus>()){
			this.particelsPrefab = this.GetComponent<Cactus>().cactusParticalesPrefab;
		}else if(this.GetComponent<Gnome>()){
			this.particelsPrefab = this.GetComponent<Gnome>().gnomeParticalesPrefab;
		}
	}
	

	void InstantiateParticles(){
		float x = this.transform.position.x;
		float y = this.transform.position.y;
		float z = -10;
		Vector3 particlePos = new Vector3 (x, y, z);
		currentParticles = Instantiate (particelsPrefab, particlePos, Quaternion.identity) as GameObject;
		currentParticles.transform.parent = this.transform;
		currentParticles.GetComponent<ParticleSystem> ().enableEmission = false;
	}
}
