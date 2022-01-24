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
    public GameObject DebugObjList;
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
    TextMeshPro DebugBoxList;
    string tmp = "";
    float P1val;
    float P2val;

    int P1Score = 0;
    int P2Score = 0;
    int numberOfBounces = 0;
    bool DisEnabWalls = true;
    int laststate=1;
    int curstate;
    int temp=-1;
   // int avgFrameRate;
    void Start()
    {
        J1 = Oj1.GetComponent<TextMeshPro>();
        J2 = Oj2.GetComponent<TextMeshPro>();
        butttons = Ojbutt.GetComponent<TextMeshPro>();
        DebugBox= DebugObj.GetComponent<TextMeshPro>();
        DebugBoxList= DebugObjList.GetComponent<TextMeshPro>();
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

        //Debug.Log(Input.GetAxisRaw("B_0") + " " + Input.GetAxisRaw("B_2"));

        P1val = Input.GetAxis("Vertical1");
        P2val = Input.GetAxis("Vertical2");
        J1.text = P1val.ToString();
        J2.text = P2val.ToString();
        P1val =  Mathf.Round(Input.GetAxis("Vertical1") * 100f) / 100f;
        P2val = Mathf.Round(Input.GetAxis("Vertical2") * 100f) / 100f;
    

        Pad1.transform.position = new Vector3(Pad1.transform.position.x, 5 * P1val, Pad1.transform.position.z);
        Pad2.transform.position = new Vector3(Pad2.transform.position.x, 5 * P2val, Pad2.transform.position.z);

      //  tmp = Input.GetAxisRaw("B_0").ToString() + " " + Input.GetAxisRaw("B_1").ToString() +" " + Input.GetAxisRaw("B_2").ToString() + " " + Input.GetAxisRaw("B_3").ToString();
        tmp = P1Score.ToString() + "  -   " + P2Score.ToString();

        if (Input.GetAxisRaw("B_0") > 0.5f) {
            resetAll();
        }

        curstate = (int) Input.GetAxisRaw("B_1");
        if (curstate ==1 && laststate==0)
        {
            DisEnabWalls = !DisEnabWalls;

            Barrier1.SetActive(DisEnabWalls);
            Barrier2.SetActive(DisEnabWalls);
            laststate = 1;
        }
        butttons.text = tmp;

        int JsButtonval = 9;

        if (Input.GetAxisRaw("B_0") > 0.5f)
        {
            JsButtonval = 0;
        } else 
            if (Input.GetAxisRaw("B_1") > 0.5f) 
        {
            JsButtonval = 1;
        }
        else
            if (Input.GetAxisRaw("B_2") > 0.5f)
        {
            JsButtonval = 2;
        }
        else
            if (Input.GetAxisRaw("B_3") > 0.5f)
        {
            JsButtonval = 3;
        }
        else
            if (Input.GetAxisRaw("B_4") > 0.5f)
        {
            JsButtonval = 4;
        }
        else
            if (Input.GetAxisRaw("B_5") > 0.5f)
        {
            JsButtonval = 5;
        }
        else
            if (Input.GetAxisRaw("B_6") > 0.5f)
        {
            JsButtonval = 6;
        }
        else
            if (Input.GetAxisRaw("B_7") > 0.5f)
        {
            JsButtonval = 7;
        }

        if (JsButtonval < 9) {

            if (JsButtonval != temp) {

                DebugBoxList.text += "\n heard JS B_" + JsButtonval;
            }
              temp=JsButtonval;
        }

        string DebugString   = "b." + JsButtonval.ToString() + "  |  " +
                Input.GetAxisRaw("B_0").ToString() + " " +
                Input.GetAxisRaw("B_1").ToString() + " " +
                Input.GetAxisRaw("B_2").ToString() + " " + 
                Input.GetAxisRaw("B_3").ToString() + " " + 
                Input.GetAxisRaw("B_4").ToString() + " " + 
                Input.GetAxisRaw("B_5").ToString() + " " + 
                Input.GetAxisRaw("B_6").ToString() + " " + 
                Input.GetAxisRaw("B_7").ToString();

       


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
