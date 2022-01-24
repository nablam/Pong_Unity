using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleWaveCompleteWithTimer() {
        TimerBehavior t = gameObject.AddComponent<TimerBehavior>();
        t.StartTimer(2, WaveStartedGraphics);
    }

    public void WaveStartedGraphics()
    {

    }
}
