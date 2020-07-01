using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	private float speed;
	private GameObject attackedTarget;
	private Animator animator;

	[Tooltip("How man seconds should pass to spawn this attacker.")]
	public float seenEveryHowManySeconds;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.left * Time.deltaTime * speed);
		if(this.IsAttackedTargetDestroyed()){
			animator.SetBool("IsAttacking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D col){

	}

	public void SetSpeed(float speed){
		this.speed = speed;
	}

	public void StrikeCurrentTarget(float damage){
		if(attackedTarget){
			attackedTarget.GetComponent<Health> ().DecreaseHealthBy (damage);
		}

	}

	public void Attack(GameObject obj){
		this.attackedTarget = obj;
	}

	bool IsAttackedTargetDestroyed(){
		if(!attackedTarget){
			return true;
		}
		return false;
	}

	public void RegularSpawnRate(){
		if (this.GetComponent<Fox> ()) {
			this.seenEveryHowManySeconds = 10f;
		}else if(this.GetComponent<Lizard> ()){
			this.seenEveryHowManySeconds = 5f;
		}
		//Debug.Log (this.seenEveryHowManySeconds);
	}

	public void HarderSpawnRate(){
		if (this.GetComponent<Fox> ()) {
			this.seenEveryHowManySeconds = 2f;
		}else if(this.GetComponent<Lizard> ()){
			this.seenEveryHowManySeconds = 1f;
		}
		//Debug.Log (this.seenEveryHowManySeconds);
	}
}
