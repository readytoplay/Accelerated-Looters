using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{

	public float EnemySpeed;
	public bool CanMove;

	public Rigidbody2D myBody;
	// Use this for initialization
	void Start()
	{
	
	}

	// Update is called once per frame
	void Update()
	{
		if (CanMove)
		{
			myBody.velocity=new Vector3(EnemySpeed,myBody.velocity.y,0f);
	
		}
	}

	private void OnBecameVisible() // as soon as any game objiects appear on the camara's view
	{
		CanMove = true;
	}
}
