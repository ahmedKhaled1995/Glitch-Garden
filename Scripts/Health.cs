using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health;

	private DefenderSpawner defenderSpawner;

	// Use this for initialization
	void Start () {
		this.InitializeHealth ();
		defenderSpawner = GameObject.FindObjectOfType<DefenderSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeHealth(){
		/*
		if(this.GetComponent<Attacker>()){
			this.health = 50;
		}if(this.GetComponent<Defenders>()){
			this.health = 100;
		}
		*/
	}

	public void IncreaseHealthBy(float healthIncrement){
		this.health += healthIncrement;
	}

	public void DecreaseHealthBy(float healthDecrement){
		this.health -= healthDecrement;
		if(this.health <= 0){
			// if it's a defender I need to free its position from the grid to be able to spawn again in that position
			if(this.GetComponent<Defenders>()){
				defenderSpawner.FreePos(this.transform.position);
			}
			DestroyObject();
		}
	}

	public void DestroyObject(){
		Destroy(this.gameObject);
	}
}
