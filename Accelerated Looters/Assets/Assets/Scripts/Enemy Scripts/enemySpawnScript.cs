using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawn
public class enemySpawnScript : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;
	private float timer;
	public int spawnSpot;
<<<<<<< HEAD
	public int spawnFrequency;
=======
	private int clockForPlayer;
	private Timer localClockForPlayer;
>>>>>>> 4eef0fb51da9a35808370e5a5e531b550de7f6d5
	// Use this for initialization

	void Awake(){
		timer = Time.time;
	}
	void Start(){
		localClockForPlayer = GameObject.Find ("TimeText").GetComponent<Timer>();

	}

	void Update (){

		if (timer < Time.time) {		//cooldown
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			spawnSpot = spawnPointIndex;
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
<<<<<<< HEAD
			timer = Time.time + spawnFrequency;
=======
			timer = Time.time + 5;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			{
			localClockForPlayer.reduceTime (3);		//reduce 6 second
			this.gameObject.SetActive (false);
			}

>>>>>>> 4eef0fb51da9a35808370e5a5e531b550de7f6d5
		}
	}


		void OnCollisionEnter2D(Collision2D other){
			if (other.gameObject.tag == "Player") {
			this.gameObject.SetActive (false);
			}
		}




<<<<<<< HEAD
}
=======
	}

>>>>>>> 4eef0fb51da9a35808370e5a5e531b550de7f6d5
