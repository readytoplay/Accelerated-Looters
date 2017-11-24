using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
//this script is for spike
public class Spike : MonoBehaviour {
	public playerController player;		

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<playerController>(); //gets script to access

	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			
			player.myRigidbody.velocity = new Vector3 (player.myRigidbody.velocity.x, player.jumpSpeed + 5, 0);
			this.GetComponent<EdgeCollider2D> ().enabled = false;		//set false so character will fall
			StartCoroutine (wait());

		
		}
	}
	IEnumerator wait(){
		yield return new WaitForSeconds (3);			//wait 3 min
		this.GetComponent<EdgeCollider2D> ().enabled = true;	//turn collide box back on

	}
}




