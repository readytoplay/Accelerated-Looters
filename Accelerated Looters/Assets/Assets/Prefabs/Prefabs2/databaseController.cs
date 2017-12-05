using UnityEngine;
using System.Collections;
using System.Security.Policy;
using UnityEngine.UI;

public class databaseController : MonoBehaviour
{
	private string secretKey = "a1"; //it's the same as the one stored on the server
	public string addScoreURL = "http://vidaviajera.tk/add_score.php?"; 
	public string highscoreURL = "http://vidaviajera.tk/display_score.php";

	public Text displayHighScores;
 
	void Start()
	{
		StartCoroutine(GetScores());
	}
 

	// remember to use StartCoroutine when calling this function!
	public IEnumerator PostScores(string name, int score)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
	
 
		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score ;
 
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		Debug.Log("high score posted??");
		Debug.Log(hs_post.error);
		yield return hs_post; // Wait until the download is done
 
		if (hs_post.error != null)
		{
			Debug.Log(" error posting" + hs_post.error);
			print("There was an error posting the high score: " + hs_post.error);
		}
		Debug.Log("what??");
	}
 
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores()
	{
		displayHighScores.text = "Loading High Scores.. Please wait..";
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;
 
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{
			displayHighScores.text= hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}
 
}