using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralController : MonoBehaviour {

    [SerializeField]
    public GameObject gO;

    private Transform _playerTransform;
    private const float FLOOR_Y = -4.86f, BOX_WIDTH = 0.8f, START_X = -9.5f, CHUNK_WIDTH = 10f; //TODO find right width

	// Use this for initialization
	void Start () {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _generateFloor();
    }

    private void _generateFloor()
    {
        _generatePiece(START_X, FLOOR_Y, CHUNK_WIDTH);
    }

    /// <summary>
    /// generates a platform piece statying from x,y for l length
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="l"></param>
    private void _generatePiece(float x, float y, float len)
    {
        var cur_length = x;
        for (var i = 0; i<len; ++i)
        {
            Instantiate(gO, new Vector3(cur_length, y, 0), Quaternion.identity);
            cur_length += BOX_WIDTH;
        }
    }
    
	// Update is called once per frame
	void Update () {
        
	}
}
