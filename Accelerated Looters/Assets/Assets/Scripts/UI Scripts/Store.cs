using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Store : MonoBehaviour {

    public GameObject buyIcon1, buyIcon2, buyIcon3, buyIcon4;

    public playerController playerScript;

    public bool hasPowerUp1, hasPowerUp2, hasPowerUp3, hasPowerUp4;

    public GUIText notification;

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
        if (!hasPowerUp1 && PlayerPrefs.GetInt("totalcoins") >= 5)
        {
            if (PlayerPrefs.GetInt("hasPowerUp1") == 0)
            {
                hasPowerUp1 = true;
                PlayerPrefs.SetInt("hasPowerUp1",1);
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 5);
            } else
            {
                StartCoroutine(ShowMessage("You already got this power up.", 1));
            }
            // todo - enable player script new power up
        }
      
        else
        {
            StartCoroutine(ShowMessage("You don't have enough coins man!", 1));
        }
    }

   public void buyPowerUp2()
    {
        // TODO
        if (!hasPowerUp2 && PlayerPrefs.GetInt("totalcoins") >= 10)
        {
            if (PlayerPrefs.GetInt("hasPowerUp2") == 0)
            {
                hasPowerUp2 = true;
                PlayerPrefs.SetInt("hasPowerUp2",1);
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 10);
            } else
            {
                StartCoroutine(ShowMessage("You already got this power up.", 1));
        
            }
            // todo - enable player script new power up
        }
      
        else
        {
            StartCoroutine(ShowMessage("You don't have enough coins man!", 1));
        }
    }

   public void buyPowerUp3()
    {
        if (!hasPowerUp3 && PlayerPrefs.GetInt("totalcoins") >= 15)
        {
            if (PlayerPrefs.GetInt("hasPowerUp3") == 0)
            {
                hasPowerUp3 = true;
                PlayerPrefs.SetInt("hasPowerUp3",1);
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 15);
            } else
            {
                StartCoroutine(ShowMessage("You already got this power up.", 1));
            }
            // todo - enable player script new power up
        }
      
        else
        {
            StartCoroutine(ShowMessage("You don't have enough coins man!", 1));
        }
    }

   public void buyPowerUp4()
    {
        if (!hasPowerUp4 && PlayerPrefs.GetInt("totalcoins") >= 20)
        {
            if (PlayerPrefs.GetInt("hasPowerUp4") == 0)
            {
                hasPowerUp4 = true;
                PlayerPrefs.SetInt("hasPowerUp4",1);
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 20);
            } else
            {
                StartCoroutine(ShowMessage("You already got this power up.", 1));
            }
            // todo - enable player script new power up
        }
      
        else
        {
            StartCoroutine(ShowMessage("You don't have enough coins man!", 1));
           
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
    
    IEnumerator ShowMessage (string message, float delay) {
       
        GetComponent<GUIText>().text = message;
        GetComponent<GUIText>().enabled = true;
        yield return new WaitForSeconds(delay);
        GetComponent<GUIText>().enabled = false;
    }

}
