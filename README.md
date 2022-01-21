# Pong_Unity
Building a pong game to be played on raspberry pi using two custom analogue controllers. The unity side of pong using input system and build for WebGl. WHY? ... because reasons.


I thought about ways to build a simple game console and custom paddles for my kids. 
The general approch is to host the game on a raspberry pi and connect paddles to it.

1- using gpio to read analog joystick would require and extrenal ADC (I do have a few laying around, but this might be too much for this project PLUS I'm not sure ther's an easy way to make the browser get input from the gpio ...to be researched
2- creating a HID with an arduino loanardo, this microcontroller can read up to 5 analogue values. then using the HID device on the Pi
3- the ANdroid route: instead of building a webGL app to run on a raspbian chromium browser , I could just build for android, then load android 11 LineageOS on the pi.
   Not sure how a custom HID would register on android, but it seems better than trying to get gpio readings ....

right now i tested my HID : Leonardo with 2 paddles, each has a linear potentiometer with a lowpass filter that i designed , and a button. the device also supports 2 more buttons for Start and options.

A simple pong 3d looks a bit jittery on webGL , and the pi also needs to host nginx server to point to the build files. Chromium does not allow running webGL locally unless i change some security settings (bad idea in the long run for sure)

I think I ll take this project as far as I can untill I encounter major performance issiues despite all the possible optimization  .
When that happens, I ll look at the android route. 