using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

	public playerController Player;
	
	
	
	public Image heart1;
	public Image heart2;
	public Image heart3;

	public Sprite FullHeart;

	public Sprite EmptyHeart;

	public int TotalHealth;

	public int CurrentHealth;
	
	
	
	

	// Use this for initialization
	void Start ()
	{
		CurrentHealth = TotalHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HurtPlayer(int damageAmount)
	{
		CurrentHealth -= damageAmount;
		UpdateHeartStatus();
	}


	public void UpdateHeartStatus()
	{
		if (CurrentHealth == 3)
		{
			heart1.sprite = FullHeart;
			heart2.sprite = FullHeart;
			heart3.sprite = FullHeart;

		}else if (CurrentHealth == 2)
		{
			heart1.sprite = FullHeart;
			heart2.sprite = FullHeart;
			heart3.sprite = EmptyHeart;
		}
		else if(CurrentHealth==1)
		{
			heart1.sprite = FullHeart;
			heart2.sprite = EmptyHeart;
			heart3.sprite = EmptyHeart;
		} else if (CurrentHealth <= 0)
		{
			heart1.sprite = EmptyHeart;
			heart2.sprite = EmptyHeart;
			heart3.sprite = EmptyHeart;
		}
		
		
	}
	
}
