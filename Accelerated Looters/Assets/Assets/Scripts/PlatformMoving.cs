using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {


	public Transform[] point;
	public int startPoint;
	public int nextPoint;
	public float speed;



	// Use this for initialization
	void Start () {
		transform.position = point [startPoint].position;	//set the platform to the first position
	}

	// Update is called once per frame
	void Update () {
		//from our current position to our target time with some speed
		transform.position = Vector2.MoveTowards (transform.position, point [nextPoint].position, speed * Time.deltaTime);
		if (transform.position == point [nextPoint].position) {//check if we arrive the point
			nextPoint ++; //+1 which toworard to other point
			if (nextPoint == point.Length) {
				nextPoint = 0;
			}
		}


	}
}

