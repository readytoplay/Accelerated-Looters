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
    public GameObject prefab_enemy1;
    public GameObject prefab_enemy2;
    public GameObject prefab_coins;
    public GameObject prefab_pu1;
    public GameObject prefab_pu2;
    public GameObject prefab_pu3;
    public GameObject prefab_pu4;

    //state variables
    private Chunk _curChunk;
    private float _curFloorEnd;
    private float _curPlatformEnd;
    private System.Random _random;

    //game variables
    private Transform _playerTransform;
    private MinHeap _currentFloorChunkObjects;
    private List<float> _currentPlatformLocations;
    private List<float> _curEnemyLocations;

    //useful info
    private const float BOX_WIDTH = 0.8f, FLOOR_Y = -3f;
    private float CHUNK_W = 50f;

    //probabilities
    private const float ENEMY1_PROB = 0.05f;
    private const float ENEMY2_PROB = 0.05f;
    private const float COIN_PROB   = 0.50f;
    private const float PU1_PROB = 0.01f;
    private const float PU2_PROB = 0.01f;
    private const float PU3_PROB = 0.01f;
    private const float PU4_PROB = 0.01f;

    //initialize list before
    private void Awake()
    {
        _currentFloorChunkObjects = new MinHeap();
        _currentPlatformLocations = new List<float>();
        _curEnemyLocations = new List<float>();
        _random = new System.Random();
    }

    // Use this for initialization
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _curChunk = new Chunk(CHUNK_W);
        _fillChunk(_curChunk);
        _curPlatformEnd = 0;
        StartCoroutine(_removeMostDistantPlatform());
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
        _fillChunkWithPrefabs(curItems);
    }

    /// <summary>
    /// fills the gven chunk with enemies/coins/powerups/etc
    /// </summary>
    /// <param name="curItems"></param>
    private void _fillChunkWithPrefabs(List<GameObject> curItems)
    {
        //find ground floor items
        foreach(var gameObject in _currentFloorChunkObjects)
        {
            if(gameObject.tag == "Ground")
            {
                _randomSpawn(gameObject.transform.position.x, gameObject.transform.position.y+1f);
            }
        }
    }

    /// <summary>
    /// return true within selected probability
    /// </summary>
    /// <param name="prob"></param>
    private bool _rollWithProbability(float prob)
    {
        if (_random.NextDouble() < prob)
            return true;
        else return false;
    }

    /// <summary>
    /// spawn random given probabilities
    /// </summary>
    private void _randomSpawn(float x, float y)
    {

        foreach(var elem in _curEnemyLocations)
        {
            if (Math.Abs(elem - x) < 10f)
                return;
        }

        if (Math.Abs(_playerTransform.position.x - x) < 30f)
            return;

        if (_rollWithProbability(ENEMY1_PROB))
        {
            GameObject.Instantiate(prefab_enemy1, new Vector3(x, y), Quaternion.identity);
            _curEnemyLocations.Add(x);
        }
        else if (_rollWithProbability(ENEMY2_PROB))
        {
            GameObject.Instantiate(prefab_enemy2, new Vector3(x, y), Quaternion.identity);
            _curEnemyLocations.Add(x);
        }

        if (_rollWithProbability(COIN_PROB)){
            GameObject.Instantiate(prefab_coins, new Vector3(x, y), Quaternion.identity);
        }

        if (_rollWithProbability(PU1_PROB))
        {
            GameObject.Instantiate(prefab_pu1, new Vector3(x, y), Quaternion.identity);
        }
        else if (_rollWithProbability(PU2_PROB))
        {
            GameObject.Instantiate(prefab_pu2, new Vector3(x, y), Quaternion.identity);
        }
        else if (_rollWithProbability(PU3_PROB))
        {
            GameObject.Instantiate(prefab_pu3, new Vector3(x, y), Quaternion.identity);
        }
        else if (_rollWithProbability(PU4_PROB))
        {
            GameObject.Instantiate(prefab_pu4, new Vector3(x, y), Quaternion.identity);
        }
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

        if (_currentPlatformLocations.Contains(spikeChunk[0].transform.position.x))
            return;

        //random variables
        var start_x = _randomNum(0,3);
        var end_x = _randomNum(spikeChunk.Count - 3, spikeChunk.Count);
        var random_y_jumpable = _random.NextDouble() * (3) + 1.5f;

        //parameter calcuations
        var _x = spikeChunk[start_x].transform.position.x;
        var _y = (float)(spikeChunk[0].transform.position.y + random_y_jumpable);
        var _len = spikeChunk[end_x].transform.position.x - spikeChunk[start_x].transform.position.x;


        List <GameObject> temp;
        _generatePiece(
            x:          _x,
            y:          _y,
            len:        _len,
            pt:         PLATFORM_TYPE.AIR_T,
            curObjects: out temp 
        );
        _currentFloorChunkObjects.AddRange(temp);
        _currentPlatformLocations.Add(spikeChunk[0].transform.position.x);
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
                var rnum = _randomNum(0, 3);
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
            var plen = x + len;
            var cur_length = x;
            while (cur_length < plen)
            {
                curObjects.Add(Instantiate(prefab_lowerPlatform, new Vector3(cur_length, y), Quaternion.identity));
                cur_length += BOX_WIDTH;
            }
            _curPlatformEnd = cur_length;
        }
    }

    /// <summary>
    /// removes the most left-distant platform (aka lowest x value)
    /// </summary>
    private IEnumerator _removeMostDistantPlatform()
    {
        float timeout = 0.3f;
        while (true)
        {
            if (_currentFloorChunkObjects.Size() == 0)
                continue;

            var curObj = _currentFloorChunkObjects.Get();
            yield return new WaitForSeconds(timeout);

            _currentFloorChunkObjects.Remove();
            Destroy(curObj);

            if (timeout > 0.02f)
            {
                timeout -= 0.001f;
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