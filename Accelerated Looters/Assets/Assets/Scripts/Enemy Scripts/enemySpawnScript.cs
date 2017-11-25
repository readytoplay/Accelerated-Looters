using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemySpawnScript : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;
	private float timer;
	public int spawnSpot;
	// Use this for initialization

	void Awake(){
		timer = Time.time;
	}

	void Update (){

		if (timer < Time.time) {		//cooldown
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			spawnSpot = spawnPointIndex;
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			timer = Time.time + 5;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			{
			this.gameObject.SetActive (false);
			}

		}



	}

