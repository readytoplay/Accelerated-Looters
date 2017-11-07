using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script for showing player health,equip in LifeText Object

public class life_number_Script : MonoBehaviour {


	public Text life;
	public int numberOfLife;	//number of life player have
	public playerController player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<playerController>();


	}
	
	// Update is called once per frame
	void Update () {
		numberOfLife = player.life_count;	//get the current health from player

		life.text=("x "+numberOfLife);		//show the current health
}



}