using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class MinHeap : IEnumerable<GameObject>
{

    private List<GameObject> _internalList;

    public MinHeap()
    {
        _internalList = new List<GameObject>();
    }

    public void _sort()
    {
        _internalList.Sort((GameObject obj1, GameObject obj2) => obj1.transform.position.x.CompareTo(obj2.transform.position.x));
    }

    /// <summary>
    /// really expensive, lazy method
    /// </summary>
    /// <param name="gameObject">object to add</param>
    public void Add(GameObject gameObject)
    {
        _internalList.Add(gameObject);
        _sort();
    }

    public void AddRange(List<GameObject> list)
    {
        _internalList.AddRange(list);
        _sort();
    }

    public int Size() { return _internalList.Count;  }

    /// <summary>
    /// remove the first element
    /// </summary>
    public void Remove()
    {
        if (_internalList.Count == 0)
            return;
        else _internalList.RemoveAt(0);
    }

    /// <summary>
    /// get the first item
    /// </summary>
    /// <returns></returns>
    public GameObject Get()
    {
        return _internalList[0];
    }

    /// <summary>
    /// auto generated shit
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<GameObject>)_internalList).GetEnumerator();
    }

    /// <summary>
    /// auto generated shit
    /// </summary>
    public IEnumerator<GameObject> GetEnumerator()
    {
        return ((IEnumerable<GameObject>)_internalList).GetEnumerator();
    }
}