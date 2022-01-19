#include <math.h>
//

//*******************************************************************************************************************
//                HID iD               num of buttons up 50, num hatswitches up to 2 max, X, Y, Z, rotX, rotY, rotZ, rudder, throttle, accelerometr, break  steering)
//Joystick_ Joystick(0x07, JOYSTICK_TYPE_JOYSTICK, 4, 0, true, true, false, false, false, false, false, false, false, false, false);
//************************************************************



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
            Joystick.setButton(index, currentButtonState);
            // Joystick[0].setButton(index, currentButtonState);
            // Joystick[1].setButton(index, currentButtonState);
         //************************************************************
            lastButtonStates[index] = currentButtonState;
        }
    }

    //for (int index = 0; index < 4; index++)
    //{
    //    if (lastButtonStates[index] == 1) { Joystick.pressButton(index); }
    //    else {
    //        Joystick.releaseButton(index);
    //    }
    //}
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

void Do_setup() {
    // put your setup code here, to run once:

    pinMode(Button1_pin, INPUT_PULLUP);
    pinMode(Button2_pin, INPUT_PULLUP);
    pinMode(Button3_pin, INPUT_PULLUP);
    pinMode(Button4_pin, INPUT_PULLUP);
    pinMode(Mode_Pin, INPUT_PULLUP);
    pinMode(LED_PIN, OUTPUT);
    MODE_currentButtonState = digitalRead(Mode_Pin);
    //************************************************************
    Joystick.begin();
    //  Joystick[0].begin();
     // Joystick[1].begin();
     //************************************************************
}

void Do_loop() {
    if (MODE_ledState == true) { _min = 0; }
    else
        _min = -127;
    ReadAnalogAndMap(_min, 127);
    ReadAnSetButtons();
    ReadModeButton();
    //************************************************************
    Joystick.setYAxis(Pad1_potCleanVal);
    Joystick.setXAxis(Pad2_potCleanVal);

    //Joystick[0].setYAxis(Pad1_potCleanVal);
    //Joystick[0].setXAxis(Pad2_potCleanVal);
    //Joystick[1].setYAxis(Pad1_potCleanVal);
    //Joystick[1].setXAxis(Pad2_potCleanVal);
    //************************************************************


    delay(20);
}