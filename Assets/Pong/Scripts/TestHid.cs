using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        // Debug.Log(Input.GetAxis("Vertical1")+ " " + Input.GetAxis("Vertical2")) ;
        // Debug.Log(Input.GetAxisRaw("Vertical1") + " " + Input.GetAxisRaw("Vertical2"));
        Debug.Log(Input.GetAxisRaw("P1_button1") + " " + Input.GetAxisRaw("P2_button1"));
    }
}
