using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoySticksAnalog : MonoBehaviour
{
    public static JoySticksAnalog Instance = null;

    public delegate void TriggerHandler(int argNum);
    public static TriggerHandler ButtonPress;
    public void call_ButtonClicked(int argNum) { if (NewMethod()) { ButtonPress(argNum); } }

    public float GetP1Potval() { return P1val; }
    public float GetP2Potval() { return P2val; }
    private bool NewMethod()
    {
        return ButtonPress != null;
    }

    float P1val;
    float P2val;
    
    int[] buttonarra_curState;
    int[] buttonarra_lastState;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            buttonarra_curState = new int[20];
            buttonarra_lastState = new int[20];
        }
        else
            Destroy(gameObject);
    }
   
    void Start()
    {
        //JoySticksAnalog.Instance.getstaticdatas
        Debug.Log("started");
    }
    string tmp = "";
    void FixedUpdate()
    {
        GetAllInputs();
        Button_clicks();
    }



    void GetAllInputs() {
        P1val = Mathf.Round(Input.GetAxis("Vertical1") * -100f) / 100f;
        P2val = Mathf.Round(Input.GetAxis("Vertical2") * -100f) / 100f;

        for (int i = 0; i < 20; i++)
        {
            buttonarra_curState[i] = (int)Input.GetAxisRaw(EnumHelper.ToEnum("B_" + i, ButtonNames.B_0).ToString());
        }

    }

    void Button_clicks() {

        for (int i = 0; i < 20; i++)
        {
            if (buttonarra_curState[i] != 0 && buttonarra_lastState[i] == 0)
            {

                //send 1 once
                Debug.Log("once" + i.ToString()) ;
                call_ButtonClicked(i);
                buttonarra_lastState[i] = buttonarra_curState[i];
            }
        }

        for (int i = 0; i < 20; i++)
        {
            if (buttonarra_curState[i] == 0 && buttonarra_lastState[i] == 1)
            {
                buttonarra_lastState[i] = 0;
            }
        }
    }

 

}
