#include <math.h>
//#include "Joystick2.h"

#include "Joystick.h"
#define MINI 0
#define MAXI 1000
// Create Joystick
Joystick_ Joystick;// (JOYSTICK_TYPE_JOYSTICK, JOYSTICK_TYPE_JOYSTICK, 4, 0, true, true, false, false, false, false, false, false, false, false, false);

const bool initAutostate = true; //true sends auto, false needs polling with .sendSate()
int _xAxis = 0; //xAxis is RESERVED!!
int _yAxis = 0;

const int Button1_pin = 8;
const int Button2_pin = 9;
const int Button3_pin = 10;
const int Button4_pin = 11;

const int Mode_Pin = 12;
const int LED_PIN = 13;


int lastButtonStates[4] = { 0,0,0,0 };
const int pinToButtonMap = 8;

float Pad1_PotValue;
int Pad1_potCleanVal;
float Pad2_PotValue;
int Pad2_potCleanVal;
const int ledPin = 13;

int MODE_ledState = LOW;     // the current state of LED
int MODE_lastButtonState;    // the previous state of button
int MODE_currentButtonState;

int _min; //0 for unity and -127 for raspi
int _max;

//*******************************************************************************************************************
//                HID iD               num of buttons up 50, num hatswitches up to 2 max, X, Y, Z, rotX, rotY, rotZ, rudder, throttle, accelerometr, break  steering)
//Joystick_ Joystick(0x07, JOYSTICK_TYPE_JOYSTICK, 4, 0, true, true, false, false, false, false, false, false, false, false, false);
//************************************************************

void setup() {
    // put your setup code here, to run once:
     // Serial.begin(9600 );   
    pinMode(Button1_pin, INPUT_PULLUP);
    pinMode(Button2_pin, INPUT_PULLUP);
    pinMode(Button3_pin, INPUT_PULLUP);
    pinMode(Button4_pin, INPUT_PULLUP);
    pinMode(Mode_Pin, INPUT_PULLUP);
    pinMode(LED_PIN, OUTPUT);
    MODE_currentButtonState = digitalRead(Mode_Pin);
    //************************************************************
    Joystick.setXAxisRange(MINI, MAXI);
    Joystick.setYAxisRange(MINI, MAXI);
    Joystick.begin();
    //  Joystick[0].begin();
     // Joystick[1].begin();
     //************************************************************
}

void ReadAnalogAndMap(int rangemin, int rangemax) {
    Pad1_PotValue = analogRead(A0);
    Pad2_PotValue = analogRead(A1);
    Pad1_potCleanVal = map(Pad1_PotValue, 0, 1023, rangemin, rangemax);//   round( sensorValue) / 10;  
    Pad2_potCleanVal = map(Pad2_PotValue, 0, 1023, rangemin, rangemax);
}
void ReadAnSetButtons() {

    for (int index = 0; index < 4; index++)
    {
        int currentButtonState = !digitalRead(index + pinToButtonMap);
        if (currentButtonState != lastButtonStates[index])
        {
            //************************************************************
           // Joystick.setButton(index, currentButtonState);
            // Joystick[0].setButton(index, currentButtonState);
            // Joystick[1].setButton(index, currentButtonState);
         //************************************************************
            lastButtonStates[index] = currentButtonState;
        }
    }

    for (int index = 0; index < 4; index++)
    {
        if (lastButtonStates[index] == 1) {
            Joystick.pressButton(index);

        }
        else
        {
            Joystick.releaseButton(index);
        }
    }
}

void ReadModeButton() {
    MODE_lastButtonState = MODE_currentButtonState;
    MODE_currentButtonState = digitalRead(Mode_Pin);

    if (MODE_lastButtonState == HIGH && MODE_currentButtonState == LOW) {


        // toggle state of LED
        MODE_ledState = !MODE_ledState;

        // control LED arccoding to the toggled state
        digitalWrite(LED_PIN, MODE_ledState);
    }
}





void loop() {
    if (MODE_ledState == true)
    {
        _min = 10;
        _max = 1000;

    }
    else
    {
        _min = 0;
        _max = 512;
    }
    ReadAnalogAndMap(_min, _max);
    ReadAnSetButtons();
    ReadModeButton();
    //************************************************************
    Joystick.setYAxis(Pad1_PotValue);
    Joystick.setXAxis(Pad2_PotValue);

    //Joystick[0].setYAxis(Pad1_potCleanVal);
    //Joystick[0].setXAxis(Pad2_potCleanVal);
    //Joystick[1].setYAxis(Pad1_potCleanVal);
    //Joystick[1].setXAxis(Pad2_potCleanVal);
    //************************************************************

    //Serial.println(Pad1_potCleanVal); 
    delay(20);
}
