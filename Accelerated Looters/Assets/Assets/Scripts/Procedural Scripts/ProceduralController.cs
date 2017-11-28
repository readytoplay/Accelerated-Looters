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
        _rect = new Rect(cam.rect.x - 2f, cam.rect.y, width, cam.rect.height);
    }
}

/// <summary>
/// represents the type of platform we wana make
/// </summary>
public enum PLATFORM_TYPE { FLOOR_T, AIR_T, SPIKE_T };

public class ProceduralController : MonoBehaviour
{

    [SerializeField]
    public GameObject prefab_lowerPlatform;
    public GameObject prefab_spikes;

    //state variables
    private Chunk _curChunk;
    private float _curFloorEnd;
    private System.Random _random;

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
        _random = new System.Random();
    }

    // Use this for initialization
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("_checkMemory", 5, 5);
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
        return _random.Next(min, max);
    }

    /// <summary>
    /// fill current chunk procedurally
    /// </summary>
    /// <param name="chunk">the chunk we're working on</param>
    private void _fillChunk(Chunk chunk)
    {
        List<GameObject> curItems;
        _generateFloor(chunk, out curItems);
        _ensureLevelIsCompletable(curItems);
    }

    /// <summary>
    /// ensures you can complete the level
    /// </summary>
    private void _ensureLevelIsCompletable(List<GameObject> curItems)
    {
        var spikesList = new List<GameObject>();
        foreach(var piece in _currentFloorChunkObjects)
        {
            if (piece.tag == "spike" && piece.transform.position.x < _curFloorEnd)
                spikesList.Add(piece);
        }
        var spikesChunkList = new List<List<GameObject>>();
        var curList = new List<GameObject>();
        GameObject prev = null;
        for(var i=0; i<spikesList.Count; ++i)
        {
            if (i == 0) {
                curList.Add(spikesList[i]);
                prev = spikesList[i];
            }
            else if (spikesList[i].transform.position.x - prev.transform.position.x <= BOX_WIDTH+0.1f)
            {              
                curList.Add(spikesList[i]);
                prev = spikesList[i];
            }
            else
            {
                if (curList.Count > 5)
                {
                    spikesChunkList.Add(new List<GameObject>(curList));
                }
                curList.Clear();
                prev = spikesList[i];
            }
        }
        foreach(var spikeChunk in spikesChunkList)
        {
            _generateJumpable(spikeChunk);
        }
    }

    /// <summary>
    /// generate a platform aboves spikeChunk so that you can jump on it
    /// </summary>
    /// <param name="spikeChunk"></param>
    private void _generateJumpable(List<GameObject> spikeChunk)
    {
        //random variables
        var start_x = _randomNum(0,2);
        var end_x = _randomNum(spikeChunk.Count - 2, spikeChunk.Count);
        var random_y_jumpable = _random.NextDouble() * (3);

        //parameter calcuations
        var _x = spikeChunk[start_x].transform.position.x;
        var _y = (float)(spikeChunk[0].transform.position.y + random_y_jumpable);
        var _len = 5f + _x;


        List<GameObject> temp;
        _generatePiece(
            x:          _x,
            y:          _y,
            len:        _len,
            pt:         PLATFORM_TYPE.AIR_T,
            curObjects: out temp 
        );
        temp.Clear();
    }

    /// <summary>
    /// destroys a list of gameobjects
    /// </summary>
    /// <param name="l">the list</param>
    private void _destroyObjects(List<GameObject> l)
    {
        foreach (var go in l)
        {
            Destroy(go);
        }
        l.Clear();
    }

    /// <summary>
    /// generates the floor of current chunk
    /// </summary>
    /// <param name="c">the chunk we're working on</param>
    private void _generateFloor(Chunk c, out List<GameObject> curItems)
    {
        _generatePiece(c.getRect().xMin, FLOOR_Y, CHUNK_W, PLATFORM_TYPE.FLOOR_T, out curItems);
    }

    /// <summary>
    /// generates a platform piece starting from x,y for l length
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="l"></param>
    private void _generatePiece(float x, float y, float len, PLATFORM_TYPE pt, out List<GameObject> curObjects)
    {
        curObjects = new List<GameObject>();
        //case: we're generating a floor object
        if (pt == PLATFORM_TYPE.FLOOR_T)
        {
            var cur_length = x;
            while (cur_length < len)
            {
                //select random platform type
                PLATFORM_TYPE pt2;

                //debug stuff
                var rnum = _randomNum(0, 2);
                if (rnum == 1)
                    pt2 = PLATFORM_TYPE.FLOOR_T;
                else
                    pt2 = PLATFORM_TYPE.SPIKE_T;
                var num = _randomNum(1, 5);
                for (var i = 0; i < num; ++i)
                {
                    if (pt2 == PLATFORM_TYPE.FLOOR_T)
                    {
                        var obj = Instantiate(prefab_lowerPlatform, new Vector3(cur_length, y, 0), Quaternion.identity);
                        _currentFloorChunkObjects.Add(obj);
                        curObjects.Add(obj);
                    }
                    else
                    {
                        var obj = Instantiate(prefab_spikes, new Vector3(cur_length, y, 0), Quaternion.identity);
                        _currentFloorChunkObjects.Add(obj);
                        curObjects.Add(obj);
                    }
                    cur_length += BOX_WIDTH;
                }
            }
            _curFloorEnd = cur_length;
        }
        else if (pt == PLATFORM_TYPE.AIR_T)
        {
            Debug.Log("generating platform of type air");
            Debug.Log("cur_len: " + x + " len: " + len);
            var cur_length = x;
            while (cur_length < len)
            {
                Debug.Log("cur_len: " + cur_length + " len: " + len);
                curObjects.Add(Instantiate(prefab_lowerPlatform, new Vector3(cur_length, y), Quaternion.identity));
                cur_length += BOX_WIDTH;
            }
        }
    }

    /// <summary>
    /// removes distant tiles
    /// </summary>
    private void _checkMemory()
    {
        for (var i = 0; i < _currentFloorChunkObjects.Count; ++i)
        {
            if (_currentFloorChunkObjects[i].transform.position.x + 25f < _playerTransform.position.x)
            {
                Destroy(_currentFloorChunkObjects[i]);
                _currentFloorChunkObjects.RemoveAt(i);
                i--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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