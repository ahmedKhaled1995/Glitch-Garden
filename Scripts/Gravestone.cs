using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {
	public GameObject gravestoneParticalesPrefab;
	private Animator animator;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.GetComponent<Lizard>()){
			this.animator.SetTrigger ("AttackedTrigger");
		}
	}

}
