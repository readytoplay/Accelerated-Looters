using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // Integers ***
    public int coins;
    public int life_count; //player health

    // Floats ***
    public float moveSpeed;
    public float inAirMoveSpeed;
    public float originalSpeed;

    public float jumpSpeed;
    public float originalJumpSpeed;

    public float groundRadius;
    public float time1;

    public float HighJumpTimer = 10.0f; //Timer for HighJump power
    public float SpeedBoostTimer = 10.0f; //Timer for SpeedBoost power
    public float DoubleCoinTimer = 10.0f; //Timer for DoubleCoin power    
    public float InvincibleTimer = 10.0f; //Timer for Invincible power
    public float jumpBuffer = 0f; // time for double jump to avoid jumping all at once
    public float spikeCooldown = 3.0f;

    // Booleans ***
    public bool isGrounded; // make sure we don't have to check all the time
    public bool CoinBoost; //does player get extra coins
    public bool Invincible; //is the player invincible
    public bool beingCollected;
    public bool doubleJump;
    public bool hasPowerUp1, hasPowerUp2, hasPowerUp3, hasPowerUp4;
    public bool invincibleToSpikeDamage;


    // Objects ***
    // Game Objects 
    public GameObject spike;
    public GameObject GameOver; //display game over
    public GameObject killBox;

    // Other Objects
    public Rigidbody2D myRigidbody;
    public Transform groundCheck; //the point that is at the buttom of the character to check if it touched the ground
    public LayerMask whatIsGround; // specify the layer "Ground" (all the platforms and grounds.)
    public KillEnemy charaterKilling; //variable for KillEnemy class
    public LevelManager MyLevelManager;
    public CheckPointController checkPointChecker;  //check if we go though that checkpoint before
    public Animator myAnim;


    Vector3 respawn_pos;    //the position that the player gonna respawn

    //database stuff

    public databaseController db;

    public string userName;
    
    
    
    //total coins
    public int totalCoins;

    //high score (enemies killed number)
    public int highScore;
    public KillEnemy k;
    public bool scoresAdded;

    //state vars
    public bool isSpeedBoost;
    private bool _jumpBuffer;

    
   /*** double jump - powerup1
        triple coin - powerup2
        faster movement - powerup3
        extra life - powerup4
   ***/
   
    // Use this for initialization
    void Start()
    {
        scoresAdded = false;

        db = FindObjectOfType<databaseController>();
        userName = "Default";
        // Variable Setting
        life_count = 3; // player life
        originalJumpSpeed = jumpSpeed;
        originalSpeed = moveSpeed;
        beingCollected = false;
        coins = 0;
        CoinBoost = false;
        GameOver.SetActive(false); // hide game over
        isSpeedBoost = false;
        invincibleToSpikeDamage = false;


        // Get Components/Get Types
        myRigidbody = GetComponent<Rigidbody2D>();
        MyLevelManager = FindObjectOfType<LevelManager>();
        charaterKilling = FindObjectOfType<KillEnemy>();
        checkPointChecker = FindObjectOfType<CheckPointController>();
        myAnim = FindObjectOfType<Animator>();


        //Get history coins number
        totalCoins = PlayerPrefs.GetInt("totalcoins");

        if (PlayerPrefs.GetInt("hasPowerUp4") == 1)
        {
            life_count = 5;
        }

        //Get high score
        k = FindObjectOfType<KillEnemy>();
        highScore = PlayerPrefs.GetInt("highscore");


    }

    /// <summary>
    /// called once per fixed interval
    /// </summary>
    private void FixedUpdate()
    {
        findGround();
    }

    private void findGround()
    {
        invincibleToSpikeDamage = false;
        var objs = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (var obj in objs)
        {
            if (obj.tag == "Ground")
                invincibleToSpikeDamage = true;
        }
    }

    // Update is called once per frame
    // Everyone, please use functions and function calls instead of putting everything in the Update() function, thanks.
    void Update()
    {
        beingCollected = false;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        powerUp3(); //sets speed base on whether you have powerup3

        handleMovement(); // handles player's movement

        handleFallingOffMap(); // if player falls off map

        healthManager(); // check life count

        powerUpTimers(); // handles the power up timers

        increaseSpikeTime(); //
    }

    /*
     * Method for movement
     */
    void handleMovement()
    {

        myAnim.SetBool("isJumping", !isGrounded);
        if (Input.GetAxisRaw("Horizontal") > 0f) //move to right (value >0 is to the right)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0);
            //myAnim.SetBool("isJumping", false);
            myAnim.SetFloat("Speed", moveSpeed);
            transform.eulerAngles = new Vector2(0, 0); //flip the character


        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) //move to right (value >0 is to the right)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0);
            // myAnim.SetBool("isJumping", false);
            myAnim.SetFloat("Speed", moveSpeed);
            transform.eulerAngles = new Vector2(0, 180); //flip the character


        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            // myAnim.SetBool("isJumping", false);
            myAnim.SetFloat("Speed", 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded) //jump (value>0 is up)
        {
            jumpBuffer = 0;
            myAnim.SetBool("isJumping", true);
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0);
        }

        jumpBuffer = jumpBuffer + Time.deltaTime;
        if (Input.GetButtonDown("Jump") && doubleJump && jumpBuffer < 1.0f && !isGrounded)
        {
            Debug.Log("plz");
            doubleJump = false;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0);
        }

        if(Input.GetButtonDown("Jump") && !isGrounded)
        {
            StartCoroutine(_awaitLanding());
        }

        if (isGrounded)
        {
            doubleJump = true;
        }

        if (myRigidbody.velocity.y < 0)
        {
            killBox.SetActive(true);
        }
        else
        {
            killBox.SetActive(false);
        }
        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));

    }

    private const float JUMP_QUEUE_WAIT = 0.05f;
    private IEnumerator _awaitLanding()
    {
        var totalWait = 0f;
        while (!isGrounded) {
            if (totalWait > 1f)
                break;
            totalWait += JUMP_QUEUE_WAIT;
            yield return new WaitForSeconds(JUMP_QUEUE_WAIT);
        }
        if(totalWait <= 0.3f)
        {
            jumpBuffer = 0;
            myAnim.SetBool("isJumping", true);
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0);
        }
    }

    /*
     * Method for handling the power up timers
     */
    void powerUpTimers()
    {
        HighJumpTimer -= Time.deltaTime; //decreases HighJump timer
        if (HighJumpTimer <= 0)
        {
            HighJumpTimer = 10.0f; //reset HighJump timer
            jumpSpeed = originalJumpSpeed; //reset HighJump to normal
        }

        SpeedBoostTimer -= Time.deltaTime; //decreases SpeedBoost timer
        if (SpeedBoostTimer <= 0)
        {
            SpeedBoostTimer = 10.0f; //reset SpeedBoost timer
            moveSpeed = originalSpeed; //reset SpeedBoost to normal
            isSpeedBoost = false;
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
    }

    /*
    * Methof for handling if the player falls off the map
    */
    void handleFallingOffMap()
    {
        if (transform.position.y <= -10.0)
        {           //if felt, lose health
            MyLevelManager.HurtPlayer(1);
            transform.position = respawn_pos;
        }
    }

    /*
     * Check player's health status
     */
    void healthManager()
    {
        if (life_count <= 0)
        {
            //update coins
            PlayerPrefs.SetInt("totalcoins", totalCoins + coins);
            //update high score

            if (k.enemyKilled >  PlayerPrefs.GetInt("localhighscore"))
            {
                PlayerPrefs.SetInt("localhighscore", k.enemyKilled); //local high score always shows the highest one
            }
           
            PlayerPrefs.SetInt("highscore", k.enemyKilled);
            if (!scoresAdded)
            {
                //all score records store in the database
                StartCoroutine(db.PostScores(PlayerPrefs.GetString("PlayerName"), PlayerPrefs.GetInt("highscore")));
                scoresAdded = true;
            }

            if (SceneManager.GetActiveScene().name == "Jungle Level 1")
            {
                SceneManager.LoadScene("Jungle Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Underwater Level 2")
            {
                SceneManager.LoadScene("UW Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Haunted Level 3")
            {
                SceneManager.LoadScene("Haunted Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Snow Level 4")
            {
                SceneManager.LoadScene("Snow Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Jungle PCG")
            {
                SceneManager.LoadScene("Jungle PCG Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Underwater PCG")
            {
                SceneManager.LoadScene("UW PCG Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Haunted PCG")
            {
                SceneManager.LoadScene("Haunted PCG Game Over Menu");
            }

            if (SceneManager.GetActiveScene().name == "Snow PCG")
            {
                SceneManager.LoadScene("Snow PCG Game Over Menu");
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {

            respawn_pos = other.transform.position;         //record the transition point
        }

        if (other.CompareTag("Enemy"))
        {
            if (!Invincible)
            { //check if player is invincible before doing damage
                if (charaterKilling.killingEnemy == false)
                {   //if we are not killing anyone and we collide with enemy, we lose health
                    MyLevelManager.HurtPlayer(1);
                    this.setInvincible();
                    InvincibleTimer = 2.0f;


                }
            }
        }


        if (other.CompareTag("Coin"))
        {
            //In case the coins are being collected again before it disappears
            if (!beingCollected)
            {
                if (CoinBoost && hasPowerUp2)
                {
                    coins = coins + 6;
                }
                else if (PlayerPrefs.GetInt("hasPowerUp2") == 1)
                {
                    coins = coins + 3;
                }
                else if (CoinBoost)
                {
                    coins = coins + 2;
                    beingCollected = true;
                }
                else
                {
                    coins++;
                }
            }
            Destroy(other.gameObject);

        }



    }//when player collide

    void OnCollisionEnter2D(Collision2D player)
    {
        //if player collide with platform
        if (player.gameObject.CompareTag("movingPlatform"))
        {
            transform.SetParent(player.transform);  //set the player parent to the movingPlatform and move together

        }
    }
    //when player exit collide
    void OnCollisionExit2D(Collision2D player)
    {

        if (player.gameObject.CompareTag("movingPlatform"))
        {
            transform.SetParent(null);              //set the player parent off the movingPlatform
        }

    }

    public void setHighJump()
    { //increases height of jump
        jumpSpeed = 25f;
        HighJumpTimer = 10.0f;
    }

    public void setSpeedBoost()
    { //increases height of jump
        isSpeedBoost = true;
        originalSpeed = moveSpeed;
        moveSpeed += 5;
        SpeedBoostTimer = 10.0f;
    }

    public void setDoubleCoin()
    { //doubles amount of coins collected
        CoinBoost = true;
        DoubleCoinTimer = 10.0f;
    }

    public void setInvincible()
    { //doubles amount of coins collected
        Invincible = true;
        InvincibleTimer = 10.0f;
    }

    public void powerUp3()
    {
        if (PlayerPrefs.GetInt("hasPowerUp3") == 1)
        {
            moveSpeed = 10f;
        }
    }
    
    public void powerUp1()
    {
        if (PlayerPrefs.GetInt("hasPowerUp1") == 1)
        {
            jumpSpeed = 22f;
         
        }
    }

    public void increaseSpikeTime()
    {
        spikeCooldown = spikeCooldown + Time.deltaTime;
    }

    public void spikeDamage()
    {
        if (spikeCooldown > 3.0f)
        {
            MyLevelManager.HurtPlayer(1);
            spikeCooldown = 0.0f;
        }
    }

}