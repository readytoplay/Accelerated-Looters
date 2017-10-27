using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

	public int coin = 0;
	
	public Text coins;
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
		
		coins.text = ("Coins = " + coin);

	}

}
