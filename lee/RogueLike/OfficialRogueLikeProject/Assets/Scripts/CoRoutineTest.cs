using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoRoutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(1));
        Debug.Log("start 2");
        StartCoroutine(Wait(2));
        Debug.Log("start 3");
        StartCoroutine(Wait(3));
        //StartCoroutine(SaySomething());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Wait(float seconds)
    {
        for (float floatTimer = 0; floatTimer < seconds; floatTimer += Time.deltaTime)
        {
            Debug.Log(seconds);
            yield return "342342342";
        }

        Debug.Log($"waited {seconds} already,function ended.");
    }

    IEnumerator SaySomething()
    {
        Debug.Log("start");
        yield return StartCoroutine(Wait(1));
        Debug.Log("1");
        yield return StartCoroutine(Wait(2));
        Debug.Log("2");
        yield return StartCoroutine(Wait(3));
    }
}