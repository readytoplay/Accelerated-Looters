using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour  {
    public int time = 0;
    public Text timer;

    // Use this for initialization
    void Start()    {
        StartCoroutine("TimeIncrement");
    }

    // Update is called once per frame
    void Update()   {
        timer.text = (time + "s");

    }

    IEnumerator TimeIncrement()  {
        while (true)    {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}