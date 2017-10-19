using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
	public LevelManager MyLevelManager;

	public int DamageAmount; //the damage to the player
	
	// Use this for initialization
	void Start () {
	MyLevelManager=FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollision2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			MyLevelManager.HurtPlayer(DamageAmount);
		}
	}
	
	
	
}
