using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeExamples : MonoBehaviour
{
    //must be either static or somethin to be accecible
    public delegate void TriggerHandler(int argNum);
    public static TriggerHandler CountDownHandler;
    public void call_CountDownAudioVideo(int argNum) { if (NewMethod()) { CountDownHandler(argNum); } }
    //anyone can call JoySticksAnalog.Instance.call_CountDownAudioVideo(10);
    private bool NewMethod()
    {
        return CountDownHandler != null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoCoroutine()
    {
        StartCoroutine(AUTOGOTO_DataEntry(10));
    }

    IEnumerator AUTOGOTO_DataEntry(int arg8)
    {
        yield return new WaitForSeconds(arg8);
    }
}
