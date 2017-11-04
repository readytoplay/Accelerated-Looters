using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

	public Sprite UnCheckedPoint;

	public Sprite CheckedPoint;

	public SpriteRenderer TheSpriteRenderer;
	public bool beenHere;
	public playerController player;
	public bool check;

	public bool CheckPointActive;
	// Use this for initialization
	void Start ()
	{
		TheSpriteRenderer = GetComponent<SpriteRenderer>();
		player = GetComponent<playerController>();
		beenHere = false;
		check = false;
	}

	// Update is called once per frame
	void Update () {
		beenHere = false;

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
				TheSpriteRenderer.sprite = CheckedPoint;  		//changing color sprite

			}
		}
		
	}

