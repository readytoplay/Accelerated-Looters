using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour {

	public playerController playerScript;

	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find ("Player").GetComponent<playerController>(); //gets script to access
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.CompareTag("Player")){
			playerScript.setSpeedBoost(); //calls setSpeedBoost in playerController
			Destroy (gameObject);

		}
	}
}
