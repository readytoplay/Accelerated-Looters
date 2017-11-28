using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

    public void loadFirstScene()
    {
        SceneManager.LoadScene("Jungle Level 1");
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