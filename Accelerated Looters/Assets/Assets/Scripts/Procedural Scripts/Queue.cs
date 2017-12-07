using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Queue : IEnumerable<GameObject>
{

    private List<GameObject> _internalList;

    public List<GameObject> GetList(){return _internalList;}

    public Queue()
    {
        _internalList = new List<GameObject>();
    }

    /// <summary>
    /// really expensive, lazy method
    /// </summary>
    /// <param name="gameObject">object to add</param>
    public void Add(GameObject gameObject)
    {
        _internalList.Add(gameObject);
    }

    public void AddRange(List<GameObject> list)
    {
        _internalList.AddRange(list);
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

    internal static class Cloner {
        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }
    }

    public List<GameObject> Clone()
    {
        return (List<GameObject>)Cloner.DeepClone(_internalList);
    }
}