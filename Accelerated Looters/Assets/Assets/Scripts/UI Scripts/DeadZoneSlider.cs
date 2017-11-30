using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZoneSlider : MonoBehaviour {

	public Slider mainSlider;
	public GameObject deadZone;
	
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		mainSlider.value=deadZone.transform.position.x;
	}
}

