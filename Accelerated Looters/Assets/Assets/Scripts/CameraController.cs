using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour
{
	//player
	public GameObject Player;

	//camera a little bit ahead of the player
	public float AheadOfPlayer;

	//the actual position that the camera will follow 
	//(a bit ahead of the player depends on if it's going to the left or right)
	public Vector3 TargetPosition;

	public float DelayTime;

	
	
	
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//camera follow the player when it moves left and right.
		TargetPosition = new Vector3(Player.transform.position.x, transform.position.y,transform.position.z);
		
		//check the direction that the player is going

		if (Player.transform.localPosition.x > 0f)
		{
			TargetPosition = new Vector3(TargetPosition.x + AheadOfPlayer, transform.position.y, transform.position.z);
			
		}
		else
		{
			TargetPosition = new Vector3(TargetPosition.x - AheadOfPlayer, transform.position.y, transform.position.z);
			
		}

		    transform.position = Vector3.Lerp(transform.position, TargetPosition, DelayTime*Time.deltaTime);
		

	}
}
