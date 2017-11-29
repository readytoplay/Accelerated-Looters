using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

    public static string PreviousScene = "";

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