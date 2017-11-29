using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public static playerController Player;

	public int CurrentHealth;	//player health

    public static int CurrentCoins;

    public static string PreviousScene = "";

    void start()
    {

    }

    public void LoadScene(string sceneName)
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        
    }

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
	

