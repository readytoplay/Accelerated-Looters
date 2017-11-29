using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndLevel : MonoBehaviour {

 
	// Use this for initialization
	void Start () {
        
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {



        if(collision.transform.tag == "Player")
        {

            if (SceneManager.GetActiveScene().name == "Jungle Level 1")
            {
                SceneManager.LoadScene("Jungle End Level Menu");
            }

            if (SceneManager.GetActiveScene().name == "Underwater Level 2")
            {
                SceneManager.LoadScene("UW End Level Menu");
            }

            if (SceneManager.GetActiveScene().name == "Haunted Level 3")
            {
                SceneManager.LoadScene("Haunted End Level Menu");
            }

            if (SceneManager.GetActiveScene().name == "Snow Level 4")
            {
                SceneManager.LoadScene("Snow End Level Menu");
            }

        }
    }

}
