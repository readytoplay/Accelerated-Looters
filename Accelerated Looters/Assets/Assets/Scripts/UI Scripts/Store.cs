using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Store : MonoBehaviour {

    public GameObject buyIcon1, buyIcon2, buyIcon3, buyIcon4;

    public playerController playerScript;

    public bool hasPowerUp1, hasPowerUp2, hasPowerUp3, hasPowerUp4;

    // Use this for initialization
    void Start () {

        playerScript = FindObjectOfType<playerController>(); //gets script to access

    }
	
	// Update is called once per frame
	void Update () {

        setIconsActive();
        // checkPlayerPowerUps() - // TODO: check if player has power up in power up script and set bool variables
    }


    void checkPlayerPowerUps()
    {
        // TODO: check if player has power up in power up script and set bool variables
    }

    public void buyPowerUp1()
    {

        // TODO
        if(!hasPowerUp1&&PlayerPrefs.GetInt("totalcoins")>=5)
        {
            hasPowerUp1 = true;
            PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins")-5);
            // todo - enable player script new power up
        }
    }

    public void buyPowerUp2()
    {
        // TODO 
        if (!hasPowerUp2&&PlayerPrefs.GetInt("totalcoins")>=10)
        {
            hasPowerUp2 = true;
            PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins")-10);
            // todo - enable player script new power up
        }
    }

    public void buyPowerUp3()
    {
        // TODO 
        if (!hasPowerUp3&&PlayerPrefs.GetInt("totalcoins")>=15)
        {
            hasPowerUp3 = true;
            PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins")-15);
            // todo - enable player script new power up
        }
    }

    public void buyPowerUp4()
    {
        // TODO 
        if (!hasPowerUp4&& PlayerPrefs.GetInt("totalcoins")>=20)
        {
            hasPowerUp4 = true;
            PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins")-20);
            // todo - enable player script new power up
        }
    }

    public void goBackJungleEndLevelMenu()
    {
        SceneManager.LoadScene("Jungle End Level Menu");
    }

    public void goBackUnderWaterEndLevelMenu()
    {
        SceneManager.LoadScene("UW End Level Menu");
    }

    public void goBackHauntedEndLevelMenu()
    {
        SceneManager.LoadScene("Haunted End Level Menu");
    }

    public void goBackSnowEndLevelMenu()
    {
        SceneManager.LoadScene("Snow End Level Menu");
    }


    void setIconsActive()
    {

        if (!hasPowerUp1)
        {
            buyIcon1.SetActive(true);
        }
        else
        {
            buyIcon1.SetActive(false);
        }
        if (!hasPowerUp2)
        {
            buyIcon2.SetActive(true);
        }
        else
        {
            buyIcon2.SetActive(false);
        }
        if (!hasPowerUp3)
        {
            buyIcon3.SetActive(true);
        }
        else
        {
            buyIcon3.SetActive(false);
        }
        if (!hasPowerUp4)
        {
            buyIcon4.SetActive(true);
        }
        else
        {
            buyIcon4.SetActive(false);
        }
    }

}
