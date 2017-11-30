using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Spikes : MonoBehaviour {

    public playerController player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<playerController>(); //gets script to access
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            player.spikeDamage();
            player.myRigidbody.velocity = new Vector3(player.myRigidbody.velocity.x, player.jumpSpeed + 5, 0);
        }
    }
}
