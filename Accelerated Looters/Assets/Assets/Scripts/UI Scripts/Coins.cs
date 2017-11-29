using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

	public int coin = 0;
	public int totalCoins;
	public Text coins;
	public Text totalc;
	public playerController p;


	// Use this for initialization
	void Start()
	{
		p = FindObjectOfType<playerController>();
		
	}

	// Update is called once per frame
	void Update()
	{
		coin = p.coins;
		totalCoins = PlayerPrefs.GetInt("totalcoins");
		
		coins.text = ("Current coins " + coin+ "\n" + "Total Coins " + totalCoins);

	}

}
