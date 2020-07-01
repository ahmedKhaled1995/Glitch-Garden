using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	[Range(-1, 10)]public float speed;
	[Range(1, 100)]public float damage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		Attacker attacker = col.GetComponent<Attacker> ();
		Health attackerHealth = col.GetComponent<Health> ();
		if (attacker && attackerHealth) {
			attackerHealth.DecreaseHealthBy(this.damage);
			Destroy(this.gameObject);
		}
	}
}
