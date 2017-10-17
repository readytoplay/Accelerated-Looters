using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WiggledEnemyMovement : MonoBehaviour
{

	public float moveSpeed;

	public Transform leftPoint;
	public Transform rightPoint;

	public Transform destination;

	private Rigidbody2D myRigidBody;
	
	


	// Use this for initialization
	void Start()
	{
		destination = rightPoint;
		myRigidBody=GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (destination == rightPoint && transform.position.x > rightPoint.position.x)
		{
			destination = leftPoint;
		}else if (destination == leftPoint && transform.position.x < leftPoint.position.x)
		{
			destination = rightPoint;
		}
		
		if (destination == rightPoint)
		{
			myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
		}
		else
		{
			myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
		}
		
		

	}
}

