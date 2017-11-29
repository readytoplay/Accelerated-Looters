using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    static public int coins;
    public GameObject manager;

	// Use this for initialization
	void Start () {
        Debug.Log(coins);
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("End Level Menu");
        }
    }

}
