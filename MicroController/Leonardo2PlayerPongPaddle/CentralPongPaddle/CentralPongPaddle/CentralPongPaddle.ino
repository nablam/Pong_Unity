/*
 Name:		CentralPongPaddle.ino
 Created:	1/19/2022 2:23:17 PM
 Author:	Nabz
*/


// the setup function runs once when you press reset or power the board

#include "Joystick.h"

// Create Joystick
Joystick_ Joystick(0x0B, JOYSTICK_TYPE_GAMEPAD, 4, 0, true, true, false, false, false, false, false, false, false, false, false);


#pragma region vars

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

#pragma endregion
void setup() {
    //Serial.begin(115200);
    Do_setup();
}

void loop() {
    Do_loop();
    //Serial.println(Pad1_PotValue);
    //Serial.println(Pad1_potCleanVal);

}


