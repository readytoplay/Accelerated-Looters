using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public playerController Player;

	public int CurrentHealth;	//player health


	
	

	// Use this for initialization
	void Start ()
	{
		Player = FindObjectOfType<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
		CurrentHealth = Player.life_count;		//record current health

	}

	public void HurtPlayer(int damageAmount)
	{
		CurrentHealth -= damageAmount;			//decrease player health
		Player.life_count = CurrentHealth;		//update player health
	}




		
		
	}
	

