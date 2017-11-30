using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour {

    public GameObject teachPop;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            teachPop.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            
        }
    }

}
