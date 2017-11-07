using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.CrashReportHandler;

public class BulletTest : MonoBehaviour
{
	public LevelManager MyLevelManager;

	

	public bool crash;
	
	public float maxDistance;




	
	
	public Vector3 SoundInstantiate;

	public GameObject clone;


	// Use this for initialization
	void Start ()
	{
		
		
	
		MyLevelManager=FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
			
		
		transform.Translate(-10f*Time.deltaTime,0f,0f);
		maxDistance += 2f*Time.deltaTime;
		if (maxDistance >= 2)
		{
			DestroyBullet();
		}

		
	}


	public void OnTriggerEnter2D(Collider2D other)
		{
			
		if ((other.CompareTag("Player")))
		{
			MyLevelManager.HurtPlayer(1);

			
			DestroyBullet();
		}
		else
		{
			return;
		}
		
	}
	


	void DestroyBullet()
	{
		
		Destroy(gameObject);
	}
	

	
}
