using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyMovementScript : MonoBehaviour {
	public Transform finalDestination;
	public float movement_speed;
	public LevelManager MyLevelManager;

	// Use this for initialization
	void Start (){
		MyLevelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();		//get the exact zombie spawn position 	

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards (this.transform.position, finalDestination.transform.position, movement_speed * Time.deltaTime);	//move from my position to target position in some speed
		if (this.transform.position.y == -1.597) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			MyLevelManager.HurtPlayer (1);
		}
	}
}
