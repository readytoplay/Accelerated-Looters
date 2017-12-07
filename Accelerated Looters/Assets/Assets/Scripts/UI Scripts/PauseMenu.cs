using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private bool paused = false;
    public GameObject pauseMenuTemplate;

    public Button resumeButton;
    public Button restartButton;
    public Button exitButton;

    // Use this for initialization
    void Start () {

        // set the pause menu view to false on start
        pauseMenuTemplate.SetActive(false);
        

        // add button click listeners
        resumeButton.onClick.AddListener(resumeButtonOnClick); 
        restartButton.onClick.AddListener(restartButtonOnClick);
        exitButton.onClick.AddListener(exitButtonOnClick); 
    }
	
	// Update is called once per frame
	void Update () {
        // check if player is pressing escape key (pause key)
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            paused = togglePause();
            pauseMenuTemplate.SetActive(true); // set pause menu to active view
        }
    }

    // resume playing from pause
    public void resumeButtonOnClick()
    {
        paused = togglePause();
        pauseMenuTemplate.SetActive(false);
    }

    // restart level
    public void restartButtonOnClick()
    {
        paused = togglePause();
        SceneManager.LoadScene("Jungle Level 1");
        
    }

    // exit game
    public void exitButtonOnClick()
    {
        SceneManager.LoadScene("Main Menu"); // quit app

    }

    // toggle game pause
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
