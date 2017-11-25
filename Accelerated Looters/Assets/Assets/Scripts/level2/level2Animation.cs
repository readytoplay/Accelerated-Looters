using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2Animation : MonoBehaviour
{

	public playerController p;

	public Animator a;

	public Rigidbody2D MyRigidbody2D;

	public float velocity;

	public bool isGrounded;

	// Use this for initialization
	void Start ()
	{
		p = FindObjectOfType<playerController>();
		a = GetComponent<Animator>();
		MyRigidbody2D = p.myRigidbody;
	}
	
	// Update is called once per frame
	void Update ()
	{
		velocity =Mathf.Abs( MyRigidbody2D.velocity.x);
		isGrounded = p.isGrounded;
		a.SetFloat("Speed", velocity);
		a.SetBool("Grounded", isGrounded);
	}
}
