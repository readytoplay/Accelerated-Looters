using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingPlayer : MonoBehaviour {

    [SerializeField]
    bool enabled;

    
    /// <summary>
    /// logarithmic function to update player movement speed
    /// </summary>
    private float _f(float x)
    {
        if (x > 40f) return x;
        return x+1;
    }

    /// <summary>
    /// updates player movement speed by _f(x) function
    /// </summary>
    private IEnumerator _updateSpeed()
    {
        var p_moveSpeed = GetComponent<playerController>().moveSpeed;
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (GetComponent<playerController>().isSpeedBoost)
                continue;
            else
            {
                p_moveSpeed = _f(p_moveSpeed);
                GetComponent<playerController>().moveSpeed = p_moveSpeed;
                GetComponent<playerController>().originalSpeed = p_moveSpeed;
            }
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(_updateSpeed());
    }
}
