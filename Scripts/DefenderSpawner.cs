using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;

	private GameObject defendrs;
	private int xGrids;
	private int yGrid;
	private bool[,] positionsGrid;

	// Use this for initialization
	void Start () {
		this.defendrs = GameObject.Find ("Defendrs");
		if(!defendrs){
			defendrs = new GameObject("Defendrs");
		}
		xGrids = 9;
		yGrid = 5;
		InitializePositionsGrid ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		GameObject defenderToSpawn = Button.selectedDefender;
		if(defenderToSpawn){
			int costToSpawnDefender = defenderToSpawn.GetComponent<Defenders> ().starsCost;
			Vector2 posToSpawn = SnapToGrid (WorldPointOfMouseClick());
			if(IsPosEmpty(posToSpawn)){
				if (GameObject.FindObjectOfType<StarScore>().UseStars (costToSpawnDefender) == StarScore.Status.SUCCESS) {
					ReservePos(posToSpawn);
					GameObject defender = Instantiate (Button.selectedDefender, posToSpawn, Quaternion.identity) as GameObject;
					defender.transform.parent = defendrs.transform;
					//Debug.Log("Position Free");
				}
			}
		}
	}

	Vector2 WorldPointOfMouseClick(){
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		float z = 10f;    // distance from camera
		Vector3 vector3 = new Vector3 (x, y, z);
		Vector2 worldPoint = myCamera.ScreenToWorldPoint (vector3);
		return worldPoint;
	}

	Vector2 SnapToGrid (Vector2 rawPos){
		float snappedX = Mathf.RoundToInt (rawPos.x);     // we substract half to ensure the snap works to the desired grid
		float snappedY = Mathf.RoundToInt (rawPos.y);
		return new Vector2 (snappedX, snappedY);
	}

	void InitializePositionsGrid(){
		positionsGrid = new bool[xGrids, yGrid];
		int x, y;
		for(x=0; x<xGrids; x++){
			for(y=0; y<yGrid; y++){
				positionsGrid[x, y] = true;
			}
		}
	}

	bool IsPosEmpty(Vector2 pos){
		int x = (int)pos.x - 1;
		int y = (int)pos.y - 1;
		return positionsGrid[x, y];
	}

	void ReservePos(Vector2 pos){
		int x = (int)pos.x - 1;
		int y = (int)pos.y - 1;
		positionsGrid[x, y] = false;
	}

	public void FreePos(Vector2 pos){
		int x = (int)pos.x - 1;
		int y = (int)pos.y - 1;
		positionsGrid[x, y] = true;
	}
}
