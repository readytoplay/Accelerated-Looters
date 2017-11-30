﻿using System.Collections;
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

    public void reset()
    { 
        PlayerPrefs.SetInt("totalcoins", 0);
        
        PlayerPrefs.SetInt("highscore", 0);
        
       
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

    public void loadPCGJungle()
    {

        SceneManager.LoadScene("PCG Jungle Level");
    }

    public void loadPCGUnderwater()
    {
        SceneManager.LoadScene("PCG Underwater Level");
    }

    public void loadPCGHaunted()
    {
        SceneManager.LoadScene("PCG Haunted Level");
    }

    public void loadPCGSnow()
    {
        SceneManager.LoadScene("PCG Snow Level");
    }

    public void loadPCGJungle_GAMEOVER()
    {

        SceneManager.LoadScene("Jungle PCG End Level Menu");
    }

    public void loadPCGUnderwater_GAMEOVER()
    {
        SceneManager.LoadScene("UW PCG Game Over Menu");
    }

    public void loadPCGHaunted_GAMEOVER()
    {
        SceneManager.LoadScene("Haunted PCG Game Over Menu");
    }

    public void loadPCGSnow_GAMEOVER()
    {
        SceneManager.LoadScene("Snow PCG Game Over Menu");
    }
}