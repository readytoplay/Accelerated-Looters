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

    public static string PreviousScene = "";


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

    public void loadPreviousScene()
    {
        SceneManager.LoadScene("PreviousScene");

    }

    public void loadSettings()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Settings");
    }

    public void loadFirstScene()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Jungle Level 1");

    }

    public void loadHighScores()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("High Scores");
    }

    public void loadStore()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Store");
    }

    public void loadLevel()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Load Level");
    }

    public void exitGame()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        Application.Quit();
    }

    public void loadJungleLevel()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Jungle Level 1");
    }

    public void loadJungleLevelStore()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Jungle Store");
    }

    public void loadUnderwaterLevel()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Underwater Level 2");
    }

    public void loadUnderwaterLevelStore()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("UW Store");
    }

    public void loadHauntedLevel()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Haunted Level 3");
    }

    public void loadHauntedLevelStore()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Haunted Store");
    }

    public void loadMainMenu()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
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
    public void loadIceLevelStore()
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
