using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {
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
			if(def.GetComponent<Gravestone>()){
				this.Jump();
			}else{
				this.Attack(def);
			}
			
		} else {
			return;
		}
	}

	void Attack(Defenders def){
		//Debug.Log (this.name + " is attacking " + def.gameObject.name);
		this.animator.SetBool ("IsAttacking", true);
		this.attacker.Attack(def.gameObject);
	}
	
	void Jump(){
		this.animator.SetTrigger ("FoxJumpTrigger");
	}
}
