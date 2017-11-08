using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// chunk is the space we're inializing for our current procedue
/// </summary>
internal class Chunk
{
    /// <summary>
    /// the rect this chunk is worried about
    /// </summary>
    private Rect _rect;
    
    /// <summary>
    /// get the rect
    /// </summary>
    public Rect getRect()
    {
        return _rect;
    }

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
        _rect = rect;
    }

    /// <summary>
    /// default constructor, grab camera dimensions to intialize the rect
    /// </summary>
    public Chunk(float width)
    {
        var cam = Camera.main;
        _rect = new Rect(cam.rect.x-2f, cam.rect.y, width, cam.rect.height);
    }
}

/// <summary>
/// represents the type of platform we wana make
/// </summary>
public enum PLATFORM_TYPE {  FLOOR_T, AIR_T, SPIKE_T };

public class ProceduralController : MonoBehaviour {

    [SerializeField]
    public GameObject prefab_lowerPlatform;
    public GameObject prefab_spikes;

    //state variables
    private Chunk _curChunk;
    private float _curFloorEnd;

    //game variables
    private Transform _playerTransform;
    private List<GameObject> _currentFloorChunkObjects;

    //useful info
    private const float BOX_WIDTH = 0.8f, FLOOR_Y = -3f;
    private float CHUNK_W = 50f;

    //initialize list before
    private void Awake()
    {
        _currentFloorChunkObjects = new List<GameObject>();
    }

    // Use this for initialization
    void Start () {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("_checkMemory()", 0, 5);
        _curChunk = new Chunk(CHUNK_W);
        _fillChunk(_curChunk);
    }

    /// <summary>
    /// generates a random number
    /// </summary>
    /// <param name="min">min value</param>
    /// <param name="max">max value</param>
    private int _randomNum(int min, int max)
    {
        var rand = new System.Random();
        return rand.Next(min, max);
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
    /// destroys a list of gameobjects
    /// </summary>
    /// <param name="l">the list</param>
    private void _destroyObjects(List<GameObject> l)
    {
        foreach(var go in l)
        {
            Destroy(go);
        }
        l.Clear();
    }

    /// <summary>
    /// generates the floor of current chunk
    /// </summary>
    /// <param name="c">the chunk we're working on</param>
    private void _generateFloor(Chunk c)
    {
        _generatePiece(c.getRect().xMin, FLOOR_Y, CHUNK_W, PLATFORM_TYPE.FLOOR_T);
    }

    /// <summary>
    /// generates a platform piece starting from x,y for l length
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="l"></param>
    private void _generatePiece(float x, float y, float len, PLATFORM_TYPE pt)
    {
        //case: we're generating a floor object
        if (pt == PLATFORM_TYPE.FLOOR_T)
        {
            var cur_length = x;
            while (cur_length < len)
            {
                var num = _randomNum(1, 5);
                PLATFORM_TYPE pt2;
                if (_randomNum(0, 2) == 1) pt2 = PLATFORM_TYPE.FLOOR_T;
                else pt2 = PLATFORM_TYPE.SPIKE_T;
                for (var i = 0; i < num; ++i)
                {
                    if (pt2 == PLATFORM_TYPE.FLOOR_T)
                    {
                        _currentFloorChunkObjects.Add(Instantiate(prefab_lowerPlatform, new Vector3(cur_length, y, 0), Quaternion.identity));
                    }
                    else
                    {
                        _currentFloorChunkObjects.Add(Instantiate(prefab_spikes, new Vector3(cur_length, y, 0), Quaternion.identity));
                    };
                    cur_length += BOX_WIDTH;
                }
            }
            _curFloorEnd = cur_length;
        }
    }

    /// <summary>
    /// removes distant tiles
    /// </summary>
    private void _checkMemory()
    {
        for (var i = 0; i < _currentFloorChunkObjects.Count; ++i)
        {
            if(_currentFloorChunkObjects[i].transform.position.x + 25f < _playerTransform.position.x)
            {
                Destroy(_currentFloorChunkObjects[i]);
                _currentFloorChunkObjects.RemoveAt(i);
                i--;
            }
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
        _checkMemory();
	}

    /// <summary>
    /// finds the new chunk
    /// </summary>
    private Chunk _findNewChunk()
    {
        var c = new Chunk(_curFloorEnd, _curChunk.getRect().y, CHUNK_W, _curChunk.getRect().height);
        CHUNK_W *= 2;
        return c;
    }

    /// <summary>
    /// if player is halfway through the chunk, create the next chunk
    /// </summary>
    private bool checkForChunkRefresh()
    {
        if (_playerTransform.position.x > (_curChunk.getRect().xMin + _curChunk.getRect().xMax) / 2.0f)
        {
            return true;
        }
        return false;
    }
}
