
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;



public class WiggleEnemy2 : MonoBehaviour
{

	public float moveSpeed;

	public Transform leftPoint;
	public Transform rightPoint;

	public Transform destination;

	private Rigidbody2D myRigidBody;
	
	


	// Use this for initialization
	void Start()
	{
		
		myRigidBody=GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (destination == rightPoint && transform.position.x > rightPoint.position.x) // if the enemy passed the right point (when it moves to right)
		{																				// the destination set to left and vice versa
			destination = leftPoint;													
		}else if (destination == leftPoint && transform.position.x < leftPoint.position.x)
		{
			destination = rightPoint;
		}
		
		if (destination == rightPoint) // moves to right
		{
			myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
			GetComponent<SpriteRenderer> ().flipX = false;

		}
		else //moves to left
		{
			myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
			GetComponent<SpriteRenderer> ().flipX = true;

		}
		
		

	}
}

