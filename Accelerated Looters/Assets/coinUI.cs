using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinUI : MonoBehaviour {
	public int totalCoins;
		public Text coins;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		totalCoins = PlayerPrefs.GetInt("totalcoins");
		
		coins.text = (" " +totalCoins+ " ");
	}
}
