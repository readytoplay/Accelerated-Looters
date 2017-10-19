using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class playerController : MonoBehaviour
{

	public float moveSpeed;
	public Rigidbody2D myRigidbody;
	public float jumpSpeed;
	public Transform groundCheck; //the point that is at the buttom of the character to check if it touched the ground
	public float groundRadius; 
	public LayerMask whatIsGround; // specify the layer "Ground" (all the platforms and grounds.)
	Vector3 respawn_pos;	//the position that the player gonna respawn
	public bool isGrounded; // make sure we don't have to check all the time
	
	
	
	// Use this for initialization
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		//it does a overlap circle around the point that we have to the given size and checks if it is the right layer
		//within us.
		
		
		
		
		if (Input.GetAxisRaw("Horizontal")>0f) //move to right (value >0 is to the right)
		{
			myRigidbody.velocity=new Vector3(moveSpeed, myRigidbody.velocity.y,0);
			
		} 
		else if (Input.GetAxisRaw("Horizontal")<0f) //move to right (value >0 is to the right)
		{
			myRigidbody.velocity=new Vector3(-moveSpeed, myRigidbody.velocity.y,0);

		} 
		if (Input.GetButtonDown("Jump")&&isGrounded) //jump (value>0 is up)
		{
			myRigidbody.velocity=new Vector3(myRigidbody.velocity.x,jumpSpeed,0);
			
		}
//		if (transform.position.y <= -15.0) {
//			
//		}
//		if (transform.position.y >= 8) {
//			transform.position = respawn_pos;
//		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("KillPlane"))
		{
			transform.position = respawn_pos;
		}
		if (other.tag == "CheckPoint")
		{
			respawn_pos = other.transform.position;
		}
		
		
	}
}

