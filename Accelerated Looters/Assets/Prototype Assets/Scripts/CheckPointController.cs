using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

	public Sprite UnCheckedPoint;

	public Sprite CheckedPoint;

	public SpriteRenderer TheSpriteRenderer;

	public bool CheckPointActive;

	// Use this for initialization
	void Start ()
	{
		TheSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			TheSpriteRenderer.sprite = CheckedPoint;	//changing color
			CheckPointActive = true;
		}
		
	}
}
