using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCoinPowerUp : MonoBehaviour {

	public playerController playerScript;

	// Use this for initialization
	void Start () {
		playerScript = FindObjectOfType<playerController>(); //gets script to access
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.CompareTag("Player")){
			playerScript.setDoubleCoin(); //calls setHighJump in playerController
			Destroy (gameObject);

		}
	}
}
