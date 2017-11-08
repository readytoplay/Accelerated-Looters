using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// chunk is the space we're inializing for our current procedue
/// </summary>
internal class Chunk
{
    public Rect _rect;
    
    /// <summary>
    /// initialize a chunk of given dimensions
    /// </summary>
    /// <param name="x"></param> x top left
    /// <param name="y"></param> y top left
    /// <param name="w"></param> width
    /// <param name="h"></param> height
    public Chunk(float x, float y, float w, float h)
    {
        _rect = new Rect(x, y, w, h);
    }

    /// <summary>
    /// initialize a chunk with given rect
    /// </summary>
    /// <param name="_rect"></param>
    public Chunk(Rect rect)
    {
        _rect = _rect;
    }

    /// <summary>
    /// default constructor, grab camera dimensions to intialize the rect
    /// </summary>
    public Chunk(float width)
    {
        var cam = Camera.main;
        _rect = new Rect(cam.rect.x, cam.rect.y, width, cam.rect.height);
    }
}

public class ProceduralController : MonoBehaviour {

    [SerializeField]
    public GameObject prefab_lowerPlatform;
    public GameObject prefab_spikes;

    //state variables
    private Chunk _curChunk;

    //game variables
    private Transform _playerTransform;

    //useful info
    private const float CHUNK_W = 50f, BOX_WIDTH = 0.8f;

	// Use this for initialization
	void Start () {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _curChunk = new Chunk(CHUNK_W);
        _fillChunk(_curChunk);
    }

    /// <summary>
    /// fill current chunk procedurally
    /// </summary>
    /// <param name="chunk">the chunk we're working on</param>
    private void _fillChunk(Chunk chunk)
    {
        _generateFloor(chunk);
    }

    /// <summary>
    /// generates the floor of current chunk
    /// </summary>
    /// <param name="c">the chunk we're working on</param>
    private void _generateFloor(Chunk c)
    {
        _generatePiece(c._rect.x, c._rect.y, CHUNK_W);
    }

    /// <summary>
    /// generates a platform piece starting from x,y for l length
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="l"></param>
    private void _generatePiece(float x, float y, float len)
    {
        var cur_length = x;
        while(cur_length < len)
        {
            Instantiate(prefab_lowerPlatform, new Vector3(cur_length, y, 0), Quaternion.identity);
            cur_length += BOX_WIDTH;
        }
    }
    
	// Update is called once per frame
	void Update () {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        // check if we need to fill a new chunk
        if (checkForChunkRefresh())
        {
            var c = _findNewChunk();
            _fillChunk(c);
            _curChunk = c;
        }
	}

    /// <summary>
    /// finds the new chunk
    /// </summary>
    /// <returns></returns>
    private Chunk _findNewChunk()
    {
        return new Chunk(_curChunk._rect.xMin + CHUNK_W, _curChunk._rect.y, CHUNK_W, _curChunk._rect.height);
    }

    /// <summary>
    /// if player is halfway through the chunk, create the next chunk
    /// </summary>
    /// <returns></returns>
    private bool checkForChunkRefresh()
    {
        if(_playerTransform.position.x > (_curChunk._rect.xMin + _curChunk._rect.xMax) / 2)
        {
            return true;
        }
        return false;
    }
}
