using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour {
	public playerController Player;
	public GameObject destination;
	public int moveSpeed;
	private int playerHealth;
	private bool canIMove = false;		//first dont let the dead zone move
	LevelManager levelManager;


	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<playerController>();
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		StartCoroutine (startDeadZone());
	}
	
	// Update is called once per frame
	void Update () {
		if (canIMove == true) {			
			this.transform.position = Vector3.MoveTowards (this.transform.position, destination.transform.position, moveSpeed * Time.deltaTime);
		}
		playerHealth=Player.life_count;	//constanly get player health
	}

	IEnumerator startDeadZone(){
		yield return new WaitForSeconds (5);
		canIMove = true;		//allow deadzone move when after 5 second
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			
			levelManager.HurtPlayer (playerHealth);
		}

	}


}
