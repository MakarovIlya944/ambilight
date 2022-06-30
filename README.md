# Ambilight
It's windows app for capturing border colours and send them on serial port for arduino with argb led ws2812b. This project inspired by https://alexgyver.ru/arduino_ambilight/

# App
App created on Windows Forms. For now there is only base functionallity like preview colour capture and change height of capturing cells. 
I setup led strip orientantion hardcoded, but you can modify it in code.

# Arduino
Arduino part uses FastLED.h lib https://github.com/FastLED/FastLED .