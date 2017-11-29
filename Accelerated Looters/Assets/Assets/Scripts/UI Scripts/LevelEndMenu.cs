using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelEndMenu : MonoBehaviour {

    public GameObject star1, star2, star3;
    Text coinCounter, timeCounter;

    int playerCoins, playerLives;
    Time playerTime;

    public Time timeStandard;
    public int coinStandard;

    

	// Use this for initialization
	void Start () {

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        // TODO

        // get the player time count
        // get the player coin count

        // get the current high score
        // if new score is higher, replace current high score

        if (playerCoins > 15)
        {
            star1.SetActive(true);
        }
        if(playerLives >= 3)
        {
            star2.SetActive(true);
        }

        // TODO player time < standard
        /*
        if ( )
        {
            star3.SetActive(true);
        }
        */
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Reloads the previous scene
    public void reloadPrevScene()
    {
        // load the previous scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void loadNextLevel()
    {
        // load the previous scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void loadFirstScene()
    {
        SceneManager.LoadScene("Jungle Level 1");
    }

    public void loadHighScores()
    {
        SceneManager.LoadScene("High Scores");
    }

    public void loadStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void loadLevel()
    {
        SceneManager.LoadScene("Load Level");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadJungleLevel()
    {
        SceneManager.LoadScene("Jungle Level 1");
    }

    public void loadUnderwaterLevel()
    {
        SceneManager.LoadScene("Underwater Level 2");
    }

    public void loadHauntedLevel()
    {
        SceneManager.LoadScene("Haunted Level 3");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }

    // ***** TODO Stuff *****

    // TODO
    public void loadIceLevel()
    {
        // TODO when Ice level is committed
        // SceneManager.LoadScene("Ice Level 4");
    }

    // TODO
    public void loadPCGJungle()
    {
        // TODO when PCG is finished
        // SceneManager.LoadScene("");
    }

    // TODO
    public void loadPCGUnderwater()
    {
        // TODO when PCG is finished
        // SceneManager.LoadScene("");
    }

    // TODO
    public void loadPCGHaunted()
    {
        // TODO when PCG is finished
        // SceneManager.LoadScene("");
    }

    // TODO
    public void loadPCGIce()
    {
        // TODO when PCG is finished
        // SceneManager.LoadScene("");
    }
}
