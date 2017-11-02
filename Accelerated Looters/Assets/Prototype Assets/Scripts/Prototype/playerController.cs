using System;
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
	public float time1;
	public LevelManager MyLevelManager;
	public int coins;
	public bool beingCollected;
	public KillEnemy charaterKilling; //variable for KillEnemy class
	public GameObject killBox;
	
	// Use this for initialization
	void Start ()
	{
		
		beingCollected = false;
		myRigidbody = GetComponent<Rigidbody2D>();
		MyLevelManager=FindObjectOfType<LevelManager>();
		charaterKilling = FindObjectOfType<KillEnemy> ();
		coins = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		beingCollected = false;
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

		if (myRigidbody.velocity.y < 0)
		{
			killBox.SetActive(true);
		}
		else
		{
				killBox.SetActive(false);
		}
		
		
		
		
		
		
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("KillPlane"))
		{
			transform.position = respawn_pos;
			MyLevelManager.HurtPlayer(1);
		}
		if (other.CompareTag("CheckPoint"))
		{
			respawn_pos = other.transform.position;
		}
		if (other.CompareTag("Enemy"))
		{
			if (charaterKilling.killingEnemy == false) {	//if we are not killing anyone and we collide with enemy, we lose health
				MyLevelManager.HurtPlayer (1);
			}
		}
		if (other.CompareTag("Coin"))
		{
			//In case the coins are being collected again before it disappears
			if (!beingCollected) 
			{
				coins++;
				beingCollected = true;
			}
			Destroy(other.gameObject);
			
		}
		
		
	}



}

