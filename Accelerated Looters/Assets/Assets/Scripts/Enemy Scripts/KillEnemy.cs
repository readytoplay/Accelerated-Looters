using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

	public int enemyKilled;
	public bool killingEnemy;		//determine are we killing enemy

	// Use this for initialization
	void Start ()
	{
		enemyKilled = 0;			//count how many enemy we killing

	}
	
	// Update is called once per frame
	void Update ()
	{
		killingEnemy = false;			//set killing enemy to false all the time
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			killingEnemy = true;		//set true if character killing someone
			enemyKilled++;				//+1 when we killed the enemy
			Destroy(other.gameObject);	//destory the enemy

			}
			
		}
	}

