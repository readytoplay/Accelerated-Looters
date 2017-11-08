using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
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
	public CheckPointController checkPointChecker;	//check if we go though that checkpoint before
	public int life_count;						//player health
	public GameObject GameOver;					//display game over
	public float HighJumpTimer = 10.0f; //Timer for HighJump power
	public float SpeedBoostTimer = 10.0f; //Timer for SpeedBoost power
	public float DoubleCoinTimer = 10.0f; //Timer for DoubleCoin power
	public bool CoinBoost; //does player get extra coins
	public bool Invincible; //is the player invincible
	public float InvincibleTimer = 10.0f; //Timer for Invincible power
	public GameObject spike;


	// Use this for initialization
	void Start ()
	{
		life_count = 3;	//player life
		beingCollected = false;
		myRigidbody = GetComponent<Rigidbody2D>();
		MyLevelManager=FindObjectOfType<LevelManager>();
		charaterKilling = FindObjectOfType<KillEnemy> ();
		checkPointChecker = FindObjectOfType<CheckPointController> ();
		coins = 0;
		CoinBoost = false;
		GameOver.SetActive(false);				//hide game over
        
	}

    // Update is called once per frame
    void Update()
    {
        beingCollected = false;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //it does a overlap circle around the point that we have to the given size and checks if it is the right layer
        //within us.

        if (Input.GetAxisRaw("Horizontal") > 0f) //move to right (value >0 is to the right)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0);

        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) //move to right (value >0 is to the right)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0);

        }
        if (Input.GetButtonDown("Jump") && isGrounded) //jump (value>0 is up)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0);

        }

        if (myRigidbody.velocity.y < 0)
        {
            killBox.SetActive(true);
        }
        else
        {
            killBox.SetActive(false);
        }
        if (life_count <= 0)
        {
            GameOver.SetActive(true);       //set gameover true
            Time.timeScale = 0;
        }
        if (transform.position.y <= -10.0)
        {           //if felt, lose health
            MyLevelManager.HurtPlayer(1);
            transform.position = respawn_pos;
        }

        HighJumpTimer -= Time.deltaTime; //decreases HighJump timer
        if (HighJumpTimer <= 0)
        {
            HighJumpTimer = 10.0f; //reset HighJump timer
            jumpSpeed = 11f; //reset HighJump to normal
        }

        SpeedBoostTimer -= Time.deltaTime; //decreases SpeedBoost timer
        if (SpeedBoostTimer <= 0)
        {
            SpeedBoostTimer = 10.0f; //reset SpeedBoost timer
            moveSpeed = 10; //reset SpeedBoost to normal
        }

        DoubleCoinTimer -= Time.deltaTime; //decreases DoubleCoin timer
        if (DoubleCoinTimer <= 0)
        {
            DoubleCoinTimer = 10.0f; //reset DoubleCoin timer
            CoinBoost = false; //reset CoinBoost to normal
        }

        InvincibleTimer -= Time.deltaTime; //decreases Invincible timer
        if (InvincibleTimer <= 0)
        {
            InvincibleTimer = 10.0f; //reset Invincible timer
            Invincible = false; //reset Invincible to normal
        }

      //  if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
      //  {
       //     paused = togglePause();
       //     pauseMenuTemplate.SetActive(true);
       // } 


    }

    void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("CheckPoint")) {
				
				respawn_pos = other.transform.position;			//record the transition point
			}

		if (other.CompareTag("Enemy"))
		{
			if (!Invincible) { //check if player is invincible before doing damage
				if (charaterKilling.killingEnemy == false) {	//if we are not killing anyone and we collide with enemy, we lose health
					MyLevelManager.HurtPlayer (1);
				}
			}
		}
		if (other.CompareTag("Coin"))
		{
			//In case the coins are being collected again before it disappears
			if (!beingCollected) 
			{
				if (CoinBoost) {
					coins = coins + 2;
					beingCollected = true;
				} else {
					coins++;
				}
			}
			Destroy(other.gameObject);
			
		}

		
		
	}//when player collide

	void OnCollisionEnter2D(Collision2D player){
		//if player collide with platform
		if (player.gameObject.CompareTag ("movingPlatform")) {
			transform.SetParent (player.transform);  //set the player parent to the movingPlatform and move together

		}
	}
	//when player exit collide
	void OnCollisionExit2D(Collision2D player){

		if (player.gameObject.CompareTag ("movingPlatform")) {
			transform.SetParent (null);				//set the player parent off the movingPlatform
		}

	}

	public void setHighJump(){ //increases height of jump
		jumpSpeed = 17;
		HighJumpTimer = 10.0f;
	}

	public void setSpeedBoost(){ //increases height of jump
		moveSpeed = 20f;
		SpeedBoostTimer = 10.0f;
	}

	public void setDoubleCoin(){ //doubles amount of coins collected
		CoinBoost = true;
		DoubleCoinTimer = 10.0f;
	}

	public void setInvincible(){ //doubles amount of coins collected
		Invincible = true;
		InvincibleTimer = 10.0f;
	}

}