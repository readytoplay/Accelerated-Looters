using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

	public int enemyKilled;

	public bool beingKilled;

	// Use this for initialization
	void Start ()
	{
		enemyKilled = 0;
		beingKilled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		beingKilled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			if (!beingKilled)
			{
				enemyKilled++;
				beingKilled = true;
			}
			Destroy(other.gameObject);
		}
	}
}
