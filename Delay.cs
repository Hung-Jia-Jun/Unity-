using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour {
     void Start()
    {
        print("Starting " + Time.time);
        StartCoroutine(WaitAndPrint(5));
        print("Done " + Time.time);
    }
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
    }
}
