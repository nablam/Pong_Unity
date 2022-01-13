using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TestHid : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Oj1;
    public GameObject Oj2;
    public GameObject Ojbutt;

    TextMeshPro J1;
    TextMeshPro J2;
    TextMeshPro butttons;
    string tmp = "";
    void Start()
    {
        J1 = Oj1.GetComponent<TextMeshPro>();
        J2 = Oj2.GetComponent<TextMeshPro>();
        butttons = Ojbutt.GetComponent<TextMeshPro>();


    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        // Debug.Log(Input.GetAxis("Vertical1")+ " " + Input.GetAxis("Vertical2")) ;
        // Debug.Log(Input.GetAxisRaw("Vertical1") + " " + Input.GetAxisRaw("Vertical2"));
        Debug.Log(Input.GetAxisRaw("P1_button1") + " " + Input.GetAxisRaw("P2_button1"));
        J1.text = Input.GetAxis("Vertical1").ToString();
        J2.text = Input.GetAxisRaw("Vertical2").ToString();

  

        tmp = Input.GetAxisRaw("P1_button1").ToString() + " " + Input.GetAxisRaw("P2_button1").ToString();
        butttons.text = tmp;
    }
}
