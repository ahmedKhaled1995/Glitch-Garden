using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {
	public Attacker attacker;
	public Animator animator;


	// Use this for initialization
	void Start () {
		this.attacker = this.GetComponent<Attacker> ();
		this.animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Defenders def = col.gameObject.GetComponent<Defenders>();
		if (def && def.GetComponent<Health>()) {
			this.animator.SetBool ("IsAttacking", true);
			this.attacker.Attack(col.gameObject);
		} else {
			return;
		}
	}
}
