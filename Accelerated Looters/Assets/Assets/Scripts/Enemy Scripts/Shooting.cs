using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject TheBulletStart;

	public GameObject Bullet;

	public float ShootWaitTime;

	public float BulletSpeed;
	
	public bool Shootable;
	
	

	// Use this for initialization
	void Start () {
		Shootable = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Shootable)
		{
			shoot();
			StartCoroutine(waitToShootAgain());
		}
		

	}
	
	
	void shoot()
	{
		Instantiate(Bullet.transform, TheBulletStart.transform.position, transform.rotation);
	
		

	}
	
	IEnumerator waitToShootAgain()
	{
		Shootable = false;
		yield return new WaitForSeconds(3f);
		Shootable = true;
	}


}
