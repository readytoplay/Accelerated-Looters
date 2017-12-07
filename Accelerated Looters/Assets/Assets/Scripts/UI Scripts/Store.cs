using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        if (!hasPowerUp1 && PlayerPrefs.GetInt("totalcoins") >= 5)
        {
            if (PlayerPrefs.GetInt("hasPowerUp1") == 0)
            {
                hasPowerUp1 = true;
                PlayerPrefs.SetInt("hasPowerUp1",1);
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 5);
            } else
            {
                bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You already got this power up.", "Ok");
            }
            // todo - enable player script new power up
        }
      
        else
        {
            bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You don't have enough coins man!", "Ok");
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
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 5);
            } else
            {
                bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You already got this power up.", "Ok");
            }
            // todo - enable player script new power up
        }
      
        else
        {
            bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You don't have enough coins man!", "Ok");
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
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 5);
            } else
            {
                bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You already got this power up.", "Ok");
            }
            // todo - enable player script new power up
        }
      
        else
        {
            bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You don't have enough coins man!", "Ok");
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
                PlayerPrefs.SetInt("totalcoins", PlayerPrefs.GetInt("totalcoins") - 5);
            } else
            {
                bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You already got this power up.", "Ok");
            }
            // todo - enable player script new power up
        }
      
        else
        {
            bool rang = EditorUtility.DisplayDialog("Failed buy power up ", "You don't have enough coins man!", "Ok");
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
