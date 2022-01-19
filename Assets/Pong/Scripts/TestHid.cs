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
    public GameObject DebugObj;
    public GameObject Pad1;
    public GameObject Pad2;

    public GameObject P1Wall;
    public GameObject P2Wall;
    public GameObject Ball;

    public GameObject Barrier1;
    public GameObject Barrier2;
    TextMeshPro J1;
    TextMeshPro J2;
    TextMeshPro butttons;
    TextMeshPro DebugBox;
    string tmp = "";
    float P1val;
    float P2val;

    int P1Score = 0;
    int P2Score = 0;
    int numberOfBounces = 0;
    bool DisEnabWalls = true;
    int laststate=1;
    int curstate;
   // int avgFrameRate;
    void Start()
    {
        J1 = Oj1.GetComponent<TextMeshPro>();
        J2 = Oj2.GetComponent<TextMeshPro>();
        butttons = Ojbutt.GetComponent<TextMeshPro>();
        DebugBox= DebugObj.GetComponent<TextMeshPro>();
    }

    public void increaseP1() { P1Score++; }
    public void increaseP2() { P2Score++; }

    void resetAll() {
        P1Score = 0;
        P2Score = 0;
        resetBAll();
    }

   public void resetBAll() {
        Ball.transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTimer();
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        // Debug.Log(Input.GetAxis("Vertical1")+ " " + Input.GetAxis("Vertical2")) ;
        // Debug.Log(Input.GetAxisRaw("Vertical1") + " " + Input.GetAxisRaw("Vertical2"));

        //Debug.Log(Input.GetAxisRaw("P1_button1") + " " + Input.GetAxisRaw("P2_button1"));
        P1val =  Mathf.Round(Input.GetAxis("Vertical1") * 100f) / 100f;
        P2val = Mathf.Round(Input.GetAxis("Vertical2") * 100f) / 100f;
        J1.text = P1val.ToString();
        J2.text = P2val.ToString();

        Pad1.transform.position = new Vector3(Pad1.transform.position.x, 5 * P1val, Pad1.transform.position.z);
        Pad2.transform.position = new Vector3(Pad2.transform.position.x, 5 * P2val, Pad2.transform.position.z);

      //  tmp = Input.GetAxisRaw("P1_button1").ToString() + " " + Input.GetAxisRaw("P1_button2").ToString() +" " + Input.GetAxisRaw("P2_button1").ToString() + " " + Input.GetAxisRaw("P2_button2").ToString();
        tmp = P1Score.ToString() + "  -   " + P2Score.ToString();

        if (Input.GetAxisRaw("P1_button1") > 0.5f) {
            resetAll();
        }

        curstate = (int) Input.GetAxisRaw("P1_button2");
        if (curstate ==1 && laststate==0)
        {
            DisEnabWalls = !DisEnabWalls;

            Barrier1.SetActive(DisEnabWalls);
            Barrier2.SetActive(DisEnabWalls);
            laststate = 1;
        }
        butttons.text = tmp;


        string DebugString = Input.GetAxisRaw("P1_button1").ToString() + " " + Input.GetAxisRaw("P1_button2").ToString() + " " + Input.GetAxisRaw("P2_button1").ToString() + " " + Input.GetAxisRaw("P2_button2").ToString();
        DebugBox.text = DebugString;
        //float current = 0;
        //current = Time.frameCount / Time.time;
        //avgFrameRate = (int)current;
        //J2.text = avgFrameRate.ToString() + " FPS";
    }

    float timeRunning = 0.0f;
    void UpdateTimer()
    {
        timeRunning += Time.deltaTime;
        if (timeRunning >= 2.0f)
        {
            //Do things
            timeRunning = 0.0f; //Restart counting
            laststate = 0;
        }
    }
}
