using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	public float EnemySpeed;
	public float EnemyJumpSpeed;

	public Vector3 StartPoint;
	public Vector3 EndPoint;
	public Vector3 Destination; //Destination will be set to endpoint initially 

	[SerializeField] public Transform Enemy;

	[SerializeField] public Transform EnemyEnd; // the transform for the end point of the enemy




	// Use this for initialization
	void Start()
	{
		StartPoint = Enemy.localPosition;
		EndPoint = EnemyEnd.localPosition; // Get the vector of start and end point
		Destination = EndPoint;

	}

	// Update is called once per frame
	void Update()
	{
		Enemy.localPosition = Vector3.MoveTowards(Enemy.localPosition, Destination, EnemySpeed * Time.fixedDeltaTime);
		if (Vector3.Distance(Enemy.localPosition, Destination) < EnemySpeed * Time.fixedDeltaTime)
		{
			if (Enemy.position == StartPoint)
			{
				Destination = EndPoint;
			}
			else
			{
				Destination = StartPoint;
			}



		}
	}
}
