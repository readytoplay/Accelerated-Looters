using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemyBehaviour : MonoBehaviour {
	public Transform DestinationPont;
	public float moveSpeed;
	LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards (this.transform.position, DestinationPont.transform.position, moveSpeed * Time.deltaTime);
		if (this.transform.position.y <-15) {
			Destroy (gameObject);
		}
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			levelManager.HurtPlayer (1);
		}

	}
}
