using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rbody;
	private Animator animation;

	public float jump;
	public float movement;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		animation = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump"))
		{
			rbody.AddForce (new Vector2 (0, jump));
		}
}

	void FixedUpdate(){
		var h = Input.GetAxis ("Horizontal");
		rbody.AddForce (new Vector2 (h * movement, 0));
		animation.SetFloat("Speed", Mathf.Abs (h));
	}
}