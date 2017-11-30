using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCheck : MonoBehaviour {
    public GameObject teachPop;
    bool isInCollision = false;
    PauseMenu pause;
    // Use this for initialization
    void Start () {
        pause = GameObject.Find("Jungle Level Character").GetComponent<PauseMenu>();
        teachPop.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (isInCollision == false)
            {
                isInCollision = true;
                Debug.Log("going in");
                teachPop.SetActive(true);
                this.togglePause();
   
 
            }

    }

    public bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }


}
