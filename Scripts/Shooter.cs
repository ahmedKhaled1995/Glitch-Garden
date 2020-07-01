using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator animator;
	private Transform spawnerLane;

	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find ("Projectiles");
		animator = this.GetComponent<Animator>();
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		SetUpMyLaneSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAttackerAheadInLane()){
			animator.SetBool("IsAttacking", true);
		}else{
			animator.SetBool("IsAttacking", false);
		}
	}

	void FireGun(){
		Vector3 projectileSpawnPos = gun.transform.position;
		GameObject proj = Instantiate(projectile, projectileSpawnPos, Quaternion.identity) as GameObject;
		proj.transform.parent = projectileParent.transform;
	}

	void SetUpMyLaneSpawner(){
		int PosY = (int) this.transform.position.y;
		spawnerLane = GameObject.Find ("Spawners").transform.GetChild (PosY - 1);
	}

	bool IsAttackerAheadInLane(){
		if (spawnerLane.childCount == 0) {
			return false;
		} else {
			foreach(Transform attacker in spawnerLane){
				if(attacker.position.x > this.transform.position.x){
					return true;
				}
			}
			return false;
		}
	}
}